using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools.Utils;

namespace Preliy.Flange.Editor.Tests
{
    public static class AssertExtension
    {
        public static void AssertEqualMatrix(Matrix4x4 actual, Matrix4x4 expected, float allowedError = 1e-6f, string message = null)
        {
            var positionEqualityComparer = new Vector3EqualityComparer(allowedError);
            var rotationEqualityComparer = new QuaternionEqualityComparer(allowedError);
            Assert.That(actual.GetPosition(), Is.EqualTo(expected.GetPosition()).Using(positionEqualityComparer), $"{message} \nMatrix position:");
            Assert.That(actual.rotation, Is.EqualTo(expected.rotation).Using(rotationEqualityComparer), $"{message} \nMatrix rotation:");
        }

        public static void AssertEqualArray(float[] actual, float[] expected, float allowedError = 1e-6f, string message = null)
        {
            if (actual.Length != expected.Length) throw new ArgumentOutOfRangeException(nameof(actual));

            for (var i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(actual[i], expected[i], allowedError, $"{message} \nValue on index {i} over threshold:");
            }
        }
    }
}
