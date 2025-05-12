// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestCylinder
    {
        private const string TEST_XML = "<cylinder radius=\"1\" length=\"0.5\"/>";

        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Cylinder));
            using var reader = new StringReader(TEST_XML);
            var cylinder = (Preliy.Flange.Editor.XmlModel.Cylinder)serializer.Deserialize(reader);
            
            Assert.IsNotNull(cylinder);
            Assert.AreEqual("1", cylinder.Radius);
            Assert.AreEqual("0.5", cylinder.Length);
        }
    }
}
