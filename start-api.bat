@echo off
echo Starting SkillUp Platform API...
cd /d "e:\PWD - 9Months\Intake 45 labs\ITI 9 Months Labs\00- project\07-Graduation Project\SkillUpPlatform\src\SkillUpPlatform.API"

echo Cleaning previous builds...
dotnet clean

echo Restoring packages...
dotnet restore

echo Building the project...
dotnet build

echo Starting the API server...
echo.
echo API will be available at:
echo - HTTP: http://localhost:5000
echo - HTTPS: https://localhost:5001
echo - Swagger UI: https://localhost:5001/swagger
echo.
echo Press Ctrl+C to stop the server
echo.

dotnet run --urls "https://localhost:5001;http://localhost:5000"

pause
