using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories;
using Application.Services.Unit.Dto;
using Domain.Unit;

namespace Application.Services.Unit
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

        public IEnumerable<OutputDtoQueryUnit> Query()
        {
            return _unitRepository.Query().Select(unit => new OutputDtoQueryUnit
            {
                Id = unit.Id,
                Type = unit.Type
            });
        }

        public OutputDtoAddUnit Create(InputDtoAddUnit inputDtoAddUnit)
        {
            //DTO --> Domain
            var unitFromDto = _unitFactory.CreateFromType(inputDtoAddUnit.Type);
            //Repository demande un element du domain

            var unitsInDb = _unitRepository.Query();
            foreach (var unit in unitsInDb)
            {
                if (unit.Type == unitFromDto.Type)
                    throw new Exception("Unit already in database");
            }
            //On crée une unit dans la db
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