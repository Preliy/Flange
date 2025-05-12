// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using System.Xml.Serialization;

namespace Preliy.Flange.Editor.XmlModel
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    public enum JointType 
    {
        [XmlEnum(Name = "revolute")]
        Revolute,
        [XmlEnum(Name = "continuous")]
        Continuous,
        [XmlEnum(Name = "prismatic")]
        Prismatic,
        [XmlEnum(Name = "fixed")]
        Fixed,
        [XmlEnum(Name = "floating")]
        Floating,
        [XmlEnum(Name = "planar")]
        Planar,
    }
}
