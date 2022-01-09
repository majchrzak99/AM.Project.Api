using AM.Projekt.Service.Dtos.Identity;
using AM.Projekt.Web.DataContracts.Requests.Authorization;
using Mapster;

namespace AM.Projekt.Web.Mappings.Identity
{
    public class RegisterInputMappingConfig :IMappingConfig
    {
        public void CreateMap(TypeAdapterConfig config)
        {
            config.ForType<RegisterRequest, RegisterInput>().Map(x => x.UserName, x => x.Email);
        }
    }
}