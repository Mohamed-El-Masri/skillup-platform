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
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLearningPath([FromRoute] int id)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost("recommend")]
    public async Task<IActionResult> RecommendLearningPath([FromBody] RecommendLearningPathCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost("{id}/enroll")]
    public async Task<IActionResult> EnrollInLearningPath([FromRoute] int id)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserLearningPaths([FromRoute] int userId)
    {
        // Implementation will be added later
        return Ok();
    }
}
