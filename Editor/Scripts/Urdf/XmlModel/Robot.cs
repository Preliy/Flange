// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="robot")]
    public class Robot 
    {
        [XmlAttribute(AttributeName="name")] 
        public string Name { get; set; } 

        [XmlAttribute(AttributeName="xacro")] 
        public string Xacro { get; set; } 
        
        [XmlElement(ElementName="link")] 
        public List<Link> Links { get; set; } 

        [XmlElement(ElementName="joint")] 
        public List<Joint> Joints { get; set; } 
    }
}
