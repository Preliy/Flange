using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestHomogeneousMatrix
    {
        private Matrix4x4 _base;
        private Matrix4x4 _joint;
        private Matrix4x4 _expectedMatrix;

        [Test]
        public void Create()
        {
            var gameObjectBase = new GameObject();
            var gameObjectJoint = new GameObject();
            gameObjectJoint.transform.parent = gameObjectBase.transform;

            var frameConfig = new FrameConfig(0, 0.1f, 1, Mathf.PI/2); 
            
            var position = new Vector3(-0.1f, 1, 0);
            var rotation = Quaternion.Euler(0, -90, 0); 
            
            gameObjectJoint.transform.SetLocalPositionAndRotation(position, rotation);

            _expectedMatrix = gameObjectJoint.transform.GetMatrixLocal();
            var result = HomogeneousMatrix.CreateRaw(frameConfig);

            AssertExtension.AssertEqualMatrix(result, _expectedMatrix);
        }
        
        [Test]
        public void CreateWithAngle()
        {
            var gameObjectBase = new GameObject();
            var gameObjectJoint = new GameObject();
            gameObjectJoint.transform.parent = gameObjectBase.transform;

            var frameConfig = new FrameConfig(0, 0.1f, 1, Mathf.PI/2); 
            
            var position = new Vector3(0, 1, -0.1f);
            var rotation = Quaternion.Euler(0, 180, 0); 
            
            gameObjectJoint.transform.SetLocalPositionAndRotation(position, rotation);

            _expectedMatrix = gameObjectJoint.transform.GetMatrixLocal();
            var result = HomogeneousMatrix.CreateRaw(frameConfig, 90f * Mathf.Deg2Rad);

            AssertExtension.AssertEqualMatrix(result, _expectedMatrix);
        }
        
        [Test]
        public void CreateWithDisplacement()
        {
            var gameObjectBase = new GameObject();
            var gameObjectJoint = new GameObject();
            gameObjectJoint.transform.parent = gameObjectBase.transform;

            var frameConfig = new FrameConfig(0, 0.1f, 1, Mathf.PI/2); 
            
            var position = new Vector3(-0.1f, 2, 0f);
            var rotation = Quaternion.Euler(0, -90, 0); 
            
            gameObjectJoint.transform.SetLocalPositionAndRotation(position, rotation);

            _expectedMatrix = gameObjectJoint.transform.GetMatrixLocal();
            var result = HomogeneousMatrix.CreateRaw(frameConfig, 0f, 1f);

            AssertExtension.AssertEqualMatrix(result, _expectedMatrix);
        }
        
        [Test]
        public void CreateWithAngleAndDisplacement()
        {
            var gameObjectBase = new GameObject();
            var gameObjectJoint = new GameObject();
            gameObjectJoint.transform.parent = gameObjectBase.transform;

            var frameConfig = new FrameConfig(0, 0.1f, 1, Mathf.PI/2); 
            
            var position = new Vector3(0, 2, -0.1f);
            var rotation = Quaternion.Euler(0, 180, 0);  
            
            gameObjectJoint.transform.SetLocalPositionAndRotation(position, rotation);

            _expectedMatrix = gameObjectJoint.transform.GetMatrixLocal();
            var result = HomogeneousMatrix.CreateRaw(frameConfig, 90f * Mathf.Deg2Rad, 1f);

            AssertExtension.AssertEqualMatrix(result, _expectedMatrix);
        }
    }
}
