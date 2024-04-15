using BuberDinner.Application.Authentification.Common;
using BuberDinner.Application.Common.Interfaces.Authentification;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Messaging;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;
using ErrorOr;

namespace BuberDinner.Application.Authentification.Register;

internal sealed class RegisterCommandHandler :
    ICommandHandler<RegisterCommand,AuthentificationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<ErrorOr<AuthentificationResult>> Handle(RegisterCommand request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //1.Validate the user exists
        if(await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) is not null)
        {
            return UserErrors.DuplicateEmail;
        }
        //2.Create user (generate unique id)
        var user = User.Create(request.FirstName, request.LastName, request.Email, request.Password);

        _userRepository.Add(user);

        //3.Create the token
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthentificationResult(user,token);
    }
}
