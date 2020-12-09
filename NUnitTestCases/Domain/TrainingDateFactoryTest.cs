using System;
using Domain.TrainingDate;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class TrainingDateFactoryTest
    {
        private TrainingDateFactory _trainingDateFactory = new TrainingDateFactory();

        [Test]
        [TestCase(1)]
        public void Create_IdDateTime_TrainingDateAreSame(int id)
        {
            DateTime date = new DateTime(2000,9,2);
            var res = _trainingDateFactory.Create(id, date);
            ITrainingDate trainingDate = new TrainingDate(id,date);
            Assert.AreEqual(trainingDate,res);
        }
        
        [Test]
        [TestCase(1)]
        public void Create_IdDateTime_TrainingDateNotSame(int id)
        {
            DateTime date = new DateTime(2000,9,2);

            var res = _trainingDateFactory.Create(id, date);
            ITrainingDate trainingDate = new TrainingDate(id,date.AddDays(10));
            Assert.AreNotEqual(trainingDate,res);
        }
        
        [Test]
        public void CreateFromDateTime_DateTime_TrainingDateSame()
        {
            DateTime date = new DateTime(2000,9,2);
            var res = _trainingDateFactory.CreateFromDateTime(date);
            ITrainingDate trainingDate = new TrainingDate(date);
            Assert.AreEqual(trainingDate,res);
        }
        
        [Test]
        public void CreateFromDateTime_DateTime_TrainingDateNotSame()
        {
            DateTime date = new DateTime(2000,9,2);
            var res = _trainingDateFactory.CreateFromDateTime(date);
            ITrainingDate trainingDate = new TrainingDate(date.AddDays(15));
            Assert.AreNotEqual(trainingDate,res);
        }
        
    }
}