using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Activity.Dto;
using Domain.Activity;

namespace Application.Services.Activity
{
    public class ActivityService : IActivityService
    {
        /*
         * On récupère les repositories qu'on a besoin
         */
        private readonly IActivityRepository _activityRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly ICategoryRepository _categoryRepository;
        
        //on recupère la Factory
        private readonly IActivityFactory _activityFactory = new ActivityFactory();

        //Constructeur
        public ActivityService(IActivityRepository activityRepository, IUnitRepository unitRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _unitRepository = unitRepository;
            _categoryRepository = categoryRepository;
        }

        /*
         * Récupérer la liste des activités ayant une même categorie
         */
        public IEnumerable<OutputDtoQueryActivity> GetByCategory(int categoryId)
        {
           return _activityRepository
               .GetByCategoryId(categoryId)
               .Select(activity => new OutputDtoQueryActivity
                   {
                       Id = activity.Id,
                       Name = activity.Name,
                       Repetitions = activity.Repetitions,
                       CategoryName = activity.Category.Name,
                       UnitType = activity.Unit.Type
                   });
        }

        /*
         * Créer une activité
         */
        public OutputDtoAddActivity Create(InputDtoAddActivity inputDtoAddActivity)
        {
            var unit = _unitRepository.GetById(inputDtoAddActivity.UnitId);
            var category = _categoryRepository.GetById(inputDtoAddActivity.CategoryId);

            
            var activityFromDto = _activityFactory.CreateFromValues(inputDtoAddActivity.Name,
                inputDtoAddActivity.Repetitions, unit, category);
            var activityInDb = _activityRepository.Create(activityFromDto);

            return new OutputDtoAddActivity
            {
                Id = activityInDb.Id,
                CategoryName = activityInDb.Category.Name,
                Name = activityInDb.Name,
                Repetitions = activityInDb.Repetitions,
                UnitType = activityInDb.Unit.Type
            };
        }
        
        /*
         * Modifier une activité
         */
        public bool Update(InputDtoAddActivity inputDtoAddActivity)
        {
            var unit = _unitRepository.GetById(inputDtoAddActivity.UnitId);
            var category = _categoryRepository.GetById(inputDtoAddActivity.CategoryId);
            
            var activityFromDto = _activityFactory.CreateFromValues(inputDtoAddActivity.Name,
                inputDtoAddActivity.Repetitions, unit, category);
            return _activityRepository.Update(activityFromDto.Id,activityFromDto);
        }

        /*
         * Supprimer une activité
         */
        public bool DeleteActivity(int activityId)
        {
           return _activityRepository.Delete(activityId);
        }
    }
}