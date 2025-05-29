using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobotScara
    {
        private readonly RobotScara _prefab = Resources.Load<RobotScara>("TestScara");
        private RobotScara _robot;

        private readonly Matrix4x4 _pose = Matrix4x4.TRS(
            new Vector3(-0.00868241861f,0.0701999962f,0.541644275f),
            Quaternion.Euler(0,40.0000076f,0),
            Vector3.one
        );
        
        private JointTarget _jointTarget = new (10, 20, -0.15f, 30);

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
