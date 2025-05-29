using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestJointTarget
    {
        [Test]
        public void Create()
        {
            var value = new float[] { 10, 20, 30, 40, 50, 60, 10, 20, 30, 40, 50, 60 };

            var jointTarget = new JointTarget(value);
            
            for (var i = 0; i < ExtJoint.LENGTH; i++)
            {
                Assert.AreEqual(value[i], jointTarget[i]);
            }
        }
        
        [Test]
        public void CreateCombine()
        {
            var value = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var robJoint = new RobJoint(value[..6]);
            var extJoint = new ExtJoint(value[6..]);
            
            var jointTarget = new JointTarget(robJoint, extJoint);
            
            for (var i = 0; i < value.Length; i++)
            {
                Assert.AreEqual(value[i], jointTarget[i], $"Invalid valid on index {i}!");
            }
        }

        [Test]
        public void Clone()
        {
            var value = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            var jointTargetInit = new JointTarget(value);
            var jointTargetClone = jointTargetInit with { };

            jointTargetInit[0] = 0;
            
            Assert.AreNotEqual(jointTargetInit[0], jointTargetClone[0]);
        }
    }
}
