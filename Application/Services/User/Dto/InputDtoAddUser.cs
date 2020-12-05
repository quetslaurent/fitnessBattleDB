namespace Application.Services.User.Dto
{
    public class InputDtoAddUser
    {
        /*
     * DTO qui permets d’ajouter un nouveau User,
     * cela permets de recevoir les éléments sans l’id pour créer un user,
     * car l’utilisateur ne doit pas entrer l’id dans les données.
     */
        
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        // public bool Admin { get; set; }
        
    }
}