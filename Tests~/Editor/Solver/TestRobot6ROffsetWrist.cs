using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestRobot6ROffsetWrist
    {
        private readonly Robot6ROffsetWrist _prefab = Resources.Load<Robot6ROffsetWrist>("Test6ROffsetWrist");
        private Robot6ROffsetWrist _robot;

        private readonly Matrix4x4 _pose = Matrix4x4.TRS(
            new Vector3(0.260437816f,0.552915692f,0.68392092f),
            Quaternion.Euler(359.974579f,0.147604764f,269.621155f),
            Vector3.one
        );
        
        private JointTarget _jointTarget = new (152.729f, -72.787f, 101.398f, 152.22f, -152.87f, -179.23f);

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

            AssertExtension.AssertEqualMatrix(actual, _pose, 1e-3f);
        }

        [Test]
        public void ComputeForwardNumerical()
        {
            var actual = _robot.ComputeForward(_jointTarget.RobJoint.Value);

            AssertExtension.AssertEqualMatrix(actual, _pose, 1e-3f);
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
            
            Assert.AreEqual(8, solutions.Count);
        }
    }
}
