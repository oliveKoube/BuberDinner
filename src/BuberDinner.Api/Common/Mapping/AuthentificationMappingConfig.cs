using BuberDinner.Api.Login;
using BuberDinner.Api.Register;
using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Login;
using BuberDinner.Application.Authentification.Register;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthentificationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthentificationResult, RegisterResponse>()
            .Map(dest => dest, src => src.User.Email);
        config.NewConfig<AuthentificationResult, LoginResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}
