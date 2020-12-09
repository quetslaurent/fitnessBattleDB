using Domain.Category;
using NUnit.Framework;

namespace NUnitTestCases.Domain
{
    [TestFixture]
    public class CategoryFactoryTest
    {
        private CategoryFactory _categoryFactory = new CategoryFactory();

        
        [Test]
        [TestCase("name")]
        public void CreateFromName_Name_CategoryNotNull(string name)
        {
            var res = _categoryFactory.CreateFromName(name);
            Assert.IsNotNull(res);
        }
        
        [Test]
        [TestCase("name")]
        public void CreateFromName_Name_CategoryAreEquals(string name)
        {
            var res = _categoryFactory.CreateFromName(name);
            ICategory expected = new Category(name);
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        [TestCase("name")]
        public void CreateFromName_Name_CategoryAreNotEquals(string name)
        {
            var res = _categoryFactory.CreateFromName(name);
            ICategory expected = new Category("otherName");
            Assert.AreNotEqual(expected,res);
        }
    }
}