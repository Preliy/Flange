using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobot6RSphericalWrist
    {
        private readonly Robot6RSphericalWrist _prefab = Resources.Load<Robot6RSphericalWrist>("Test6RSphericalWrist");
        private Robot6RSphericalWrist _robot;

        private readonly Matrix4x4 _pose = Matrix4x4.TRS(
            new Vector3(-0.381429225f, 0.614667535f, 1.52517414f),
            Quaternion.Euler(330.463531f, 259.448853f, 178.188049f),
            Vector3.one
        );
        
        private JointTarget _jointTarget = new (10, 20, 30, 40, 50, 60);

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
            
            Assert.AreEqual(2, solutions.Count);
        }
    }
}
