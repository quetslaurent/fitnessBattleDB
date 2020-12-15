namespace Application.Services.Auth.Dto
{
    /*
     * Dto utilisé comme retour d'une méthode qui ne renvoie qu'un seul user authentifié
     */
    
    public class OutputDtoAuthUser
    {
        public string Token { get; set; }

        protected bool Equals(OutputDtoAuthUser other)
        {
            return Token == other.Token;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OutputDtoAuthUser) obj);
        }
    }
}