using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Category.Dto;
using Application.Services.TrainingDate.Dto;
using Domain.Category;

namespace Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        //repository et factory
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory = new CategoryFactory();

        //constructeur
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            var categoryInDb = _categoryRepository.Create(categoryFromDto);
            
            //Domain -> DTO
            return new OutputDtoAddCategory
            {
                Id = categoryInDb.Id,
                Name = categoryInDb.Name
            };
        }
    }
}