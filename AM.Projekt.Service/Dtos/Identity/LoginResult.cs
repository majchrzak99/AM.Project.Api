using System.Collections.Generic;

namespace AM.Projekt.Service.Dtos.Identity
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool Succeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}