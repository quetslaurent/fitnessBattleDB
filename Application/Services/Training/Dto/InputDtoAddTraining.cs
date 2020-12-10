using System.ComponentModel.DataAnnotations;

namespace Application.Services.Training.Dto
{
    public class InputDtoAddTraining
    {
        /*
     * DTO qui permets d’ajouter un nouveau Training,
     * cela permets de recevoir les éléments sans l’id pour créer un training,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
        [Required]
        [Range(0,99999)]
        public double Repetitions { get; set; }
        [Required]
        [Range(1,99999)]
        public int UserId { get; set; }
        [Required]
        [Range(1,99999)]
        public int ActivityId { get; set; }
        [Required]
        [Range(1,99999)]
        public int TrainingDateId { get; set; }


        public InputDtoAddTraining()
        {
        }

        public InputDtoAddTraining(double repetitions, int userId, int activityId, int trainingDateId)
        {
            Repetitions = repetitions;
            UserId = userId;
            ActivityId = activityId;
            TrainingDateId = trainingDateId;
        }
    }
}