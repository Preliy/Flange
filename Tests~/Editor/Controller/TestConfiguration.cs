using NUnit.Framework;

namespace Preliy.Flange.Editor.Tests
{
    public class TestConfiguration
    {
        [Test]
        public void Initialisation()
        {
            var expectedTurn1 = 1;
            var expectedTurn4 = 2;
            var expectedTurn6 = 3;
            var expectedIndex = 4;

            var configuration = new Configuration(expectedTurn1, expectedTurn4, expectedTurn6, expectedIndex);

            Assert.AreEqual(expectedTurn1, configuration.Turn1, "Turn1 value isn't correct!");
            Assert.AreEqual(expectedTurn4, configuration.Turn4, "Turn4 value isn't correct!");
            Assert.AreEqual(expectedTurn6, configuration.Turn6, "Turn6 value isn't correct!");
            Assert.AreEqual(expectedIndex, configuration.Index, "Index value isn't correct!");
        }
        
        [Test]
        public void InitialisationJoints()
        {
            var expectedTurn1 = 2;
            var expectedTurn4 = 2;
            var expectedTurn6 = 3;
            var expectedIndex = 4;

            var jointTarget = new JointTarget(expectedTurn1 * 360, 0, 0 ,expectedTurn4 * 360, 0, expectedTurn6 * 360);

            var configuration = new Configuration(jointTarget, expectedIndex);

            Assert.AreEqual(expectedTurn1, configuration.Turn1, "Turn1 value isn't correct!");
            Assert.AreEqual(expectedTurn4, configuration.Turn4, "Turn4 value isn't correct!");
            Assert.AreEqual(expectedTurn6, configuration.Turn6, "Turn6 value isn't correct!");
            Assert.AreEqual(expectedIndex, configuration.Index, "Index value isn't correct!");
        }

        [Test]
        public void Compare()
        {
            var config1 = new Configuration(1, 2, 3, 4);
            var config2 = new Configuration(1, 2, 3, 4);
            var config3 = new Configuration(4, 3, 2, 1);

            Assert.True(config1 == config2);
            Assert.True(config1 != config3);
        }
    }
}
