# SkillUp Platform - Smart Career Training Platform

## 🌟 Project Overview

SkillUp is an intelligent platform designed to support university students and fresh graduates in the Middle East and North Africa region. The platform helps users choose the right career path and acquire practical skills needed in today's job market.

## 🏗️ Architecture

The project follows **Clean Architecture** principles with **N-tier Architecture**:

```
📁 SkillUpPlatform/
├── 📁 src/
│   ├── 📁 SkillUpPlatform.API/          # Presentation Layer (Web API)
│   ├── 📁 SkillUpPlatform.Application/  # Business Logic Layer
│   ├── 📁 SkillUpPlatform.Domain/       # Domain Models & Entities
│   └── 📁 SkillUpPlatform.Infrastructure/ # Data Access & External Services
└── 📄 SkillUpPlatform.sln
```

### Layers Description:

1. **API Layer**: Controllers, Middleware, Authentication
2. **Application Layer**: CQRS (MediatR), DTOs, Validators, Handlers
3. **Domain Layer**: Entities, Enums, Repository Interfaces
4. **Infrastructure Layer**: EF Core, Repositories, External Services

## 🚀 Features

### MVP Features:
- ✅ **User Management**: Registration, Login, Profile Management
- 🔄 **Smart Assessment System**: Skills and interests analysis
- 📚 **Personalized Learning Paths**: AI-recommended courses
- 📖 **Educational Content**: Videos, PDFs, Interactive content
- 🤖 **AI Assistant**: Virtual assistant for guidance and recommendations
- 📋 **Professional Resources**: CV templates, Cover letters, Interview questions
- 📊 **User Dashboard**: Progress tracking and analytics

## 🌐 API Documentation & Swagger

### Accessing Swagger UI:
- **Development**: `https://localhost:5001/swagger`
- **Production**: `https://your-domain.com/swagger`

### Important Note:
Swagger is enabled in all environments (Development, Staging, Production) for easy API documentation access.

## 📦 Deployment Guide

### For Production Deployment:

1. **Build for Production**:
   ```bash
   # Run the production build script
   build-production.bat
   ```

2. **Test Production Mode Locally**:
   ```bash
   # Test production settings before deployment
   start-production.bat
   ```

3. **Deploy to Server**:
   - Copy the contents of `publish` folder to your server
   - Ensure your server has .NET 8.0 Runtime installed
   - Configure your web server (IIS, Apache, Nginx) to serve the application
   - Update `appsettings.Production.json` with your production settings

### Environment Variables:
- `ASPNETCORE_ENVIRONMENT`: Set to "Production" for production deployment
- Update connection strings in `appsettings.Production.json`

## 🛠️ Technology Stack

### Backend:
- **Framework**: ASP.NET Core 8.0 Web API
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer Tokens
- **Architecture Pattern**: CQRS with MediatR
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Caching**: Redis (StackExchange.Redis)
- **Logging**: Serilog

### AI Integration:
- **AI Engine**: Python + Flask API
- **Skills Analysis**: Machine Learning models
- **Career Recommendations**: AI-powered matching

## 📋 Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code
- Redis (optional for caching)

## 🚀 Getting Started

### Option 1: Quick Setup with Batch Scripts (Recommended)

1. **Setup Database** (First time only):
   ```bash
   # Double-click or run from command line:
   setup-database.bat
   ```

2. **Start the API**:
   ```bash
   # Double-click or run from command line:
   start-api.bat
   ```

### Option 2: Manual Setup

1. **Clone the Repository**
   ```bash
   git clone [repository-url]
   cd SkillUpPlatform
   ```

