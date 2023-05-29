using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentification.Commands.Register;

public class RegisterCommandHandler : 
    IRequestHandler<RegisterCommand,ErrorOr<AuthentificationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthentificationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        //1.Validate the user exists
        if(_userRepository.getUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
        //2.Create user (generate unique id)
        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
        
        _userRepository.Add(user);
        
        //3.Create the token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthentificationResult(user,token);
    }
}