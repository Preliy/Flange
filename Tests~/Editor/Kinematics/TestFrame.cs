using UnityEngine;
using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestFrame
    {
        [Test]
        public void SetTransform()
        {
            var frameConfig = new FrameConfig(0, 0, 1, 0);
            var gameObject = new GameObject();
            var frame = gameObject.AddComponent<Frame>();
            frame.Config = frameConfig;
            
            var expected = Matrix4x4.TRS(new Vector3(0, 1, 0), Quaternion.identity, Vector3.one);
            AssertExtension.AssertEqualMatrix(frame.Transform.GetMatrix(), expected);
        }
    }
}
