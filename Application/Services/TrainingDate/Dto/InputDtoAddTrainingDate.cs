using System;

namespace Application.Services.TrainingDate.Dto
{
    /*
     * DTO qui permets d’ajouter un nouveau Trainig,
     * cela permets de recevoir les éléments sans l’id pour créer un training,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
    public class InputDtoAddTrainingDate
    {
        public DateTime Date { get; set; }

        public InputDtoAddTrainingDate(DateTime date)
        {
            Date = date;
        }

        public InputDtoAddTrainingDate()
        {
        }
    }
}