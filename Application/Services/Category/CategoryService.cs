using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Activity.Dto;
using Application.Services.Category.Dto;
using Application.Services.TrainingDate.Dto;
using Domain.Category;

namespace Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        //repository et factory
        private readonly ICategoryRepository _categoryRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryFactory _categoryFactory = new CategoryFactory();

        //constructeur
        public CategoryService(ICategoryRepository categoryRepository,IActivityRepository activityRepository)
        {
            _categoryRepository = categoryRepository;
            _activityRepository = activityRepository;
        }

        public IEnumerable<OutputDtoQueryCategory> Query()
        {
            /*
             * On récupère les categories pour les renvoyer
             * en format DTO
             */
            return _categoryRepository
                .Query()
                .Select(category => new OutputDtoQueryCategory
                {
                    Id = category.Id,
                    Name = category.Name
                });
        }

        public OutputDtoAddCategory Create(InputDtoAddCategory inputDtoAddCategory)
        {
            //DTO --> Domain
            var categoryFromDto = _categoryFactory.CreateFromName(inputDtoAddCategory.Name);
            //Repository demande un element du domain

            var categoriesInDb = _categoryRepository.Query();

            foreach (var category in categoriesInDb)
            {
                if(category.Name==categoryFromDto.Name)
                    throw new Exception("Category already in database");
            }
            //On crée la catégorie
            var categoryInDb = _categoryRepository.Create(categoryFromDto);
            
            //Domain -> DTO
            return new OutputDtoAddCategory
            {
                Id = categoryInDb.Id,
                Name = categoryInDb.Name
            };
        }

        public IEnumerable<OutputDtoQueryActivitiesByCategory> getActivitiesByCategory()
        {
            /*
             * On récupère les categories pour les renvoyer
             * en format DTO
             */
            return _categoryRepository
                .Query()
                .Select(category => new OutputDtoQueryActivitiesByCategory
                {
                    Id = category.Id,
                    Name = category.Name,
                    Activities = _activityRepository.GetByCategoryId(category.Id)
                });
        }
    }
}