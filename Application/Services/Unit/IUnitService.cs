using System.Collections.Generic;
using Application.Services.TrainingDate.Dto;
using Application.Services.Unit.Dto;

namespace Application.Services.Unit
{
    public interface IUnitService
    {
        IEnumerable<OutputDtoQueryUnit> Query();
        OutputDtoAddUnit Create(InputDtoAddUnit inputDtaAddUnit);
    }

   
}