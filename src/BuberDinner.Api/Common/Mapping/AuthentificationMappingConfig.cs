using BuberDinner.Api.Controllers.Authentification;
using BuberDinner.Application.Authentification.Commands.Register;
using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Authentification.Queries.Login;

using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthentificationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthentificationResult, AuthentificationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);
    }
}