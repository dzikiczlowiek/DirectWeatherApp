﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DirectWeather.Tests.Core.Builders {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DirectWeather.Tests.Core.Builders.TestData", typeof(TestData).Assembly);
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
        ///   Looks up a localized string similar to {&quot;cod&quot;:&quot;&lt;COD_VARIABLE&gt;&quot;,&quot;message&quot;:&quot;&lt;MESSAGE_VARIABLE&gt;&quot;}.
        /// </summary>
        internal static string ValidErrorJsonData {
            get {
                return ResourceManager.GetString("ValidErrorJsonData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;coord&quot;:{&quot;lon&quot;:13.39,&quot;lat&quot;:52.52},&quot;weather&quot;:[{&quot;id&quot;:500,&quot;main&quot;:&quot;Rain&quot;,&quot;description&quot;:&quot;light rain&quot;,&quot;icon&quot;:&quot;10d&quot;}],&quot;base&quot;:&quot;stations&quot;,&quot;main&quot;:{&quot;temp&quot;:&lt;TEMP_VARIABLE&gt;,&quot;pressure&quot;:1018,&quot;humidity&quot;:&lt;HUMIDITY_VARIABLE&gt;,&quot;temp_min&quot;:13,&quot;temp_max&quot;:13},&quot;visibility&quot;:10000,&quot;wind&quot;:{&quot;speed&quot;:3.6,&quot;deg&quot;:270},&quot;clouds&quot;:{&quot;all&quot;:75},&quot;dt&quot;:&lt;TIMESTAMP_VARIABLE&gt;,&quot;sys&quot;:{&quot;type&quot;:1,&quot;id&quot;:4892,&quot;message&quot;:0.0038,&quot;country&quot;:&quot;DE&quot;,&quot;sunrise&quot;:1529808257,&quot;sunset&quot;:1529868819},&quot;id&quot;:2950159,&quot;name&quot;:&quot;Berlin&quot;,&quot;cod&quot;:&quot;&lt;COD_VARIABLE&gt;&quot;}.
        /// </summary>
        internal static string ValidSuccessJsonData {
            get {
                return ResourceManager.GetString("ValidSuccessJsonData", resourceCulture);
            }
        }
    }
}
