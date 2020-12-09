using Domain.Activity;
using Domain.Category;
using Domain.Unit;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class ActivityFactoryTest
    {
        private ActivityFactory _activityFactory = new ActivityFactory();
        private IUnit _unit = Substitute.For<IUnit>();
        private ICategory _category = Substitute.For<ICategory>();

        [Test]
        [TestCase("name", 1)]
        public void CreateFromValues_NameRepetitionsUnitCategory_ActivityIsNotNull(string name, double repetitions)
        {
            var res = _activityFactory.CreateFromValues(name, repetitions, _unit, _category);
            Assert.IsNotNull(res);
        }

        [Test]
        [TestCase("name",1)]
        public void CreateFromValues_NameRepetitionsUnitCategory_ActivityAreSame(string name, double repetitions)
        {
            var res = _activityFactory.CreateFromValues(name, repetitions, _unit, _category);
            IActivity expected = new Activity(name, repetitions, _unit, _category);
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        [TestCase("name",1)]
        public void CreateFromValues_NameRepetitionsUnitCategory_ActivityAreNotSame(string name, double repetitions)
        {
            var res = _activityFactory.CreateFromValues(name, repetitions, _unit, _category);
            IActivity expected = new Activity("otherName", repetitions, _unit, _category);
            Assert.AreNotEqual(expected,res);
        }
        
    }
}