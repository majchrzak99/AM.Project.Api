using System.Collections.Generic;

namespace AM.Projekt.Web.DataContracts.Responses.Authorization
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Succeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}