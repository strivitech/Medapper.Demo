using Medapper.Demo.Contracts.Requests;
using Medapper.Demo.Data;
using Medapper.Demo.Repositories;
using MediatR;

namespace Medapper.Demo.Handlers.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = request.Id,
            Name = request.Name
        };
        await _userRepository.UpdateAsync(user, cancellationToken);
    }
}