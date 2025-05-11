// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

namespace Preliy.Flange.Editor.XmlModel
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Pose 
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("0 0 0")]
        public string XYZ 
        {
            get => _xyz;
            set => _xyz = value;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("0 0 0")]
        public string RPY 
        {
            get => _rpy;
            set => _rpy = value;
        }
        
        private string _xyz = "0 0 0";
        private string _rpy = "0 0 0";
    }
}
