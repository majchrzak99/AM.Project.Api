namespace AM.Projekt.Web.DataContracts.Requests.Authorization
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
    }
}