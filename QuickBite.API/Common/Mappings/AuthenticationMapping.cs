using Mapster;
using MapsterMapper;
using QuickBite.Application.Features.Authentication.CommonDTOs;
using QuickBite.Contracts.Authentication;

namespace QuickBite.Common.Mappings;

public class AuthenticationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
    }
}