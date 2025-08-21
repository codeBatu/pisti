# Pisti - C# Console Application

Always reference these instructions first and fallback to search or bash commands only when you encounter unexpected information that does not match the info here.

Pisti is a simple C# .NET 8.0 console application structured as a Visual Studio solution with two projects: a main console application (`pisti`) and a domain library project (`domain`). The application currently outputs "Hello, World!" but appears to be set up for future card game development based on the name "pisti".

## Working Effectively

### Prerequisites
- .NET 8.0 SDK is required and already available in the development environment
- No additional dependencies or external tools required

### Essential Commands (All Validated Working)
Execute these commands from the repository root directory:

```bash
# Restore NuGet packages (4-5 seconds)
dotnet restore

# Build solution (7-8 seconds) 
dotnet build

# Run the main application (1.5 seconds)
dotnet run --project pisti

# Test the solution (1.4 seconds, currently no tests)
dotnet test

# Clean build artifacts (0.8 seconds)
dotnet clean

# Verify code formatting (7-8 seconds)
dotnet format --verify-no-changes

# Apply code formatting if needed
dotnet format
```

### Build Configurations
```bash
# Debug build (default, ~7-8 seconds)
dotnet build --configuration Debug

# Release build (~1.6 seconds)
dotnet build --configuration Release

# Run release build directly
./pisti/bin/Release/net8.0/pisti
```

### Complete Workflow Timing
NEVER CANCEL: Full workflow (clean + restore + build + run + test + format) takes approximately 12-15 seconds. Set timeout to 30+ seconds for safety.

## Validation

### Manual Validation Steps
Always perform these validation steps after making code changes:
1. Run `dotnet build` - must complete without errors or warnings
2. Run `dotnet run --project pisti` - verify expected output appears
3. Run `dotnet format --verify-no-changes` - ensure code follows formatting standards
4. Test direct executable: `./pisti/bin/Debug/net8.0/pisti` - should execute successfully

### Expected Output
The application should output: `Hello, World!`

Any deviation from this output indicates a code issue that needs investigation.

## Repository Structure

### Key Directories and Files
```
/home/runner/work/pisti/pisti/          # Repository root
├── .github/                            # GitHub configuration (create workflows here)
├── .gitignore                          # Standard Visual Studio .gitignore
├── README.md                           # Basic project description
├── pisti.sln                           # Visual Studio solution file
├── pisti/                              # Main console application project
│   ├── pisti.csproj                    # Project file (net8.0, executable)
│   └── Program.cs                      # Main entry point
└── domain/                             # Domain library project
    └── domain.csproj                   # Project file (net8.0, library)
```

### Project References
- `pisti` project references `domain` project
- `domain` project is currently empty (contains only .csproj file)
- Both projects target .NET 8.0 with nullable reference types enabled

## Navigation and Development

### Primary Development Locations
- **Main application logic**: `/home/runner/work/pisti/pisti/pisti/Program.cs`
- **Domain/business logic**: `/home/runner/work/pisti/pisti/domain/` (currently empty)
- **Project configuration**: `.csproj` files in each project directory
- **Solution configuration**: `/home/runner/work/pisti/pisti/pisti.sln`

### Build Output Locations
- **Debug builds**: `{project}/bin/Debug/net8.0/`
- **Release builds**: `{project}/bin/Release/net8.0/`
- **Main executable**: `pisti/bin/{Configuration}/net8.0/pisti` (native executable)
- **Library output**: `domain/bin/{Configuration}/net8.0/domain.dll`

### Common Development Tasks

#### Adding New Features
1. Implement business logic in the `domain` project
2. Update the main `Program.cs` to use domain classes
3. Always build and test after changes: `dotnet build && dotnet run --project pisti`

#### Creating Tests
Currently no test projects exist. To add testing:
1. Create new test project: `dotnet new xunit -n pisti.Tests`
2. Add project reference: `dotnet add pisti.Tests reference domain`
3. Update solution: `dotnet sln add pisti.Tests`

#### Code Formatting
Always run `dotnet format` before committing changes to ensure consistent code style.

## CI/CD Recommendations

### GitHub Actions Setup
Consider creating `.github/workflows/build.yml` with these validated steps:
```yaml
- name: Restore dependencies
  run: dotnet restore
  timeout-minutes: 2

- name: Build
  run: dotnet build --configuration Release --no-restore  
  timeout-minutes: 2

- name: Test
  run: dotnet test --no-build --configuration Release
  timeout-minutes: 2

- name: Format verification
  run: dotnet format --verify-no-changes --no-restore
  timeout-minutes: 2
```

### Pre-commit Validation
Always run these commands before committing:
1. `dotnet build` (verify builds successfully)
2. `dotnet run --project pisti` (verify expected functionality)
3. `dotnet format --verify-no-changes` (verify formatting compliance)

## Troubleshooting

### Common Issues
- **Build failures**: Ensure .NET 8.0 SDK is available with `dotnet --version`
- **Missing dependencies**: Run `dotnet restore` to restore NuGet packages
- **Format violations**: Run `dotnet format` to auto-fix formatting issues
- **Clean build needed**: Run `dotnet clean` followed by `dotnet build`

### Performance Notes
All operations are very fast due to the simple project structure:
- Cold builds: ~7-8 seconds
- Incremental builds: ~1-2 seconds  
- Application startup: ~50ms
- Clean operations: <1 second

This is a lightweight, fast-building project with minimal external dependencies.