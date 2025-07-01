using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Resources.Commands;
using SkillUpPlatform.Application.Features.Resources.Queries;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResourcesController : BaseController
{
    public ResourcesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("cv-templates")]
    public async Task<IActionResult> GetCVTemplates()
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("cover-letter-templates")]
    public async Task<IActionResult> GetCoverLetterTemplates()
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("interview-questions")]
    public async Task<IActionResult> GetInterviewQuestions()
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("interview-questions/{category}")]
    public async Task<IActionResult> GetInterviewQuestionsByCategory([FromRoute] string category)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateResource([FromBody] CreateResourceCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResource([FromRoute] int id, [FromBody] UpdateResourceCommand command)
    {
        // Implementation will be added later
        return Ok();
    }
}
