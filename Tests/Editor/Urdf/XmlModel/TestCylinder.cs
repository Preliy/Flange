// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestBox
    {
        private const string TEST_XML = "<box size=\"1 1 1\" />\n";

        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Box));
            using var reader = new StringReader(TEST_XML);
            var box = (Preliy.Flange.Editor.XmlModel.Box)serializer.Deserialize(reader);
            
            Assert.IsNotNull(box);
            Assert.AreEqual("1 1 1", box.Size);
        }
    }
}
