using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Activity;
using Application.Services.Activity.Dto;
using Domain.Activity;
using Domain.Category;
using Domain.Unit;
using NSubstitute;
using NUnit.Framework;

namespace NUnitTestCases.Application
{
    [TestFixture]
    public class ActivityServiceTest
    {
        private static readonly IActivityRepository _activityRepository = Substitute.For<IActivityRepository>();
        private static readonly IUnitRepository _unitRepository = Substitute.For<IUnitRepository>();
        private static readonly ICategoryRepository _categoryRepository = Substitute.For<ICategoryRepository>();

        private readonly IActivityFactory _activityFactory = Substitute.For<IActivityFactory>();
        
        private readonly ActivityService _activityService = new ActivityService(_activityRepository,_unitRepository,_categoryRepository);


        public static IEnumerable<IActivity> getActivities()
        {
            Activity[] activities = new[] {new Activity("name",1,new Unit("type"), new Category("name"))};
            IEnumerable<Activity> list = activities;
            return list;
        }

        [Test]
        public void Query_NotNull()
        {
            _activityRepository.Query().Returns(getActivities());
            var res = _activityService.Query();
            Assert.NotNull(res);
        }
        
        [Test]
        public void Query_AreSame()
        {
            _activityRepository.Query().Returns(getActivities());
            var res = _activityService.Query();
            
            OutputDtoQueryActivity[] outputDtoQueryActivities = { new OutputDtoQueryActivity("name",1,"name","type") };
            IEnumerable<OutputDtoQueryActivity> expected = outputDtoQueryActivities;
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        public void Query_AreNotSame()
        {
            _activityRepository.Query().Returns(getActivities());
            var res = _activityService.Query();
            
            OutputDtoQueryActivity[] outputDtoQueryActivities = { new OutputDtoQueryActivity("otherName",1,"name","type") };
            IEnumerable<OutputDtoQueryActivity> expected = outputDtoQueryActivities;
            Assert.IsFalse(res.SequenceEqual(expected));
        }
        
        [Test]
        [TestCase(1)]
        public void GetByCategoryId_categoryId_NotNull(int categoryId)
        {
            _activityRepository
                .GetByCategoryId(categoryId).Returns(getActivities());

            var res = _activityService.GetByCategoryId(categoryId);

            Assert.NotNull(res);
        }
        
        [Test]
        [TestCase(1)]
        public void GetByCategoryId_categoryId_AreSame(int categoryId)
        {
            _activityRepository
                .GetByCategoryId(categoryId).Returns(getActivities());

            var expected = getActivities()
                .Select(activity => new OutputDtoQueryActivity
            {
                Id = activity.Id,
                Name = activity.Name,
                Repetitions = activity.Repetitions,
                CategoryName = activity.Category.Name,
                UnitType = activity.Unit.Type
            });

            var res = _activityService.GetByCategoryId(categoryId);
                
            Assert.IsTrue(res.SequenceEqual(expected));
        }
        
        [Test]
        [TestCase(1)]
        public void GetByCategoryId_categoryId_AreNotSame(int categoryId)
        {
            _activityRepository
                .GetByCategoryId(categoryId).Returns(getActivities());

            var expected = getActivities()
                .Select(activity => new OutputDtoQueryActivity
                {
                    Id = activity.Id,
                    Name = "other"+activity.Name,
                    Repetitions = activity.Repetitions,
                    CategoryName = activity.Category.Name,
                    UnitType = activity.Unit.Type
                });

            var res = _activityService.GetByCategoryId(categoryId);
                
            Assert.IsFalse(res.SequenceEqual(expected));
        }

        [Test]
        public void Create_inputDtoAddActivity_AreSame()
        {
            var input = new InputDtoAddActivity("name",1,1,1);
            var unit = new Unit("type");
            unit.Id = 1;
            var category = new Category("name");
            category.Id = 1;

            var activityFromDto = new Activity(input.Name, input.Repetitions, unit, category);
            var activityInDb = new Activity(input.Name, input.Repetitions, unit, category);
            activityInDb.Id = 1;
            
            _activityFactory.CreateFromValues(input.Name, input.Repetitions, unit, category)
                .Returns(activityFromDto);
            _unitRepository.GetById(input.UnitId).Returns(unit);
            _categoryRepository.GetById(input.CategoryId).Returns(category);
            _activityRepository.Create(activityFromDto).Returns(activityInDb);//ok

            OutputDtoAddActivity expected = new OutputDtoAddActivity
            {
                Id = activityInDb.Id,
                CategoryName = activityInDb.Category.Name,
                Name = activityInDb.Name,
                Repetitions = activityInDb.Repetitions,
                UnitType = activityInDb.Unit.Type
            };

            var res = _activityService.Create(input);
            
            Assert.AreEqual(expected,res);
        }
        
        [Test]
        public void Create_inputDtoAddActivity_AreNotSame()
        {
            var input = new InputDtoAddActivity("name",1,1,1);
            var unit = new Unit("type");
            unit.Id = 1;
            var category = new Category("name");
            category.Id = 1;

            var activityFromDto = new Activity(input.Name, input.Repetitions, unit, category);
            var activityInDb = new Activity(input.Name, input.Repetitions, unit, category);
            activityInDb.Id = 1;
            
            _activityFactory.CreateFromValues(input.Name, input.Repetitions, unit, category)
                .Returns(activityFromDto);
            _unitRepository.GetById(input.UnitId).Returns(unit);
            _categoryRepository.GetById(input.CategoryId).Returns(category);
            _activityRepository.Create(activityFromDto).Returns(activityInDb);
            
            OutputDtoAddActivity expected = new OutputDtoAddActivity(1,"other"+input.Name, input.Repetitions,category.Name,unit.Type);

            var res = _activityService.Create(input);
            
            Assert.AreNotEqual(expected,res);
        }

        [Test]
        [TestCase(1)]
        public void Update_IdInputDtoUpdateActivity_AreSame(int id)
        {
            var inputUpdate= new InputDtoUpdateActivity("name",1,1,1);

            var unit = new Unit("type");
            unit.Id = 1;
            var category = new Category("name");
            category.Id = 1;

            _unitRepository.GetById(1).Returns(unit);
            _categoryRepository.GetById(1).Returns(category);
            _activityFactory.CreateFromValues(inputUpdate.Name, inputUpdate.Repetitions,unit, category)
                .Returns(new Activity("name",1,unit,category));

            var categoryUpdated =
                _activityFactory.CreateFromValues(inputUpdate.Name, inputUpdate.Repetitions, unit, category);
            
            _activityRepository.Update(id, categoryUpdated).Returns(true);
            
            var res = _activityService.Update(1,inputUpdate);
            
            Assert.IsTrue(res);
        }
        
        [Test]
        [TestCase(1)]
        public void DeleteActivity_id(int id)
        {
            _activityRepository.Delete(1).Returns(true);

            var res = _activityService.DeleteActivity(1);
            Assert.IsTrue(res);
        }
        
    }
}