using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Category;
using Application.Services.Category.Dto;
using Domain.Category;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class CategoryServiceTest
    {
        private static ICategoryRepository _categoryRepository = Substitute.For<ICategoryRepository>();
        private static IActivityRepository _activityRepository = Substitute.For<IActivityRepository>();
        private ICategoryFactory  _categoryFactory = Substitute.For<ICategoryFactory>();
        private CategoryService _categoryService = new CategoryService(_categoryRepository, _activityRepository);

        private static IEnumerable<ICategory> getCategoryList()
        {
            Category[] categories = { new Category("Multi") };
            IEnumerable <ICategory> list= categories;
            return list;
        }
        
        //QUERY

        [Test]
        public void Query_NotNull()
        {
            _categoryRepository.Query().Returns(getCategoryList());
            var res = _categoryService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _categoryRepository.Query().Returns(getCategoryList());
            var res = _categoryService.Query();
            
            OutputDtoQueryCategory[] outputDtoQueryCategories = { new OutputDtoQueryCategory("Multi") };
            IEnumerable<OutputDtoQueryCategory> expected = outputDtoQueryCategories;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        public void Query_AreNotSame()
        {
            _categoryRepository.Query().Returns(getCategoryList());
            var res = _categoryService.Query();
            
            OutputDtoQueryCategory[] outputDtoQueryCategories = { new OutputDtoQueryCategory("not Multi") };
            IEnumerable<OutputDtoQueryCategory> expected = outputDtoQueryCategories;
            Assert.IsFalse(res.SequenceEqual(expected));
        }
        
        
        //CREATE

        [Test]
        public void Create_InputDtoAddCategory_AreSame()
        {
            
            var input= new InputDtoAddCategory("Cardio");
            _categoryFactory.CreateFromName(input.Name).Returns(new Category(input.Name));
            var icategory = _categoryFactory.CreateFromName(input.Name);
            _categoryRepository.Query().Returns(getCategoryList());
            _categoryRepository.Create(icategory).Returns(new Category(input.Name));
            
            var res = _categoryService.Create(input);
            
            var expected = new OutputDtoAddCategory("Cardio");

            Assert.AreEqual(expected, res);

        }
        
        
        //EXCEPTION already in DB
        
        [Test]
        public void Create_InputDtoAddCategory_ThrowsAlreadyInDBException()
        {
            var input= new InputDtoAddCategory("Multi");
            _categoryFactory.CreateFromName(input.Name).Returns(new Category(input.Name));
            _categoryRepository.Query().Returns(getCategoryList());
            
            var exception = Assert.Throws<Exception>(() => _categoryService.Create(input));
            Assert.AreEqual("Category already in database",exception.Message);
        }
    }
}