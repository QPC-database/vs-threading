﻿//-----------------------------------------------------------------------
// <copyright file="InternalUtilities.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.VisualStudio.Threading {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.CompilerServices;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// Internal helper/extension methods for this assembly's own use.
	/// </summary>
	internal static class InternalUtilities {
		/// <summary>
		/// Removes an element from the middle of a queue without disrupting the other elements.
		/// </summary>
		/// <typeparam name="T">The element to remove.</typeparam>
		/// <param name="queue">The queue to modify.</param>
		/// <param name="valueToRemove">The value to remove.</param>
		/// <remarks>
		/// If a value appears multiple times in the queue, only its first entry is removed.
		/// </remarks>
		internal static bool RemoveMidQueue<T>(this Queue<T> queue, T valueToRemove) where T : class {
			Requires.NotNull(queue, "queue");
			Requires.NotNull(valueToRemove, "valueToRemove");
			if (queue.Count == 0) {
				return false;
			}

			T originalHead = queue.Dequeue();
			if (Object.ReferenceEquals(originalHead, valueToRemove)) {
				return true;
			}

			bool found = false;
			queue.Enqueue(originalHead);
			while (!Object.ReferenceEquals(originalHead, queue.Peek())) {
				var tempHead = queue.Dequeue();
				if (!found && Object.ReferenceEquals(tempHead, valueToRemove)) {
					found = true;
				} else {
					queue.Enqueue(tempHead);
				}
			}

			return found;
		}

		/// <summary>
		/// Walk the continuation objects inside "async state machines" to generate the return callstack.
		/// FOR DIAGNOSTIC PURPOSES ONLY.
		/// </summary>
		/// <param name="continuationDelegate">The delegate that represents the head of an async continuation chain.</param>
		internal static IEnumerable<string> GetAsyncReturnStackFrames(this Delegate continuationDelegate) {
			var stateMachine = FindAsyncStateMachine(continuationDelegate);
			if (stateMachine == null) {
				// Did not find the async state machine, so returns the method name as top frame and stop walking.
				yield return GetDelegateLabel(continuationDelegate);
				yield break;
			}

			do {
				var state = GetStateMachineFieldValueOnSuffix(stateMachine, "__state");
				yield return string.Format(
					CultureInfo.CurrentCulture,
					"{0} ({1})",
					stateMachine.GetType().FullName,
					state);

				var continuationDelegates = FindContinuationDelegates(stateMachine).ToArray();
				if (continuationDelegates.Length == 0) {
					break;
				}

				// Consider: It's possible but uncommon scenario to have multiple "async methods" being awaiting for one "async method".
				// Here we just choose the first awaiting "async method" as that should be good enough for postmortem.
				// In future we might want to revisit this to cover the other awaiting "async methods".
				stateMachine = continuationDelegates.Select((d) => FindAsyncStateMachine(d))
					.FirstOrDefault((s) => s != null);
				if (stateMachine == null) {
					yield return GetDelegateLabel(continuationDelegates.First());
				}
			} while (stateMachine != null);
		}

		/// <summary>
		/// A helper method to get the label of the given delegate.
		/// </summary>
		private static string GetDelegateLabel(Delegate invokeDelegate) {
			Requires.NotNull(invokeDelegate, "invokeDelegate");

			if (invokeDelegate.Target != null) {
				return string.Format(
					CultureInfo.CurrentCulture,
					"{0}.{1} ({2})",
					invokeDelegate.Method.DeclaringType.FullName,
					invokeDelegate.Method.Name,
					invokeDelegate.Target.GetType().FullName);
			}

			return string.Format(
				CultureInfo.CurrentCulture,
				"{0}.{1}",
				invokeDelegate.Method.DeclaringType.FullName,
				invokeDelegate.Method.Name);
		}

		/// <summary>
		/// A helper method to find the async state machine from the given delegate.
		/// </summary>
		private static IAsyncStateMachine FindAsyncStateMachine(Delegate invokeDelegate) {
			Requires.NotNull(invokeDelegate, "invokeDelegate");

			if (invokeDelegate.Target != null) {
				// Some delegates are wrapped with a ContinuationWrapper object. We have to unwrap that in those cases.
				// In testing, this m_continuation field jump is only required when the debugger is attached -- weird.
				// I suspect however that it's a natural behavior of the async state machine (when there are >1 continuations perhaps).
				// So we check for the case in all cases.
				var continuation = GetFieldValue(invokeDelegate.Target, "m_continuation") as Action;
				if (continuation != null) {
					invokeDelegate = continuation;
				}

				var stateMachine = GetFieldValue(invokeDelegate.Target, "m_stateMachine") as IAsyncStateMachine;
				return stateMachine;
			}

			return null;
		}

		/// <summary>
		/// This is the core to find the continuation delegate(s) inside the given async state machine.
		/// The chain of objects is like this: async state machine -> async method builder -> task -> continuation object -> action.
		/// </summary>
		/// <remarks>
		/// There are 3 types of "async method builder": AsyncVoidMethodBuilder, AsyncTaskMethodBuilder, AsyncTaskMethodBuilder&lt;T&gt;.
		/// We don't cover AsyncVoidMethodBuilder as it is used rarely and it can't be awaited either;
		/// AsyncTaskMethodBuilder is a wrapper on top of AsyncTaskMethodBuilder&lt;VoidTaskResult&gt;.
		/// </remarks>
		private static IEnumerable<Delegate> FindContinuationDelegates(IAsyncStateMachine stateMachine) {
			Requires.NotNull(stateMachine, "stateMachine");

			var builder = GetStateMachineFieldValueOnSuffix(stateMachine, "__builder");
			if (builder == null) {
				yield break;
			}

			var task = GetFieldValue(builder, "m_task");
			if (task == null) {
				// Probably this builder is an instance of "AsyncTaskMethodBuilder", so we need to get its inner "AsyncTaskMethodBuilder<VoidTaskResult>"
				builder = GetFieldValue(builder, "m_builder");
				if (builder != null) {
					task = GetFieldValue(builder, "m_task");
				}
			}

			if (task == null) {
				yield break;
			}

			// "task" might be an instance of the type deriving from "Task", but "m_continuationObject" is a private field in "Task",
			// so we need to use "typeof(Task)" to access "m_continuationObject".
			var continuationField = typeof(Task).GetField("m_continuationObject", BindingFlags.Instance | BindingFlags.NonPublic);
			if (continuationField == null) {
				yield break;
			}

			var continuationObject = continuationField.GetValue(task);
			if (continuationObject == null) {
				yield break;
			}

			var items = continuationObject as IEnumerable;
			if (items != null) {
				foreach (var item in items) {
					var action = item as Delegate ?? GetFieldValue(item, "m_action") as Delegate;
					if (action != null) {
						yield return action;
					}
				}
			} else {
				var action = continuationObject as Delegate ?? GetFieldValue(continuationObject, "m_action") as Delegate;
				if (action != null) {
					yield return action;
				}
			}
		}

		/// <summary>
		/// A helper method to get field's value given the object and the field name.
		/// </summary>
		private static object GetFieldValue(object obj, string fieldName) {
			Requires.NotNull(obj, "obj");
			Requires.NotNullOrEmpty(fieldName, "fieldName");

			var field = obj.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			if (field != null) {
				return field.GetValue(obj);
			}

			return null;
		}

		/// <summary>
		/// The field names of "async state machine" are not fixed; the workaround is to find the field based on the suffix.
		/// </summary>
		private static object GetStateMachineFieldValueOnSuffix(IAsyncStateMachine stateMachine, string suffix) {
			Requires.NotNull(stateMachine, "stateMachine");
			Requires.NotNullOrEmpty(suffix, "suffix");

			var fields = stateMachine.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			var field = fields.FirstOrDefault((f) => f.Name.EndsWith(suffix, StringComparison.Ordinal));
			if (field != null) {
				return field.GetValue(stateMachine);
			}

			return null;
		}
	}
}
