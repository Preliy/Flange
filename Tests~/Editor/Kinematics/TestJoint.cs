using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestJoint
    {
        private Frame _frame;
        private TransformJoint _transformJoint;

        [SetUp]
        public void SetUp()
        {
            var frameConfig = new FrameConfig(0, 0.1f, 1, Mathf.PI/2); 
            var gameObject = new GameObject();
            _frame = gameObject.AddComponent<Frame>();
            _frame.Config = frameConfig;

            _transformJoint = gameObject.AddComponent<TransformJoint>();
        }
        
        [Test]
        public void PositionPropertySubscription()
        {
            var receivedValues = new List<float>();

            _transformJoint.Position.Subscribe(newValue => {
                receivedValues.Add(newValue);
            });

            _transformJoint.Position.Value = 1;
            _transformJoint.Position.Value = 2;
            _transformJoint.Position.Value = 3;
            _transformJoint.Position.Value = 4;

            Assert.AreEqual(5, receivedValues.Count, "Received value count is wrong");
        }

        [Test]
        public void Translate()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-180, 180), 
                0, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(-0.1f, 2, 0);
            var rotation = Quaternion.Euler(0, -90, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 1;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void TranslateLimited()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-1, 1f), 
                0, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(-0.1f, 2, 0);
            var rotation = Quaternion.Euler(0, -90, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 2;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void TranslateOffset()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-180, 180), 
                1, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(-0.1f, 3, 0);
            var rotation = Quaternion.Euler(0, -90, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 1;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void TranslateFactor()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Displacement, 
                new Vector2(-180, 180), 
                0, 
                2, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(-0.1f, 3, 0);
            var rotation = Quaternion.Euler(0, -90, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 1;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void Rotate()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Rotation, 
                new Vector2(-180, 180), 
                0, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(0, 1, -0.1f);
            var rotation = Quaternion.Euler(0, -180, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 90;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void RotateLimited()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Rotation, 
                new Vector2(-90, 90), 
                0, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(0, 1, -0.1f);
            var rotation = Quaternion.Euler(0, -180, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 180;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void RotateOffset()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Rotation, 
                new Vector2(-180, 180), 
                90, 
                1, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(0.1f, 1, 0f);
            var rotation = Quaternion.Euler(0, 90f, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 90;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
        
        [Test]
        public void RotateFactor()
        {
            var config = new JointConfig(
                TransformJoint.JointType.Rotation, 
                new Vector2(-180, 180), 
                0, 
                2, 
                100,
                500);

            _transformJoint.Config = config;
            
            var position = new Vector3(0.1f, 1, 0f);
            var rotation = Quaternion.Euler(0, 90f, 0);
            var expected = Matrix4x4.TRS(position, rotation, Vector3.one);

            _transformJoint.Position.Value = 90;
            
            AssertExtension.AssertEqualMatrix(_transformJoint.transform.GetMatrixLocal(), expected);
        }
    }
}
