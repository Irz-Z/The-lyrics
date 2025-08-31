@echo off
echo Running The Lyrics in Debug mode...
echo.

dotnet run --project TheLyrics --configuration Debug --verbosity normal

if %ERRORLEVEL% neq 0 (
    echo Failed to run project
    echo Error code: %ERRORLEVEL%
    pause
    exit /b %ERRORLEVEL%
)

echo Application finished running.
pause
