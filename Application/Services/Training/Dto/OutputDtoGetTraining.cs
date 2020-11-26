using System;

namespace Application.Services.Training.Dto
{
    public class OutputDtoGetTraining
    {
        /*
     * DTO qui permets d’ajouter un nouveau Training,
     * cela permets de recevoir les éléments sans l’id pour créer un training,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
        public int Id { get; set; }
        public double Repetitions { get; set; }
        public string ActivityName { get; set; }
        public DateTime TrainingDateValue { get; set; }
        
        public double Points { get; set; }
    }
}