using Medapper.Demo.Contracts.Responses;
using MediatR;

namespace Medapper.Demo.Contracts.Requests;

public class GetUserByIdRequest : IRequest<GetUserResponse>
{
    public Guid Id { get; set; }
}