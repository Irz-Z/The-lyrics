@echo off
echo Building The Lyrics...

dotnet restore
if %ERRORLEVEL% neq 0 (
    echo Failed to restore packages
    exit /b %ERRORLEVEL%
)

dotnet build --configuration Release
if %ERRORLEVEL% neq 0 (
    echo Failed to build project
    exit /b %ERRORLEVEL%
)

echo Build completed successfully!
pause
