using MonitoNet.Backend.Iam.Domain.Model.Aggregates;
using MonitoNet.Backend.Iam.Domain.Model.Commands;

namespace MonitoNet.Backend.Iam.Application.CommandServices;

public interface IAuthenticationCommandService
{
    Task<User> SignUpAsync(SignUpCommand command);
    Task<User?> SignInAsync(SignInCommand command);
    Task<string> SignOutAsync();
}
