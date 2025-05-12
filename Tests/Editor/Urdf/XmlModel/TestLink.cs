// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestLink
    {
        private const string TEST_XML = "<link name=\"base_link\">\n    <collision name=\"collision\">\n      <geometry>\n        <mesh filename=\"package://collision/base_link.stl\"/>\n      </geometry>\n    </collision>\n    <visual name=\"visual\">\n      <geometry>\n        <mesh filename=\"package://visual/base_link.dae\"/>\n      </geometry>\n      <material name=\"yellow\">\n        <color rgba=\"1 1 0 1\"/>\n      </material>\n    </visual>\n  </link>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Link));
            using var reader = new StringReader(TEST_XML);
            var link = (Preliy.Flange.Editor.XmlModel.Link)serializer.Deserialize(reader);
            
            Assert.IsNotNull(link);
            Assert.AreEqual("base_link", link.Name);
            Assert.IsNotNull(link.Collision);
            Assert.IsNotNull(link.Visual);
        }
    }
}
