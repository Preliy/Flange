// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestLimit
    {
        private const string TEST_XML = "<limit effort=\"0\" lower=\"-1.134\" upper=\"1.4855\" velocity=\"1.5707\"/>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Limit));
            using var reader = new StringReader(TEST_XML);
            var limit = (Preliy.Flange.Editor.XmlModel.Limit)serializer.Deserialize(reader);
            
            Assert.IsNotNull(limit);
            Assert.AreEqual(0, limit.Effort);
            Assert.AreEqual(-1.134, limit.Lower);
            Assert.AreEqual(1.4855, limit.Upper);
            Assert.AreEqual(1.5707, limit.Velocity);
        }
    }
}
