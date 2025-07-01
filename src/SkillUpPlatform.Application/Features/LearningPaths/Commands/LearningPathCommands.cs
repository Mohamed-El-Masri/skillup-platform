using MediatR;
using SkillUpPlatform.Application.Common.Models;
using SkillUpPlatform.Domain.Entities;

namespace SkillUpPlatform.Application.Features.LearningPaths.Commands;

public class CreateLearningPathCommand : IRequest<Result<int>>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public int EstimatedDurationHours { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<string> Prerequisites { get; set; } = new();
    public List<string> LearningObjectives { get; set; } = new();
}

public class RecommendLearningPathCommand : IRequest<Result<List<int>>>
{
    public int UserId { get; set; }
    public List<string> Skills { get; set; } = new();
    public List<string> Interests { get; set; } = new();
    public string? CareerGoal { get; set; }
}

public class EnrollInLearningPathCommand : IRequest<Result<bool>>
{
    public int UserId { get; set; }
    public int LearningPathId { get; set; }
}
