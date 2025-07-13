using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.LearningPaths.Commands;
using SkillUpPlatform.Application.Features.LearningPaths.Queries;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LearningPathsController : BaseController
{
    public LearningPathsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetLearningPaths()
    {
        var query = new GetLearningPathsQuery(); // Create the query object
        var result = await _mediator.Send(query); // Send it via MediatR

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLearningPath([FromRoute] int id)
    {
        var query = new GetLearningPathByIdQuery { LearningPathId = id };
        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(result.Data);
    }

    [HttpPost("recommend")]
    public async Task<IActionResult> RecommendLearningPath([FromBody] RecommendLearningPathCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }

    [HttpPost("{id}/enroll")]
    public async Task<IActionResult> EnrollInLearningPath([FromRoute] int id)
    {
        var command = new EnrollInLearningPathCommand
        {
            UserId = GetCurrentUserId(),
            LearningPathId = id
        };

        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { Message = "User enrolled in learning path successfully" });
    
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserLearningPaths([FromRoute] int userId)
    {
        if (userId != GetCurrentUserId())
            return Forbid("Access denied");

        var query = new GetUserLearningPathsQuery { UserId = userId };
        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }
}
