namespace Application.Services.Training.Dto
{
    public class InputDtoAddTraining
    {
        /*
     * DTO qui permets d’ajouter un nouveau Training,
     * cela permets de recevoir les éléments sans l’id pour créer un training,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
       
        public double Repetitions { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public int TrainingDateId { get; set; }
        
        public double Points { get; set; }
        
    }
}