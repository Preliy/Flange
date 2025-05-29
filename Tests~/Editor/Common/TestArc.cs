using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools.Utils;

namespace Preliy.Flange.Editor.Tests
{
    public class TestArc
    {
        private Vector3 _startPoint;
        private Vector3 _endPoint;
        private Vector3 _wayPoint;
        private Arc _arc;
        private Vector3EqualityComparer _comparer;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _startPoint = Vector3.zero;
            _endPoint = new Vector3(0, 0, 1);
            _wayPoint = new Vector3(0, 1, 0.5f);
            _arc = new Arc(_startPoint, _endPoint, _wayPoint);
            _comparer = new Vector3EqualityComparer(1e-6f);
        }
        
        [Test]
        public void GetStartPoint()
        {
            var expected = _startPoint;
            var actual = _arc.GetPoint(0);
            
            Assert.That(actual, Is.EqualTo(expected).Using(_comparer));
        }
        
        [Test]
        public void GetEndPoint()
        {
            var expected = _endPoint;
            var actual = _arc.GetPoint(1);
            
            Assert.That(actual, Is.EqualTo(expected).Using(_comparer));
        }
        
        [Test]
        public void GetWayPoint()
        {
            var expected = _wayPoint;
            var actual = _arc.GetPoint(0.5f);
            
            Assert.That(actual, Is.EqualTo(expected).Using(_comparer));
        }
    }
}
