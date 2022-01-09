using System.Collections;
using System.Collections.Generic;

namespace AM.Projekt.Service.Dtos.Identity
{
    public class RegisterResult
    {
        public bool Succeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}