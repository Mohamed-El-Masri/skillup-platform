using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Contentt.Commands;
using SkillUpPlatform.Application.Features.Contentt.Queries;
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
        var result = await _mediator.Send(new GetContentQuery());
        if (!result.IsSuccess)
            return BadRequest(result.Error);

        return Ok(result.Data);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContentById([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetContentByIdQuery { ContentId = id });
        if (!result.IsSuccess)
            return NotFound(result.Error);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContent([FromBody] CreateContentCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { ContentId = result.Data, Message = "Content created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContent([FromRoute] int id, [FromBody] UpdateContentCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { Message = "Content updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContent([FromRoute] int id)
    {
        var command = new DeleteContentCommand { Id = id };
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(new { Message = "Content deleted successfully" });
    }

    [HttpGet("learning-path/{learningPathId}")]
    public async Task<IActionResult> GetContentByLearningPath([FromRoute] int learningPathId)
    {
        var query = new GetContentByLearningPathQuery { LearningPathId = learningPathId };
        var result = await _mediator.Send(query);

        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(result.Data);
    }

}
