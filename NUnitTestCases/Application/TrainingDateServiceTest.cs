using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.TrainingDate;
using Application.Services.TrainingDate.Dto;
using Domain.TrainingDate;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class TrainingDateServiceTest
    {
        private static ITrainingDateRepository _trainingDateRepository = Substitute.For<ITrainingDateRepository>();
        private TrainingDateService _trainingDateService = new TrainingDateService(_trainingDateRepository);



        public static IEnumerable<ITrainingDate> GetDateList()
        {
            TrainingDate[] trainingDates = { new TrainingDate(new DateTime(2000,9,2)) };
            IEnumerable <ITrainingDate> list= trainingDates;
            return list;
        }
        
        //QUERY
        
        [Test]
        public void Query_NotNull()
        {
            _trainingDateRepository.Query().Returns(GetDateList());
            var res = _trainingDateService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _trainingDateRepository.Query().Returns(GetDateList());
            var res = _trainingDateService.Query();
            
            OutputDtoQueryTrainingDate[] outputDtoQueryTrainingDates = { new OutputDtoQueryTrainingDate(new DateTime(2000,9,2)) };
            IEnumerable<OutputDtoQueryTrainingDate> expected = outputDtoQueryTrainingDates;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        public void Query_NotSame()
        {
            _trainingDateRepository.Query().Returns(GetDateList());
            var res = _trainingDateService.Query();
            
            OutputDtoQueryTrainingDate[] outputDtoQueryTrainingDates = { new OutputDtoQueryTrainingDate(new DateTime(2020,10,2)) };
            IEnumerable<OutputDtoQueryTrainingDate> expected = outputDtoQueryTrainingDates;
            Assert.IsFalse(res.SequenceEqual(expected));
        }
        
        //CREATE
        [Test]
        public void Create_InputDtoAddTrainingDate_AreSame()
        {
            var input= new InputDtoAddTrainingDate(new DateTime(2021,12,2));
            
            _trainingDateRepository.Create(input.Date).Returns(new TrainingDate(input.Date));
            
            var res = _trainingDateService.Create(input);
            
            var expected = new OutputDtoAddTrainingDate(input.Date);

            Assert.AreEqual(expected, res);
        }
        
        
        //CREATE TODAY
        [Test]
        public void CreateToday_AreSame()
        {
            var res = _trainingDateService.CreateToday();
            var expected = new OutputDtoAddTrainingDate(res.Date);
            
            Assert.AreEqual(expected,res);
        }
        
    }
}