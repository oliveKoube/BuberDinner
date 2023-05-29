using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentification.Queries.Login;

public class LoginQueryHandler : 
    IRequestHandler<LoginQuery,ErrorOr<AuthentificationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthentificationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        //1. Validate the user exists
        if(_userRepository.getUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentification.InvalidCreadentials;
        }
        //2. Validate the password is correct
        if (user.Password != query.Password)
        {
            return Errors.Authentification.InvalidCreadentials;
        }
        //3.Create the token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthentificationResult(user,token);
    }
}