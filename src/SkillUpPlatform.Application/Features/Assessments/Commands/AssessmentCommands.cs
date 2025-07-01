using MediatR;
using SkillUpPlatform.Application.Common.Models;
using SkillUpPlatform.Domain.Entities;

namespace SkillUpPlatform.Application.Features.Assessments.Commands;

public class CreateAssessmentCommand : IRequest<Result<int>>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AssessmentType AssessmentType { get; set; }
    public int TimeLimit { get; set; }
    public int PassingScore { get; set; }
    public int? LearningPathId { get; set; }
    public List<CreateQuestionDto> Questions { get; set; } = new();
}

public class SubmitAssessmentCommand : IRequest<Result<int>>
{
    public int AssessmentId { get; set; }
    public int UserId { get; set; }
    public List<SubmitAnswerDto> Answers { get; set; } = new();
    public int TimeSpentMinutes { get; set; }
}

public class CreateQuestionDto
{
    public string QuestionText { get; set; } = string.Empty;
    public QuestionType QuestionType { get; set; }
    public List<string> Options { get; set; } = new();
    public string CorrectAnswer { get; set; } = string.Empty;
    public string? Explanation { get; set; }
    public int Points { get; set; } = 1;
}

public class SubmitAnswerDto
{
    public int QuestionId { get; set; }
    public string Answer { get; set; } = string.Empty;
}
