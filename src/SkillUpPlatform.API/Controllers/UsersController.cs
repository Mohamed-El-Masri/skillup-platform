using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Users.Commands;
using SkillUpPlatform.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using SkillUpPlatform.Application.Common.Constants;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { UserId = result.Data, Message = SuccessMessages.UserCreated });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { Token = result.Data, Message = SuccessMessages.LoginSuccessful });
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetUser([FromRoute] int id)
    {
        var query = new GetUserByIdQuery { UserId = id };
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(result.Data);
    }    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> GetUserProfile()
    {
        var userId = GetUserIdFromContext();
        if (userId == 0)
            return Unauthorized();
        
        var query = new GetUserProfileQuery { UserId = userId };
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(result.Data);
    }

    [HttpPut("profile")]
    [Authorize]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileCommand command)
    {
        var userId = GetUserIdFromContext();
        if (userId == 0)
            return Unauthorized();
            
        command.UserId = userId;
        
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { Message = SuccessMessages.UserUpdated });
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery query)
    {
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }
}
