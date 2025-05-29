using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobJoint
    {
        [Test]
        public void Initialisation()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60};

            var robJoint = new RobJoint(jointValue);

            for (var i = 0; i < RobJoint.LENGTH; i++)
            {
                Assert.AreEqual(jointValue[i], robJoint[i]);
            }
        }

        [Test]
        public void ValueWithIndex()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60};
            var robJoint = new RobJoint();
            
            for (var i = 0; i < RobJoint.LENGTH; i++)
            {
                robJoint[i] = jointValue[i];
                Assert.AreEqual(jointValue[i], robJoint[i]);
            }
        }

        [Test]
        public void Clone()
        {
            var jointValue = new float[] { 10, 20, 30, 40, 50, 60};
            var robJoint = new RobJoint(jointValue);
            var copy = robJoint with { Value = new float[] { 0, 0, 0, 0, 0, 0 }};
            
            for (var i = 0; i < RobJoint.LENGTH; i++)
            {
                Assert.AreEqual(jointValue[i], robJoint[i]);
            }
            
            for (var i = 0; i < RobJoint.LENGTH; i++)
            {
                Assert.AreEqual(0, copy[i], $"Copy Joint value at index {i} failed");
            }
        }

        [Test]
        public void CreateDefault()
        {
            var joint = RobJoint.Default;
            
            for (var i = 0; i < RobJoint.LENGTH; i++)
            {
                Assert.AreEqual(0, joint[i], $"Joint value at index {i} failed");
            }
        }
    }
}
