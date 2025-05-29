using NUnit.Framework;
using UnityEngine;

namespace Preliy.Flange.Editor.Tests
{
    public class TestTool
    {
        private Tool _tool;
        private GameObject _point;
        private readonly Matrix4x4 _expected = Matrix4x4.TRS(new Vector3(0.1f, 0.2f, 0.3f), Quaternion.Euler(10, 22, 33), Vector3.one);

        [SetUp]
        public void SetUp()
        {
            var toolGameObject = new GameObject();
            _tool = toolGameObject.AddComponent<Tool>();
            _point = new GameObject();
        }

        [Test]
        public void GetNullOffset()
        {
            _tool.Point = null;
            var actual = _tool.Offset;
            
            AssertExtension.AssertEqualMatrix(actual, Matrix4x4.identity);
        }
        
        [Test]
        public void GetOffset()
        {
            _point.transform.parent = _tool.transform;
            _point.transform.SetLocalMatrix(_expected);
            
            _tool.Point = _point.transform;
            
            AssertExtension.AssertEqualMatrix(_tool.GetOffset(), _expected);
        }
    }
}
