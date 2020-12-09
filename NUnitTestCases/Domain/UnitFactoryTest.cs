using Domain.Unit;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class UnitFactoryTest
    {
        private UnitFactory unitFactory = new UnitFactory();

        [Test]
        [TestCase("kilometer")]
        public void CreateFromType_Type_UnitAreSame(string type)
        {
            var res = unitFactory.CreateFromType(type);
            IUnit unit = new Unit(type);
            Assert.AreEqual(unit,res);
        }
        
        [Test]
        [TestCase("kilometer")]
        public void CreateFromType_Type_UnitNotSame(string type)
        {
            var res = unitFactory.CreateFromType(type);
            IUnit unit = new Unit("not kilometers");
            Assert.AreNotEqual(unit,res);
        }
    }
}