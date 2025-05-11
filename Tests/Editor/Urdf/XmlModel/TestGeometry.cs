// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestGeometry
    {
        private const string TEST_XML = "<geometry>\n        <mesh filename=\"package://collision/base_link.stl\"/>\n      </geometry>";
        
        [Test]
        public void Deserialize_XmlToMeshObject_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Geometry));
            using var reader = new StringReader(TEST_XML);
            var geometry = (Preliy.Flange.Editor.XmlModel.Geometry)serializer.Deserialize(reader);
            
            Assert.IsNotNull(geometry);
            Assert.IsNotNull(geometry.Mesh);
            Assert.AreEqual(geometry.Mesh.FileName, "package://collision/base_link.stl");
        }
    }
}
