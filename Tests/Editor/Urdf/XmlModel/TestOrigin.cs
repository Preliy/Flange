// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestOrigin
    {
        private const string TEST_XML = "<origin rpy=\"0 0 0\" xyz=\"0.320 0 0\"/>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Origin));
            using var reader = new StringReader(TEST_XML);
            var origin = (Preliy.Flange.Editor.XmlModel.Origin)serializer.Deserialize(reader);
            
            Assert.IsNotNull(origin);
            Assert.AreEqual("0.320 0 0", origin.XYZ);
            Assert.AreEqual("0 0 0", origin.RPY);
        }
    }
}
