namespace Application.Services.User.Dto
{
    public class OutputDtoAddUser
    {
        public int Id { get; set; } // le retour renvoie aussi l'id
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }
}