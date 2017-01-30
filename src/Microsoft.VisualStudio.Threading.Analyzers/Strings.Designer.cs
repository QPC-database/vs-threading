﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Threading.Analyzers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.VisualStudio.Threading.Analyzers.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Await {0} instead.
        /// </summary>
        internal static string AwaitXInstead {
            get {
                return ResourceManager.GetString("AwaitXInstead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use await instead.
        /// </summary>
        internal static string UseAwaitInstead {
            get {
                return ResourceManager.GetString("UseAwaitInstead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Synchronously waiting on tasks or awaiters may cause deadlocks. Use JoinableTaskFactory.Run instead..
        /// </summary>
        internal static string VSSDK001_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK001_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid problematic synchronous waits.
        /// </summary>
        internal static string VSSDK001_Title {
            get {
                return ResourceManager.GetString("VSSDK001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Visual Studio service &quot;{0}&quot; should be used on main thread explicitly. 
        ///Call ThreadHelper.ThrowIfNotOnUIThread() or await JoinableTaskFactory.SwitchToMainThreadAsync() first..
        /// </summary>
        internal static string VSSDK002_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK002_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use VS services from UI thread.
        /// </summary>
        internal static string VSSDK002_Title {
            get {
                return ResourceManager.GetString("VSSDK002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change return type to Task.
        /// </summary>
        internal static string VSSDK003_CodeFix_Title {
            get {
                return ResourceManager.GetString("VSSDK003_CodeFix_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid &quot;async void&quot; methods, because any exceptions not handled by the method will crash the process..
        /// </summary>
        internal static string VSSDK003_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK003_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid async void methods.
        /// </summary>
        internal static string VSSDK003_Title {
            get {
                return ResourceManager.GetString("VSSDK003_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using async lambda for a void returning delegate type, because any exceptions not handled by the delegate will crash the process..
        /// </summary>
        internal static string VSSDK004_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK004_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid unsupported async delegates.
        /// </summary>
        internal static string VSSDK004_Title {
            get {
                return ResourceManager.GetString("VSSDK004_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AsyncEventHandler delegates should be invoked via the extension method &quot;TplExtensions.InvokeAsync()&quot; defined in Microsoft.VisualStudio.Threading assembly..
        /// </summary>
        internal static string VSSDK005_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK005_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use InvokeAsync to raise async events.
        /// </summary>
        internal static string VSSDK005_Title {
            get {
                return ResourceManager.GetString("VSSDK005_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Calling await on a Task inside a JoinableTaskFactory.Run, when the task is initialized outside the delegate can cause potential deadlocks.
        ///You can avoid this problem by ensuring the task is initialized within the delegate or by using JoinableTask instead of Task..
        /// </summary>
        internal static string VSSDK006_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK006_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid awaiting non-joinable tasks in join contexts.
        /// </summary>
        internal static string VSSDK006_Title {
            get {
                return ResourceManager.GetString("VSSDK006_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lazy&lt;Task&lt;T&gt;&gt;.Value can deadlock.
        ///Use AsyncLazy&lt;T&gt; instead..
        /// </summary>
        internal static string VSSDK007_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK007_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid using Lazy&lt;T&gt; where T is a Task&lt;T2&gt;.
        /// </summary>
        internal static string VSSDK007_Title {
            get {
                return ResourceManager.GetString("VSSDK007_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} synchronously blocks. Await {1} instead..
        /// </summary>
        internal static string VSSDK008_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK008_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} synchronously blocks. Use await instead..
        /// </summary>
        internal static string VSSDK008_MessageFormat_UseAwaitInstead {
            get {
                return ResourceManager.GetString("VSSDK008_MessageFormat_UseAwaitInstead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Call async methods when in an async method.
        /// </summary>
        internal static string VSSDK008_Title {
            get {
                return ResourceManager.GetString("VSSDK008_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Limit use of synchronously blocking method calls such as JoinableTaskFactory.Run or Task.Result to public entrypoint members where you must be synchronous. Using it for internal members can needlessly add synchronous frames between asynchronous frames, leading to threadpool exhaustion..
        /// </summary>
        internal static string VSSDK009_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK009_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Implement internal logic asynchronously.
        /// </summary>
        internal static string VSSDK009_Title {
            get {
                return ResourceManager.GetString("VSSDK009_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rename to {0}.
        /// </summary>
        internal static string VSSDK010_CodeFix_Title {
            get {
                return ResourceManager.GetString("VSSDK010_CodeFix_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use &quot;Async&quot; suffix in names of Task-returning methods..
        /// </summary>
        internal static string VSSDK010_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK010_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Use &quot;Async&quot; suffix for async methods.
        /// </summary>
        internal static string VSSDK010_Title {
            get {
                return ResourceManager.GetString("VSSDK010_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid method overloads that assume TaskScheduler.Current. Use an overload that accepts a TaskScheduler and specify TaskScheduler.Default (or any other) explicitly..
        /// </summary>
        internal static string VSSDK011_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK011_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid method overloads that assume TaskScheduler.Current.
        /// </summary>
        internal static string VSSDK011_Title {
            get {
                return ResourceManager.GetString("VSSDK011_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide an instance of JoinableTaskFactory in this call (or another overload) to avoid deadlocks with the main thread..
        /// </summary>
        internal static string VSSDK012_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK012_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide JoinableTaskFactory where allowed.
        /// </summary>
        internal static string VSSDK012_Title {
            get {
                return ResourceManager.GetString("VSSDK012_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expose an async version of this method that does not synchronously block. Then simplify this method to call that async method within a JoinableTaskFactory.Run delegate..
        /// </summary>
        internal static string VSSDK013_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK013_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Offer async methods.
        /// </summary>
        internal static string VSSDK013_Title {
            get {
                return ResourceManager.GetString("VSSDK013_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Await JoinableTaskFactory.SwitchToMainThreadAsync() to switch to the UI thread instead of APIs that can deadlock or require specifying a priority..
        /// </summary>
        internal static string VSSDK014_MessageFormat {
            get {
                return ResourceManager.GetString("VSSDK014_MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Avoid legacy threading switching APIs.
        /// </summary>
        internal static string VSSDK014_Title {
            get {
                return ResourceManager.GetString("VSSDK014_Title", resourceCulture);
            }
        }
    }
}