2. **Update Connection Strings** (Optional)
   The project is pre-configured to use LocalDB. Update `appsettings.json` if needed:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=skillup;Integrated Security=True;TrustServerCertificate=True;"
     }
   }
   ```

3. **Setup Database**
   ```bash
   cd src/SkillUpPlatform.API
   dotnet ef migrations add InitialCreate --project ../SkillUpPlatform.Infrastructure
   dotnet ef database update --project ../SkillUpPlatform.Infrastructure
   ```

4. **Build and Run**
   ```bash
   dotnet build
   dotnet run --project src/SkillUpPlatform.API
   ```

### 🌐 Access Points
- **Swagger UI**: https://localhost:5001/swagger
- **API Base URL**: https://localhost:5001/api/v1
- **HTTP URL**: http://localhost:5000/api/v1

## 📖 API Documentation

### Authentication Endpoints:
- `POST /api/v1/users/register` - User registration
- `POST /api/v1/users/login` - User login

### User Management:
- `GET /api/v1/users/profile` - Get user profile
- `PUT /api/v1/users/profile` - Update user profile
- `GET /api/v1/users/{id}` - Get user by ID

### Learning Paths:
- `GET /api/v1/learning-paths` - Get all learning paths
- `POST /api/v1/learning-paths/recommend` - Get AI recommendations
- `POST /api/v1/learning-paths/{id}/enroll` - Enroll in learning path

### Assessments:
- `GET /api/v1/assessments` - Get assessments
- `POST /api/v1/assessments/{id}/submit` - Submit assessment

### AI Assistant:
- `POST /api/v1/ai-assistant/chat` - Chat with AI
- `POST /api/v1/ai-assistant/analyze-skills` - Analyze user skills
- `POST /api/v1/ai-assistant/recommend-career` - Get career recommendations

## 🔧 Development Guidelines

### Code Structure:
- Follow **SOLID** principles
- Use **Repository Pattern** with Unit of Work
- Implement **CQRS** pattern with MediatR
- Apply **Dependency Injection** throughout

### Database Design:
- Entities follow **Domain-Driven Design**
- **Fluent API** configurations for complex relationships
- **Soft delete** pattern for data integrity

### Security:
- **JWT** authentication with role-based authorization
- **Input validation** with FluentValidation
- **HTTPS** enforcement
- **CORS** configuration for frontend integration

## 🌐 Frontend Integration

The API is designed to work with:
- **Angular 18** application
- **Bootstrap** for styling
- **RESTful** API consumption
- **JWT** token-based authentication

## 📊 Database Schema

### Core Entities:
- **Users**: User accounts and authentication
- **UserProfiles**: Extended user information
- **LearningPaths**: Course structures
- **Content**: Educational materials
- **Assessments**: Tests and quizzes
- **Resources**: Templates and guides

## 🔮 Future Enhancements

- **Real-time notifications** with SignalR
- **File upload** functionality for profile pictures
- **Advanced analytics** dashboard
- **Mobile app** development
- **Multi-language** support
- **Payment integration** for premium features

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 📞 Support

For support and questions, please contact the development team.

---

**Made with ❤️ for empowering students and graduates in their career journey**

## 🎉 Welcome to SkillUp Platform!
## 🎯 Potential Next Development Steps:

### 1. **Content Management Features** 
- Implement file upload functionality for educational content (videos, PDFs)
- Add content categorization and tagging
- Implement content approval workflow

### 2. **Enhanced AI Assistant Features**
- Integrate real AI service (OpenAI, Azure Cognitive Services)
- Implement conversation history
- Add more intelligent career recommendations

### 3. **Professional Resources Library**
- CV/Resume templates and builder
- Cover letter templates
- Interview questions database
- Job market insights

### 4. **Dashboard and Analytics**
- User progress tracking
- Learning analytics
- Performance metrics
- Achievement system

### 5. **Notification System**
- Email notifications
- In-app notifications
- Progress reminders

### 6. **Advanced Features**
- Role-based authorization (Admin, Content Creator, Student)
- Multi-language support (Arabic/English)
- Social features (peer interaction)

## 🤔 What would you like to focus on next?

Please let me know which area you'd like to develop further, or if you have a specific feature in mind. I can help you implement:

1. **Enhanced AI Integration** - Connect to real AI services
2. **Content Management** - File uploads and content organization  
3. **Professional Resources** - CV builder and templates
4. **Dashboard Analytics** - Progress tracking and insights
5. **User Experience** - Notifications and gamification
6. **Something else** - Any specific feature you have in mind

Just let me know your preference and I'll help you implement it step by step! 🚀
