// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="geometry")]
    public class Geometry 
    { 
        [XmlElement("mesh", typeof(Mesh), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] 
        [XmlElement("box", typeof(Box), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] 
        [XmlElement("cylinder", typeof(Cylinder), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] 
        [XmlElement("sphere", typeof(Sphere), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] 
        public object Object { get; set; } 
    }
}
