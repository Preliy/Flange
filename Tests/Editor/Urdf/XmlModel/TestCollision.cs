// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestCollision
    {
        private const string TEST_XML = "<collision name=\"collision\">\n      <origin rpy=\"0 0 0\" xyz=\"-0.065 0 0.0\"/>\n      <geometry>\n        <mesh filename=\"package://robot_description/meshes/base_link_simple.DAE\"/>\n      </geometry>\n    </collision>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Collision));
            using var reader = new StringReader(TEST_XML);
            var collision = (Preliy.Flange.Editor.XmlModel.Collision)serializer.Deserialize(reader);
            
            Assert.IsNotNull(collision);
            Assert.AreEqual("collision", collision.Name);
            Assert.IsNotNull(collision.Geometry);
            Assert.IsNotNull(collision.Origin);
        }
    }
}
