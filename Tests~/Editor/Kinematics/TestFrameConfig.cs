using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestFrameConfig
    {
        [Test]
        public void Initialisation()
        {
            var expectedAlpha = 1;
            var expectedA = 2;
            var expectedD = 3;
            var expectedTheta = 4;
            var expectedName = "Test";
            
            var frameConfig = new FrameConfig(expectedAlpha, expectedA, expectedD, expectedTheta, expectedName);
            
            Assert.AreEqual(expectedAlpha, frameConfig.Alpha, "Alpha value isn't correct!");
            Assert.AreEqual(expectedA, frameConfig.A, "A value isn't correct!");
            Assert.AreEqual(expectedD, frameConfig.D, "D value isn't correct!");
            Assert.AreEqual(expectedTheta, frameConfig.Theta, "Theta value isn't correct!");
            Assert.AreEqual(expectedName, frameConfig.Name, "Name value isn't correct!");
        }
    }
}
