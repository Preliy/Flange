using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestExtJoint
    {
        [Test]
        public void Initialisation()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60 };

            var extJoint = new ExtJoint(jointValue);

            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                Assert.AreEqual(jointValue[i], extJoint[i]);
            }
        }

        [Test]
        public void ValueWithIndex()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60 };
            var extJoint = new ExtJoint();
            
            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                extJoint[i] = jointValue[i];
                Assert.AreEqual(jointValue[i], extJoint[i]);
            }
        }

        [Test]
        public void Clone()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60 };
            var extJoint = new ExtJoint(jointValue);
            var copy = extJoint with { Value = new float[] { 0, 0, 0, 0, 0, 0 }};
            
            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                Assert.AreEqual(jointValue[i], extJoint[i]);
            }
            
            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                Assert.AreEqual(0, copy[i], $"Copy Joint value at index {i} failed");
            }
        }

        [Test]
        public void CreateDefault()
        {
            var extJoint = ExtJoint.Default;
            
            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                Assert.AreEqual(Math.FLOAT_MAX, extJoint[i]);
            }
        }
    }
}
