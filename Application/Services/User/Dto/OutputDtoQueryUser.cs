namespace Application.Services.User.Dto
{
    public class OutputDtoQueryUser
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        
        public double Points { get; set; }
    }
}