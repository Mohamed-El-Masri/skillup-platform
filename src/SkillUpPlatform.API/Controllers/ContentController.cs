using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Content.Commands;
using SkillUpPlatform.Application.Features.Content.Queries;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ContentController : BaseController
{
    public ContentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetContent()
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContentById([FromRoute] int id)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateContent([FromBody] CreateContentCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContent([FromRoute] int id, [FromBody] UpdateContentCommand command)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContent([FromRoute] int id)
    {
        // Implementation will be added later
        return Ok();
    }

    [HttpGet("learning-path/{learningPathId}")]
    public async Task<IActionResult> GetContentByLearningPath([FromRoute] int learningPathId)
    {
        // Implementation will be added later
        return Ok();
    }
}
