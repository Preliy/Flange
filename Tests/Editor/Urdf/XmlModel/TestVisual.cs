// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at https://mozilla.org/MPL/2.0/.

using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;

namespace Preliy.Flange.Editor.Tests.Urdf.XmlModel
{
    public class TestVisual
    {
        private const string TEST_XML = "<visual name=\"visual\">\n      <origin rpy=\"0 0 0\" xyz=\"0 0 0\"/>\n      <geometry>\n        <mesh filename=\"package://robot_description/meshes/base_link.DAE\"/>\n      </geometry>\n  <material name=\"yellow\">\n        <color rgba=\"1 1 0 1\"/>\n      </material>  </visual>";
        
        [Test]
        public void Deserialize_Success()
        {
            var serializer = new XmlSerializer(typeof(Preliy.Flange.Editor.XmlModel.Visual));
            using var reader = new StringReader(TEST_XML);
            var visual = (Preliy.Flange.Editor.XmlModel.Visual)serializer.Deserialize(reader);
            
            Assert.IsNotNull(visual);
            Assert.AreEqual("visual", visual.Name);
            Assert.IsNotNull(visual.Geometry);
            Assert.IsNotNull(visual.Material);
            Assert.IsNotNull(visual.Origin);
        }
    }
}
