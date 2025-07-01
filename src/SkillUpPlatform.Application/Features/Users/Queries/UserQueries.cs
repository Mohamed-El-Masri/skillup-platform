using MediatR;
using SkillUpPlatform.Application.Common.Models;
using SkillUpPlatform.Application.Features.Users.DTOs;

namespace SkillUpPlatform.Application.Features.Users.Queries;

public class GetUserByIdQuery : IRequest<Result<UserDto>>
{
    public int UserId { get; set; }
}

public class GetUserProfileQuery : IRequest<Result<UserProfileDto>>
{
    public int UserId { get; set; }
}

public class GetUsersQuery : IRequest<Result<List<UserDto>>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
}
