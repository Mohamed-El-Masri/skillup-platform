@echo off
echo Building and Publishing SkillUp Platform API for Production...
cd /d "e:\Gallery\skillup-hager\Backend\src\SkillUpPlatform.API"

echo.
echo ========================================
echo          PRODUCTION BUILD
echo ========================================
echo.

echo [1/5] Cleaning previous builds...
dotnet clean --configuration Release
if %errorlevel% neq 0 (
    echo ERROR: Failed to clean project
    pause
    exit /b 1
)

echo [2/5] Restoring packages...
dotnet restore
if %errorlevel% neq 0 (
    echo ERROR: Failed to restore packages
    pause
    exit /b 1
)

echo [3/5] Building in Release mode...
dotnet build --configuration Release --no-restore
if %errorlevel% neq 0 (
    echo ERROR: Failed to build project
    pause
    exit /b 1
)

echo [4/5] Publishing for production...
dotnet publish --configuration Release --output "..\..\publish" --no-build
if %errorlevel% neq 0 (
    echo ERROR: Failed to publish project
    pause
    exit /b 1
)

echo [5/5] Production build completed successfully!
echo.
echo ========================================
echo          BUILD COMPLETED
echo ========================================
echo.
echo Published files are located in: e:\Gallery\skillup-hager\Backend\publish
echo.
echo After deployment, Swagger will be available at:
echo - Your-Server-URL/swagger
echo.
echo Press any key to continue...
pause > nul
