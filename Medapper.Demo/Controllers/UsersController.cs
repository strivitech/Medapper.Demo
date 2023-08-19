using Medapper.Demo.Contracts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Medapper.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _sender.Send(new GetUserByIdRequest {Id = id});
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateUserRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserRequest request)
    {
        await _sender.Send(request);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _sender.Send(new DeleteUserRequest {Id = id});
        return Ok();
    }
}