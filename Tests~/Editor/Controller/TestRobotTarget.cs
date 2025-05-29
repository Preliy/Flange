using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobotTarget
    {
        [Test]
        public void Create()
        {
            var pose = Matrix4x4.TRS(
                new Vector3(0.0509335622f,-1.05529034f,-0.0854802877f),
                Quaternion.Euler(0, 0, 0),
                Vector3.one
            );

            var extJoint = new ExtJoint(1, 2, 3, 4, 5, 6);
            var configuration = new Configuration();

            var robotTarget = new CartesianTarget(pose, configuration, extJoint);
            
            AssertExtension.AssertEqualMatrix(robotTarget.Pose, pose);
            Assert.AreEqual(extJoint, robotTarget.ExtJoint);
            Assert.AreEqual(configuration, robotTarget.Configuration);
        }
    }
}
