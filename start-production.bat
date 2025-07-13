@echo off
echo Starting SkillUp Platform API in Production Mode...
cd /d "e:\Gallery\skillup-hager\Backend\src\SkillUpPlatform.API"

echo.
echo ========================================
echo       PRODUCTION MODE TESTING
echo ========================================
echo.

echo Setting environment to Production...
set ASPNETCORE_ENVIRONMENT=Production

echo Cleaning previous builds...
dotnet clean

echo Restoring packages...
dotnet restore

echo Building the project...
dotnet build --configuration Release

echo.
echo Starting the API server in Production mode...
echo.
echo API will be available at:
echo - HTTP: http://localhost:5000
echo - HTTPS: https://localhost:5001
echo - Swagger UI: https://localhost:5001/swagger
echo.
echo Press Ctrl+C to stop the server
echo.

dotnet run --configuration Release --urls "https://localhost:5001;http://localhost:5000"

pause
