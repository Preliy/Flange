// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestSphere
    {
        private const string TEST_XML = "<sphere radius=\"1\" />";

        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Sphere));
            using var reader = new StringReader(TEST_XML);
            var sphere = (Preliy.Flange.Editor.XmlModel.Sphere)serializer.Deserialize(reader);
            
            Assert.IsNotNull(sphere);
            Assert.AreEqual(1, sphere.Radius);
        }
    }
}
