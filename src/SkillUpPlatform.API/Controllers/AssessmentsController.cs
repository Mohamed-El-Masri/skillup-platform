using Microsoft.AspNetCore.Mvc;
using SkillUpPlatform.Application.Features.Assessments.Commands;
using SkillUpPlatform.Application.Features.Assessments.Queries;
using SkillUpPlatform.Application.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace SkillUpPlatform.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class AssessmentsController : BaseController
{
    public AssessmentsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAssessments([FromQuery] string? category = null, [FromQuery] int? learningPathId = null)
    {
        var query = new GetAssessmentsQuery
        {
            Category = category,
            LearningPathId = learningPathId
        };

        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssessment([FromRoute] int id)
    {
        var query = new GetAssessmentByIdQuery { AssessmentId = id };
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return NotFound(new { Error = result.Error });

        return Ok(result.Data);
    }    [HttpPost]
    public async Task<IActionResult> CreateAssessment([FromBody] CreateAssessmentCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { AssessmentId = result.Data, Message = "Assessment created successfully" });
    }

    [HttpPost("{id}/submit")]
    public async Task<IActionResult> SubmitAssessment([FromRoute] int id, [FromBody] SubmitAssessmentCommand command)
    {
        command.AssessmentId = id;
        command.UserId = GetCurrentUserId();
        
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(new { AssessmentResultId = result.Data, Message = SuccessMessages.AssessmentSubmitted });
    }

    [HttpGet("user/{userId}/results")]
    public async Task<IActionResult> GetUserAssessmentResults([FromRoute] int userId)
    {
        // Only allow users to see their own results unless admin
        var currentUserId = GetCurrentUserId();
        if (currentUserId != userId)
        {
            return Forbid("Access denied");
        }

        var query = new GetUserAssessmentResultsQuery { UserId = userId };
        
        var result = await _mediator.Send(query);
        
        if (!result.IsSuccess)
            return BadRequest(new { Error = result.Error });

        return Ok(result.Data);
    }
}
