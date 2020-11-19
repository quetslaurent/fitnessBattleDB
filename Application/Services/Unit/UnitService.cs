using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Category.Dto;
using Application.Services.TrainingDate.Dto;
using Application.Services.Unit.Dto;
using Domain.Category;
using Domain.Unit;

namespace Application.Services.Category
{
    public class UnitService : IUnitService
    {
        //repository et factory
        private readonly IUnitRepository _unitRepository;
        private readonly IUnitFactory _unitFactory = new UnitFactory();

        //constructeur
        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public OutputDtoAddUnit Create(InputDtoAddUnit inputDtoAddUnit)
        {
            //DTO --> Domain
            var unitFromDto = _unitFactory.CreateFromType(inputDtoAddUnit.Type);
            //Repository demande un element du domain
            var unitInDb = _unitRepository.Create(unitFromDto);
            
            //Domain -> DTO
            return new OutputDtoAddUnit
            {
                Id = unitInDb.Id,
                Type = unitInDb.Type
            };
        }
    }
}