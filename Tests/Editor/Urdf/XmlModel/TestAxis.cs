// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestAxis
    {
        private const string TEST_XML = "<axis xyz=\"0 1 0\"/>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Axis));
            using var reader = new StringReader(TEST_XML);
            var axis = (Preliy.Flange.Editor.XmlModel.Axis)serializer.Deserialize(reader);
            
            Assert.IsNotNull(axis);
            Assert.AreEqual("0 1 0", axis.XYZ);
        }
    }
}
