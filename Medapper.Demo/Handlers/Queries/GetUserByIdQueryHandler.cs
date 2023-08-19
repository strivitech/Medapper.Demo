using Medapper.Demo.Contracts.Requests;
using Medapper.Demo.Contracts.Responses;
using Medapper.Demo.Repositories;
using MediatR;

namespace Medapper.Demo.Handlers.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdRequest, GetUserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id, cancellationToken);
        return new GetUserResponse
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}