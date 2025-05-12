// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Preliy.Flange.Editor.XmlModel;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestGeometry
    {
        [Test]
        public void DeserializeMesh_Success()
        {
            var testXML = "<geometry>\n        <mesh filename=\"package://collision/base_link.stl\"/>\n      </geometry>";
            var serializer = new XmlSerializer(typeof(Geometry));
            using var reader = new StringReader(testXML);
            var geometry = (Geometry)serializer.Deserialize(reader);
            
            Assert.IsNotNull(geometry);
            Assert.IsNotNull(geometry.Object);
            Assert.IsInstanceOf(typeof(Mesh), geometry.Object);
        }
        
        [Test]
        public void DeserializeCylinder_Success()
        {
            var testXML = "<geometry>\n        <cylinder radius=\"1\" length=\"0.5\"/>\n      </geometry>";
            var serializer = new XmlSerializer(typeof(Geometry));
            using var reader = new StringReader(testXML);
            var geometry = (Geometry)serializer.Deserialize(reader);
            
            Assert.IsNotNull(geometry);
            Assert.IsNotNull(geometry.Object);
            Assert.IsInstanceOf(typeof(Cylinder), geometry.Object);
        }
        
        [Test]
        public void DeserializeBox_Success()
        {
            var testXML = "<geometry>\n        <box size=\"1 1 1\" />\n      </geometry>";
            var serializer = new XmlSerializer(typeof(Geometry));
            using var reader = new StringReader(testXML);
            var geometry = (Geometry)serializer.Deserialize(reader);
            
            Assert.IsNotNull(geometry);
            Assert.IsNotNull(geometry.Object);
            Assert.IsInstanceOf(typeof(Box), geometry.Object);
        }
        
        [Test]
        public void DeserializeSphere_Success()
        {
            var testXML = "<geometry>\n        <sphere radius=\"1\" />\n      </geometry>";
            var serializer = new XmlSerializer(typeof(Geometry));
            using var reader = new StringReader(testXML);
            var geometry = (Geometry)serializer.Deserialize(reader);
            
            Assert.IsNotNull(geometry);
            Assert.IsNotNull(geometry.Object);
            Assert.IsInstanceOf(typeof(Sphere), geometry.Object);
        }
    }
}
