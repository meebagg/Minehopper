﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minehopper {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("Minehopper.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string WelcomeMessage {
            get {
                return ResourceManager.GetString("WelcomeMessage", resourceCulture);
            }
        }
        
        internal static string Instructions {
            get {
                return ResourceManager.GetString("Instructions", resourceCulture);
            }
        }
        
        internal static string InvalidKeyMessage {
            get {
                return ResourceManager.GetString("InvalidKeyMessage", resourceCulture);
            }
        }
        
        internal static string WonMessage {
            get {
                return ResourceManager.GetString("WonMessage", resourceCulture);
            }
        }
        
        internal static string MovedMessage {
            get {
                return ResourceManager.GetString("MovedMessage", resourceCulture);
            }
        }
        
        internal static string DeadMessage {
            get {
                return ResourceManager.GetString("DeadMessage", resourceCulture);
            }
        }
        
        internal static string BoomMessage {
            get {
                return ResourceManager.GetString("BoomMessage", resourceCulture);
            }
        }
        
        internal static string InvalidMoveMessage {
            get {
                return ResourceManager.GetString("InvalidMoveMessage", resourceCulture);
            }
        }
        
        internal static string MinesRemainingMessage {
            get {
                return ResourceManager.GetString("MinesRemainingMessage", resourceCulture);
            }
        }
        
        internal static string CurrentLocationMessage {
            get {
                return ResourceManager.GetString("CurrentLocationMessage", resourceCulture);
            }
        }
        
        internal static string HitMineAndWonMessage {
            get {
                return ResourceManager.GetString("HitMineAndWonMessage", resourceCulture);
            }
        }
    }
}