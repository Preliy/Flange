// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    [XmlRoot(ElementName="limit")]
    public class Limit 
    {
        [XmlAttribute(AttributeName="effort")] 
        public double Effort { get; set; } 

        [XmlAttribute(AttributeName="lower")] 
        public double Lower { get; set; } 

        [XmlAttribute(AttributeName="upper")] 
        public double Upper { get; set; } 

        [XmlAttribute(AttributeName="velocity")] 
        public double Velocity { get; set; } 
    }
}
