using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.AI.Commands;
using SkillUpPlatform.Application.Features.AI.Queries;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AIAssistantController : BaseController
{
    public AIAssistantController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("chat")]
    public async Task<IActionResult> ChatWithAssistant([FromBody] ChatWithAssistantCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost("analyze-skills")]
    public async Task<IActionResult> AnalyzeSkills([FromBody] AnalyzeSkillsCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost("recommend-career")]
    public async Task<IActionResult> RecommendCareer([FromBody] RecommendCareerCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("user/{userId}/progress")]
    public async Task<IActionResult> GetUserProgress([FromRoute] int userId)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost("generate-cv")]
    public async Task<IActionResult> GenerateCV([FromBody] GenerateCVCommand command)
    {
        // Implementation will be added later
        return Ok();
    }
}
