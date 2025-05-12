// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.ComponentModel;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="axis")]
    public class Axis 
    {
        [XmlAttribute(AttributeName="xyz")] 
        // ReSharper disable once InconsistentNaming
        public string XYZ { get; set; } 
    }
}
