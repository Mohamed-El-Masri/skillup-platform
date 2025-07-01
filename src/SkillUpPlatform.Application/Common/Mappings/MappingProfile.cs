using AutoMapper;
using SkillUpPlatform.Application.Features.Users.DTOs;
using SkillUpPlatform.Application.Features.LearningPaths.DTOs;
using SkillUpPlatform.Application.Features.Assessments.DTOs;
using SkillUpPlatform.Application.Features.Content.DTOs;
using SkillUpPlatform.Application.Features.Resources.DTOs;
using SkillUpPlatform.Domain.Entities;
using System.Text.Json;

namespace SkillUpPlatform.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
          // Learning Path mappings
        CreateMap<LearningPath, LearningPathDto>()
            .ForMember(dest => dest.Prerequisites, opt => opt.MapFrom(src => 
                DeserializeStringList(src.Prerequisites)))
            .ForMember(dest => dest.LearningObjectives, opt => opt.MapFrom(src => 
                DeserializeStringList(src.LearningObjectives)));

        CreateMap<LearningPath, LearningPathDetailDto>()
            .ForMember(dest => dest.Prerequisites, opt => opt.MapFrom(src => 
                DeserializeStringList(src.Prerequisites)))
            .ForMember(dest => dest.LearningObjectives, opt => opt.MapFrom(src => 
                DeserializeStringList(src.LearningObjectives)))
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents))
            .ForMember(dest => dest.Assessments, opt => opt.MapFrom(src => src.Assessments));

        CreateMap<UserLearningPath, UserLearningPathDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.LearningPath.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.LearningPath.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.LearningPath.ImageUrl));

        // Content mappings
        CreateMap<Content, ContentDto>();
        CreateMap<Content, ContentDetailDto>()
            .ForMember(dest => dest.LearningPathTitle, opt => opt.MapFrom(src => src.LearningPath.Title));
        
        CreateMap<Content, ContentSummaryDto>();

        // Assessment mappings
        CreateMap<Assessment, AssessmentDto>();
        CreateMap<Assessment, AssessmentSummaryDto>();
          CreateMap<Question, QuestionDto>()
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => 
                DeserializeStringList(src.Options)));

        CreateMap<AssessmentResult, AssessmentResultDto>()
            .ForMember(dest => dest.AssessmentTitle, opt => opt.MapFrom(src => src.Assessment.Title));

        // Resource mappings
        CreateMap<Resource, ResourceDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => 
                DeserializeStringList(src.Tags)));

        CreateMap<Resource, ResourceDetailDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => 
                DeserializeStringList(src.Tags)));        // User Progress mappings
        CreateMap<UserProgress, UserProgressDto>();
    }

    private static List<string> DeserializeStringList(string? jsonString)
    {
        if (string.IsNullOrEmpty(jsonString))
            return new List<string>();

        try
        {
            return JsonSerializer.Deserialize<List<string>>(jsonString) ?? new List<string>();
        }
        catch
        {
            return new List<string>();
        }
    }
}
