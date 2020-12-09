using System;
using Domain.Activity;
using Domain.Training;
using Domain.TrainingDate;
using Domain.Unit;
using Domain.User;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class TrainingFactoryTest
    {
        private TrainingFactory _trainingFactory = new TrainingFactory();
        private IUser _user = Substitute.For<IUser>();
        private IActivity _activity = Substitute.For<IActivity>();
        private ITrainingDate _trainingDate = Substitute.For<ITrainingDate>();

        [Test]
        public void CreateTrainingFromValues_AllValues_TrainingsNotNull()
        {
            double repetitions = 25;
            
            ITraining res =_trainingFactory.CreateTrainingFromValues(repetitions, _user, _activity, _trainingDate);
            
            Assert.IsNotNull(res);
        }
        
        [Test]
        public void CreateTrainingFromValues_AllValues_TrainingsAreSame()
        {
            double repetitions = 25;
            
            ITraining res =_trainingFactory.CreateTrainingFromValues(repetitions, _user, _activity, _trainingDate);
            
            var expected = new Training(_user,repetitions,_activity,_trainingDate); 

            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void CreateTrainingFromValues_AllValues_TrainingsNotSame()
        {
            double repetitions = 25;
            
            ITraining res =_trainingFactory.CreateTrainingFromValues(repetitions, _user, _activity, _trainingDate);
            
            var expected = new Training(_user,repetitions+10,_activity,_trainingDate); 

            Assert.AreNotEqual(expected,res);
        }
    }
}