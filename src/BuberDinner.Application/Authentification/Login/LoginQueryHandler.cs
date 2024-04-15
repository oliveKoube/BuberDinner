using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Messaging;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;

namespace BuberDinner.Application.Authentification.Login;

internal sealed class LoginQueryHandler :
    IQueryHandler<LoginQuery,AuthentificationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthentificationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        //1. Validate the user exists
        if(await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) is not User user)
        {
            return AuthentificationErrors.InvalidCreadentials;
        }

        //2. Validate the password is correct
        if (user.Password != request.Password)
        {
            return AuthentificationErrors.InvalidCreadentials;
        }
        //3.Create the token
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthentificationResult(user,token);
    }
}
