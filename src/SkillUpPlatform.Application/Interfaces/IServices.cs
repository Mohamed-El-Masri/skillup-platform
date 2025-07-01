using SkillUpPlatform.Application.Features.AI.Commands;

namespace SkillUpPlatform.Application.Interfaces;

public interface IAIService
{
    Task<string> ChatWithAssistantAsync(string message, string? context = null);
    Task<SkillAnalysisResult> AnalyzeSkillsAsync(List<string> skills, List<int> assessmentResults);
    Task<List<CareerRecommendation>> RecommendCareerAsync(List<string> skills, List<string> interests, string? educationLevel, string? experience);
    Task<string> GenerateCVAsync(int userId, string templateId);
    Task<List<string>> GenerateRecommendationsAsync(int userId, string recommendationType);
    Task<string> GenerateAssessmentFeedbackAsync(string assessmentTitle, int score, int maxScore, bool isPassed);
}

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
    Task SendEmailVerificationAsync(string email, string verificationLink);
    Task SendPasswordResetAsync(string email, string resetLink);
}

public interface IFileService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string folder);
    Task<bool> DeleteFileAsync(string fileUrl);
    Task<Stream> DownloadFileAsync(string fileUrl);
}

public interface ITokenService
{
    string GenerateJwtToken(int userId, string email, string role);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
    int GetUserIdFromToken(string token);
}

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan expiration);
    Task RemoveAsync(string key);
    Task RemovePatternAsync(string pattern);
}
