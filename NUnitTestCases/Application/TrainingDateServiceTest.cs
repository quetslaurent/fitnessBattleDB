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
        private static ITrainingDateRepository _trainingRepository = Substitute.For<ITrainingDateRepository>();
        private TrainingDateService _trainingDateService = new TrainingDateService(_trainingRepository);



        public static IEnumerable<ITrainingDate> GetDateList()
        {
            TrainingDate[] trainingDates = { new TrainingDate(new DateTime(2000,9,2)) };
            IEnumerable <ITrainingDate> list= trainingDates;
            return list;
        }
        
        [Test]
        public void Query_NotNull()
        {
            _trainingRepository.Query().Returns(GetDateList());
            var res = _trainingDateService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _trainingRepository.Query().Returns(GetDateList());
            var res = _trainingDateService.Query();
            
            OutputDtoQueryTrainingDate[] outputDtoQueryTrainingDates = { new OutputDtoQueryTrainingDate(new DateTime(2000,9,2)) };
            IEnumerable<OutputDtoQueryTrainingDate> expected = outputDtoQueryTrainingDates;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        
    }
}