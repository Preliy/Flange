using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobot3DDelta
    {
        private readonly Robot3DDelta _prefab = Resources.Load<Robot3DDelta>("Test3DDelta");
        private Robot3DDelta _robot;

        private readonly Matrix4x4 _pose = Matrix4x4.TRS(
            new Vector3(0.0509335622f,-1.05529034f,-0.0854802877f),
            Quaternion.Euler(0, 0, 0),
            Vector3.one
        );
        
        private JointTarget _jointTarget = new (10, 20, 30);

        [SetUp]
        public void SetUp()
        {
            _robot = Object.Instantiate(_prefab);
        }

        [Test]
        public void ComputeForward()
        {
            _robot.JointValue = _jointTarget;

            var actual = _robot.ComputeForward();

            AssertExtension.AssertEqualMatrix(actual, _pose);
        }

        [Test]
        public void ComputeForwardNumerical()
        {
            var actual = _robot.ComputeForward(_jointTarget.RobJoint.Value);

            AssertExtension.AssertEqualMatrix(actual, _pose);
        }

        [Test]
        public void ComputeInverse()
        {
           var solution = _robot.ComputeInverse(_pose, Configuration.Default, SolutionIgnoreMask.All);
           
           AssertExtension.AssertEqualArray(_jointTarget.RobJoint.Value, solution.JointTarget.RobJoint.Value, 1e-1f);
        }

        [Test]
        public void ComputeInverseList()
        {
            var solutions = _robot.ComputeInverse(_pose, false, SolutionIgnoreMask.All);
            
            Assert.AreEqual(1, solutions.Count);
        }
    }
}
