// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestMesh
    {
        private const string TEST_XML = "<mesh filename=\"package://collision/base_link.stl\"/>";

        [Test]
        public void Deserialize_XmlToMeshObject_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Mesh));
            using var reader = new StringReader(TEST_XML);
            var mesh = (Preliy.Flange.Editor.XmlModel.Mesh)serializer.Deserialize(reader);
            
            Assert.IsNotNull(mesh);
            Assert.AreEqual(mesh.FileName, "package://collision/base_link.stl");
        }
    }
}
