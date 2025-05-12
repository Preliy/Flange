// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="material")]
    public class Material 
    {
        [XmlAttribute(AttributeName="name")] 
        public string Name { get; set; } 
        
        [XmlElement(ElementName="color")] 
        public Color Color { get; set; } 
    }
}
