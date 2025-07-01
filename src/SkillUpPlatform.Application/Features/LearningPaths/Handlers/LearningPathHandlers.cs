using MediatR;
using SkillUpPlatform.Application.Common.Constants;
using SkillUpPlatform.Application.Common.Models;
using SkillUpPlatform.Application.Features.LearningPaths.Commands;
using SkillUpPlatform.Application.Features.LearningPaths.DTOs;
using SkillUpPlatform.Application.Features.LearningPaths.Queries;
using SkillUpPlatform.Domain.Entities;
using SkillUpPlatform.Domain.Interfaces;
using AutoMapper;

namespace SkillUpPlatform.Application.Features.LearningPaths.Handlers;

public class CreateLearningPathCommandHandler : IRequestHandler<CreateLearningPathCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateLearningPathCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLearningPathCommand request, CancellationToken cancellationToken)
    {
        var learningPath = new LearningPath
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            EstimatedDurationHours = request.EstimatedDurationHours,
            DifficultyLevel = request.DifficultyLevel,
            Category = request.Category,
            Prerequisites = System.Text.Json.JsonSerializer.Serialize(request.Prerequisites),
            LearningObjectives = System.Text.Json.JsonSerializer.Serialize(request.LearningObjectives),
            IsActive = true,
            DisplayOrder = 0
        };

        await _unitOfWork.LearningPaths.AddAsync(learningPath);
        await _unitOfWork.SaveChangesAsync();

        return Result<int>.Success(learningPath.Id);
    }
}

public class GetLearningPathsQueryHandler : IRequestHandler<GetLearningPathsQuery, Result<List<LearningPathDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLearningPathsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<List<LearningPathDto>>> Handle(GetLearningPathsQuery request, CancellationToken cancellationToken)
    {
        var learningPaths = await _unitOfWork.LearningPaths.GetActiveLearningPathsAsync();

        // Apply filters
        if (!string.IsNullOrEmpty(request.Category))
        {
            learningPaths = learningPaths.Where(lp => lp.Category.Equals(request.Category, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(request.DifficultyLevel) && Enum.TryParse<DifficultyLevel>(request.DifficultyLevel, out var difficulty))
        {
            learningPaths = learningPaths.Where(lp => lp.DifficultyLevel == difficulty);
        }

        var learningPathDtos = _mapper.Map<List<LearningPathDto>>(learningPaths.ToList());
        return Result<List<LearningPathDto>>.Success(learningPathDtos);
    }
}

public class GetLearningPathByIdQueryHandler : IRequestHandler<GetLearningPathByIdQuery, Result<LearningPathDetailDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLearningPathByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<LearningPathDetailDto>> Handle(GetLearningPathByIdQuery request, CancellationToken cancellationToken)
    {
        var learningPath = await _unitOfWork.LearningPaths.GetLearningPathWithContentsAsync(request.LearningPathId);

        if (learningPath == null)
        {
            return Result<LearningPathDetailDto>.Failure(ErrorMessages.LearningPathNotFound);
        }

        var learningPathDto = _mapper.Map<LearningPathDetailDto>(learningPath);
        return Result<LearningPathDetailDto>.Success(learningPathDto);
    }
}

public class EnrollInLearningPathCommandHandler : IRequestHandler<EnrollInLearningPathCommand, Result<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public EnrollInLearningPathCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(EnrollInLearningPathCommand request, CancellationToken cancellationToken)
    {
        // Check if user exists
        var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
        if (user == null)
        {
            return Result<bool>.Failure(ErrorMessages.UserNotFound);
        }

        // Check if learning path exists
        var learningPath = await _unitOfWork.LearningPaths.GetByIdAsync(request.LearningPathId);
        if (learningPath == null)
        {
            return Result<bool>.Failure(ErrorMessages.LearningPathNotFound);
        }

        // Check if already enrolled
        var existingEnrollment = await _unitOfWork.UserLearningPaths.SingleOrDefaultAsync(
            ulp => ulp.UserId == request.UserId && ulp.LearningPathId == request.LearningPathId);

        if (existingEnrollment != null)
        {
            return Result<bool>.Failure("Already enrolled in this learning path");
        }

        // Create enrollment
        var userLearningPath = new UserLearningPath
        {
            UserId = request.UserId,
            LearningPathId = request.LearningPathId,
            EnrolledAt = DateTime.UtcNow,
            Status = LearningPathStatus.NotStarted,
            ProgressPercentage = 0
        };

        await _unitOfWork.UserLearningPaths.AddAsync(userLearningPath);
        await _unitOfWork.SaveChangesAsync();

        return Result<bool>.Success(true);
    }
}
