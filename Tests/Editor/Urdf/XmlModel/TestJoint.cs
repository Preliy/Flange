// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Preliy.Flange.Editor.XmlModel;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestJoint
    {
        private const string TEST_XML = "<joint name=\"joint_1\" type=\"revolute\">\n    <origin rpy=\"0 0 0\" xyz=\"0 0 0.780\"/>\n    <axis xyz=\"0 0 1\"/>\n    <parent link=\"base_link\"/>\n    <child link=\"link_1\"/>\n    <limit effort=\"0\" lower=\"-2.967\" upper=\"2.967\" velocity=\"1.7453\"/>\n  </joint>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Joint));
            using var reader = new StringReader(TEST_XML);
            var joint = (Joint)serializer.Deserialize(reader);
            
            Assert.IsNotNull(joint);
            Assert.AreEqual("joint_1", joint.Name);
            Assert.AreEqual(joint.Type, JointType.Revolute);
            Assert.IsNotNull(joint.Origin);
            Assert.IsNotNull(joint.Axis);
            Assert.IsNotNull(joint.Parent);
            Assert.IsNotNull(joint.Child);
            Assert.IsNotNull(joint.Limit);
        }
    }
}
