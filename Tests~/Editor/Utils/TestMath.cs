using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestMath
    {
        [TestCase(0,0, ExpectedResult = true)]
        [TestCase(1,1, ExpectedResult = true)]
        [TestCase(1e-3f,1e-3f, ExpectedResult = true)]
        [TestCase(1e-6f,1e-6f, ExpectedResult = true)]
        
        [TestCase(1,1 + 1e-7f, ExpectedResult = true)]
        [TestCase(1,1 + 1e-6f, ExpectedResult = true)]
        [TestCase(1,1 + 1e-5f, ExpectedResult = false)]
        public bool FastApproximately(float a, float b)
        {
            return Math.IsEqual(a, b);
        }

        [TestCase(1.22222222f,0, ExpectedResult = 1f)]
        [TestCase(1.22222222f,1, ExpectedResult = 1.2f)]
        [TestCase(1.22222222f,2, ExpectedResult = 1.22f)]
        [TestCase(1.22222222f,3, ExpectedResult = 1.222f)]
        [TestCase(1.22222222f,4, ExpectedResult = 1.2222f)]
        public float Round(float value, int digits)
        {
            return value.Round(digits);
        }

        [TestCase(0,90, ExpectedResult = 0)]
        [TestCase(89.99f,90, ExpectedResult = 0)]
        [TestCase(90,90, ExpectedResult = 1)]
        [TestCase(179.99f,90, ExpectedResult = 1)]
        [TestCase(180,90, ExpectedResult = 2)]
        
        [TestCase(-89.99f,90, ExpectedResult = -1)]
        [TestCase(-90,90, ExpectedResult = -2)]
        [TestCase(-179.99f,90, ExpectedResult = -2)]
        [TestCase(-180,90, ExpectedResult = -3)]
        public int GetQuadrant(float value, float interval)
        {
            return Math.GetQuadrant(value, interval);
        }

        [TestCase(0,0, ExpectedResult = 0)]
        [TestCase(0,1, ExpectedResult = 0)]
        [TestCase(0,2, ExpectedResult = 0)]
        [TestCase(0,3, ExpectedResult = 0)]
        [TestCase(0,4, ExpectedResult = 360)]
        [TestCase(0,8, ExpectedResult = 720)]
        [TestCase(0,-1, ExpectedResult = 0)]
        [TestCase(0,-2, ExpectedResult = 0)]
        [TestCase(0,-3, ExpectedResult = 0)]
        [TestCase(0,-4, ExpectedResult = -360)]
        [TestCase(0,-8, ExpectedResult = -720)]
        
        [TestCase(80,0, ExpectedResult = 80f)]
        [TestCase(80,4, ExpectedResult = 440f)]
        [TestCase(80,8, ExpectedResult = 800f)]
        [TestCase(80,-4, ExpectedResult = -280f)]
        [TestCase(80,-8, ExpectedResult = -640f)]
        
        [TestCase(-80,0, ExpectedResult = -80f)]
        [TestCase(-80,4, ExpectedResult = 280f)]
        [TestCase(-80,8, ExpectedResult = 640f)]
        [TestCase(-80,-5, ExpectedResult = -440f)]
        [TestCase(-80,-9, ExpectedResult = -800f)]
        public float ApplyQuadrant(float value, int targetQuadrant)
        {
            return value.ApplyQuadrant(targetQuadrant);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(360, ExpectedResult = 1)]
        [TestCase(720, ExpectedResult = 2)]
        [TestCase(-360, ExpectedResult = -1)]
        [TestCase(-720, ExpectedResult = -2)]
        public int GetTurn(float value)
        {
            return value.GetTurn();
        }
    }
}
