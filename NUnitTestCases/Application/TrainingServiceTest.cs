using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Training;
using Application.Services.Training.Dto;
using Domain.Activity;
using Domain.Category;
using Domain.Training;
using Domain.TrainingDate;
using Domain.Unit;
using Domain.User;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class TrainingServiceTest
    {
        private static IActivityRepository _activityRepository = Substitute.For<IActivityRepository>();
        private static IUserRepository _userRepository= Substitute.For<IUserRepository>();
        private static ITrainingDateRepository _trainingDateRepository= Substitute.For<ITrainingDateRepository>();
        private static ITrainingRepository _trainingRepository= Substitute.For<ITrainingRepository>();
        private static ITrainingFactory _trainingFactory = Substitute.For<ITrainingFactory>();
        
        private TrainingService _trainingService = new TrainingService(_activityRepository,_userRepository,_trainingDateRepository,_trainingRepository);

        private static IEnumerable<ITraining> getDateList()
        {
            ITraining[] trainings = { new Training(new User(), 20,new Activity("activity",20,new Unit(),new Category()),new TrainingDate(new DateTime(2000,10,10))) };
            IEnumerable <ITraining> list= trainings;
            return list;
        }
        
        //GetByTrainingDateId
        
        [Test]
        [TestCase(1)]
        public void GetByTrainingDateId_dateId_NotNull(int dateId)
        {
            _trainingRepository.GetByDateId(dateId).Returns( getDateList());

            IEnumerable<OutputDtoGetTraining> res = _trainingService.GetByTrainingDateId(dateId);
            
            Assert.NotNull(res);
        }
        
        [Test]
        [TestCase(1)]
        public void GetByTrainingDateId_dateId_ListsAreSame(int dateId)
        {
            _trainingRepository.GetByDateId(dateId).Returns( getDateList());

            IEnumerable<OutputDtoGetTraining> res = _trainingService.GetByTrainingDateId(dateId);
            
            OutputDtoGetTraining[] outputDtoGetTrainings = {new OutputDtoGetTraining(20,"activity",new DateTime(2000,10,10),0 )};
            IEnumerable<OutputDtoGetTraining> expected = outputDtoGetTrainings;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        //GetByTrainingUserId
        
        [Test]
        [TestCase(1)]
        public void GetByTrainingUserId_userId_NotNull(int userId)
        {
            _trainingRepository.GetByUserId(userId).Returns( getDateList());

            IEnumerable<OutputDtoGetTraining> res = _trainingService.GetByTrainingUserId(userId);
            
            Assert.NotNull(res);
        }
        
        [Test]
        [TestCase(1)]
        public void GetByTrainingUserId_userId_ListsAreSame(int userId)
        {
            _trainingRepository.GetByUserId(userId).Returns( getDateList());

            IEnumerable<OutputDtoGetTraining> res = _trainingService.GetByTrainingUserId(userId);
            
            OutputDtoGetTraining[] outputDtoGetTrainings = {new OutputDtoGetTraining(20,"activity",new DateTime(2000,10,10),0 )};
            IEnumerable<OutputDtoGetTraining> expected = outputDtoGetTrainings;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        //Create
        
        [Test]
        public void Create_inputDtoAddTraining_AreSame()
        {
            var inputDtoAddTraining = new InputDtoAddTraining(20,1,1,1);
            inputDtoAddTraining.UserId = 1;

            _userRepository.GetById(1).Returns(new User("name","password","email@gmail.com","role"));
            _activityRepository.GetById(1).Returns(new Activity("name",20,new Unit("km"),new Category()));
            _trainingDateRepository.GetById(1).Returns(new TrainingDate(new DateTime(20)));

            var activity = _activityRepository.GetById(1);
            activity.Id = 1;
            var user = _userRepository.GetById(1);
            user.Id = 1;
            var date =_trainingDateRepository.GetById(1);
            date.Id = 1;

            _trainingFactory
                .CreateTrainingFromValues(inputDtoAddTraining.Repetitions, user,activity,date)
                .Returns(new Training(user,20,activity,date));

            _trainingRepository.Create(_trainingFactory.CreateTrainingFromValues(inputDtoAddTraining.Repetitions, user,activity,date))
                .Returns(new Training(user,20,activity,date));
            
            var res = _trainingService.Create(inputDtoAddTraining);
            
            var expected = new OutputDtoAddTraining(1,inputDtoAddTraining.Repetitions,"name",new DateTime(20));

            Assert.AreEqual(expected, res);
        }
        
        
        //DELETE

        [Test]
        public void DeleteTraining_isDeleted()
        {
            _trainingRepository.Delete(1).Returns(true);

            var res = _trainingService.DeleteTraining(1);
            Assert.IsTrue(res);
        }
        
        
        
    }
}