// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="joint")]
    public class Joint 
    {
        [XmlAttribute(AttributeName="name")] 
        public string Name { get; set; } 

        [XmlAttribute(AttributeName="type")] 
        public JointType Type { get; set; } 
        
        [XmlElement(ElementName="origin")] 
        public Origin Origin { get; set; } 

        [XmlElement(ElementName="axis")] 
        public Axis Axis { get; set; } 

        [XmlElement(ElementName="parent")] 
        public Parent Parent { get; set; } 

        [XmlElement(ElementName="child")] 
        public Child Child { get; set; } 

        [XmlElement(ElementName="limit")] 
        public Limit Limit { get; set; } 

        [XmlElement(ElementName="mimic")] 
        public Mimic Mimic { get; set; } 
    }
}
