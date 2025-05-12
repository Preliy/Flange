// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestMimic
    {
        private const string TEST_XML = "<mimic joint=\"joint_2\" multiplier=\"-1.25\" offset=\"1.25\"/>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Mimic));
            using var reader = new StringReader(TEST_XML);
            var mimic = (Preliy.Flange.Editor.XmlModel.Mimic)serializer.Deserialize(reader);
            
            Assert.IsNotNull(mimic);
            Assert.AreEqual("joint_2", mimic.Joint);
            Assert.AreEqual(mimic.Multiplier, -1.25);
            Assert.AreEqual(mimic.Offset, 1.25);
        }
    }
}
