using System.Collections.Generic;

namespace AM.Projekt.Web.DataContracts.Responses.Authorization
{
    public class RegisterResponse
    {
        public bool Succeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}