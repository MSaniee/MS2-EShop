﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace MS2EShop.Common.Resources
{
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Memos
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Memos()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MS2EShop.Common.Resources.Memos", typeof(Memos).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to کدملی وارد شده صحیح نیست.
        /// </summary>
        public static string InvalidNationalIdEntered
        {
            get
            {
                return ResourceManager.GetString("InvalidNationalIdEntered", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to شماره تلفن همراه وارد شده صحیح نیست.
        /// </summary>
        public static string InvalidPhoneNumberEntered
        {
            get
            {
                return ResourceManager.GetString("InvalidPhoneNumberEntered", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to نام کاربری وارد شده صحیح نیست.
        /// </summary>
        public static string InvalidUserNameEntered
        {
            get
            {
                return ResourceManager.GetString("InvalidUserNameEntered", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to کاربر مورد نظر یافت نشد.
        /// </summary>
        public static string UserNotFound
        {
            get
            {
                return ResourceManager.GetString("UserNotFound", resourceCulture);
            }
        }
    }
}
