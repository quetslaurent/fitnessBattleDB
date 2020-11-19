using Application.Services.TrainingDate.Dto;
using Application.Services.Unit.Dto;

namespace Application.Services.Category
{
    public interface IUnitService
    {
        OutputDtoAddUnit Create(InputDtoAddUnit inputDtaAddUnit);
    }

   
}