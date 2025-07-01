using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }    protected int GetUserIdFromContext()
    {
        if (HttpContext.Items.TryGetValue("UserId", out var userIdObj) && userIdObj is int userId)
        {
            return userId;
        }
        return 0;
    }

    protected int GetCurrentUserId()
    {
        return GetUserIdFromContext();
    }
}
