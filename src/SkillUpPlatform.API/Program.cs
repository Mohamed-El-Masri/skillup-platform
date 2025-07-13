using SkillUpPlatform.Application;
using SkillUpPlatform.Infrastructure;
using SkillUpPlatform.API.Middleware;
using SkillUpPlatform.API.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger with JWT support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "SkillUp Platform API", 
        Version = "v1",
        Description = "Smart Career Training Platform for Students and Graduates"
    });
    
    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add application services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add API specific services
builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
// Enable Swagger in all environments (Development, Production, etc.)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillUp Platform API V1");
    c.RoutePrefix = "swagger"; // Set Swagger UI at /swagger
    c.DocumentTitle = "SkillUp Platform API Documentation";
    c.DisplayRequestDuration();
});

app.UseHttpsRedirection();

// Add CORS
app.UseCors("AllowAll");

// Add authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Add custom middleware
app.UseMiddleware<ExceptionMiddleware>();
app.UseUserContext();

app.MapControllers();

app.Run();
