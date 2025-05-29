using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestJointConfig
    {
        [Test]
        public void Initialisation()
        {
            var expectedType = TransformJoint.JointType.Rotation;
            var expectedLimits = new Vector2(-180, 180);
            var expectedOffset = 0f;
            var expectedFactor = 1f;
            var expectedSpeedMax = 100f;
            var expectedAccMax = 500f;
            
            var config = new JointConfig(
                expectedType, 
                expectedLimits, 
                expectedOffset, 
                expectedFactor, 
                expectedSpeedMax,
                expectedAccMax);
            
            Assert.AreEqual(expectedType, config.Type, "Type value isn't correct!");
            Assert.AreEqual(expectedLimits, config.Limits, "Limits value isn't correct!");
            Assert.AreEqual(expectedOffset, config.Offset, "Offset value isn't correct!");
            Assert.AreEqual(expectedFactor, config.Factor, "Factor value isn't correct!");
            Assert.AreEqual(expectedSpeedMax, config.SpeedMax, "SpeedMax value isn't correct!");
            Assert.AreEqual(expectedAccMax, config.AccMax, "AccMax value isn't correct!");
        }
        
        [TestCase(1f, 0f, 10f,ExpectedResult = 1f)]
        [TestCase(-1f, 0f, 10f,ExpectedResult = 0f)]
        [TestCase(11f, 0f, 10f,ExpectedResult = 10f)]
        public float GetValidValueLimits(float value, float min, float max)
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(min, max), 
                0, 
                1, 
                100,
                500);


            return config.GetValidValue(value);
        }
        
        [TestCase(1f, 0f, ExpectedResult = 1f)]
        [TestCase(1f, 1f, ExpectedResult = 2f)]
        [TestCase(1f, -1f, ExpectedResult = 0f)]
        public float GetValidValueOffset(float value, float offset)
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-Mathf.Infinity, Mathf.Infinity), 
                offset, 
                1, 
                100,
                500);


            return config.GetValidValue(value);
        }
        
        [TestCase(1f, 0f, ExpectedResult = 0f)]
        [TestCase(1f, 1f, ExpectedResult = 1f)]
        [TestCase(1f, 2f, ExpectedResult = 2f)]
        [TestCase(1f, -1f, ExpectedResult = -1f)]
        public float GetValidValueFactor(float value, float factor)
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-Mathf.Infinity, Mathf.Infinity), 
                0, 
                factor, 
                100,
                500);


            return config.GetValidValue(value);
        }
    }
}
