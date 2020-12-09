using Domain.Activity;
using Domain.Training;
using Domain.Unit;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class TrainingFactoryTest
    {
        private TrainingFactory _trainingFactory = new TrainingFactory();
        private IUnit unit = Substitute.For<IUnit>();
        private IActivity activity = Substitute.For<IActivity>();

        [Test]
        public void CreateTrainingFromValues_AllValues_TrainingsAreSame()
        {
            double repetitions = 25;
            unit.Returns(new Unit("km"));
            activity.Returns(new Activity());

        }
    }
}