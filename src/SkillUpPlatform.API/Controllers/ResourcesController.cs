using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Resources.Commands;
using SkillUpPlatform.Application.Features.Resources.Queries;
using SkillUpPlatform.Application.Common.Models;
using MediatR;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ResourcesController : BaseController
{
    public ResourcesController(IMediator mediator) : base(mediator) { }

    [HttpGet("cv-templates")]
    public async Task<IActionResult> GetCVTemplates()
    {
        var result = await _mediator.Send(new GetCVTemplatesQuery());
        return HandleResult(result);
    }

    [HttpGet("cover-letter-templates")]
    public async Task<IActionResult> GetCoverLetterTemplates()
    {
        var result = await _mediator.Send(new GetCoverLetterTemplatesQuery());
        return HandleResult(result);
    }

    [HttpGet("interview-questions")]
    public async Task<IActionResult> GetInterviewQuestions()
    {
        var result = await _mediator.Send(new GetInterviewQuestionsQuery());
        return HandleResult(result);
    }

    [HttpGet("interview-questions/{category}")]
    public async Task<IActionResult> GetInterviewQuestionsByCategory([FromRoute] string category)
    {
        var result = await _mediator.Send(new GetInterviewQuestionsByCategoryQuery { Category = category });
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateResource([FromBody] CreateResourceCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResource([FromRoute] int id, [FromBody] UpdateResourceCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }
}
