@echo off
echo Setting up SkillUp Platform Database...
cd /d "e:\PWD - 9Months\Intake 45 labs\ITI 9 Months Labs\00- project\07-Graduation Project\SkillUpPlatform\src\SkillUpPlatform.API"

echo Creating database migration...
dotnet ef migrations add InitialCreate --project ..\SkillUpPlatform.Infrastructure --force

echo Updating database...
dotnet ef database update --project ..\SkillUpPlatform.Infrastructure

echo Database setup completed!
echo.
echo Database Name: skillup
echo Server: . (Local SQL Server)
echo.
pause
