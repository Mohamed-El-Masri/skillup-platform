using MediatR;
using SkillUpPlatform.Application.Common.Models;
using SkillUpPlatform.Application.Features.Content.DTOs;

namespace SkillUpPlatform.Application.Features.Content.Queries;

public class GetContentQuery : IRequest<Result<List<ContentDto>>>
{
    public int? LearningPathId { get; set; }
}

public class GetContentByIdQuery : IRequest<Result<ContentDetailDto>>
{
    public int ContentId { get; set; }
    public int? UserId { get; set; }
}
