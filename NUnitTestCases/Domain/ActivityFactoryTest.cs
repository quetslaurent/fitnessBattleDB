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
        private ICategory _category = Substitute.For<ICategory>()
            
    }
}