using System.ComponentModel.DataAnnotations;

namespace Application.Services.Activity.Dto
{
    /*
     * DTO qui permets de modifier une Activity
     * 
     */
    
    public class InputDtoUpdateActivity
    {
        public string Name { get; }
        [Required]
        [Range(0,99999)]
        public double Repetitions { get;}
        [Required]
        [Range(1,99999)]
        public int CategoryId { get; }
        [Required]
        [Range(1,99999)]
        public int UnitId { get;}

        public InputDtoUpdateActivity()
        {
        }
        public InputDtoUpdateActivity(string name, double repetitions, int categoryId, int unitId)
        {
            Name = name;
            Repetitions = repetitions;
            CategoryId = categoryId;
            UnitId = unitId;
        }
    }
}