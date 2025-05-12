// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestChild
    {
        private const string TEST_XML = "<child link=\"link_2\"/>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Child));
            using var reader = new StringReader(TEST_XML);
            var child = (Preliy.Flange.Editor.XmlModel.Child)serializer.Deserialize(reader);
            
            Assert.IsNotNull(child);
            Assert.AreEqual("link_2", child.Link);
        }
    }
}
