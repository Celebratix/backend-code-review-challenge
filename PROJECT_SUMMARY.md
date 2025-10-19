# Project Summary - Interview Exercise API

## Overview

This is a simplified ASP.NET Core Web API project created from the Celebratix backend repository for use as a code review exercise with backend engineering candidates. The project is ready to be published to a public GitHub repository.

## Location

The new project has been created at:
```
/Users/markodjordjevic/clbtx/interview-exercise-api/
```

## What Was Done

### 1. **Extracted and Simplified Code**
   - Analyzed the PR changes from `feature/clbtx-9999-interview-pr-do-not-remove` branch
   - Identified changes related to the Category feature
   - Created a standalone, minimal ASP.NET Core Web API project

### 2. **Project Structure Created**
   ```
   interview-exercise-api/
   ├── CategoriesApi/              # Main API project
   │   ├── Controllers/
   │   ├── Services/
   │   ├── Models/
   │   ├── DTOs/
   │   ├── Data/
   │   ├── Authorization/
   │   └── Helpers/
   ├── CategoriesApi.Tests/        # Test project
   ├── README.md                   # Candidate instructions
   ├── SOLUTION_GUIDE.md           # For interviewers (DO NOT SHARE)
   ├── CONTRIBUTING.md             # Guidelines for using/maintaining
   ├── LICENSE                     # MIT License
   └── .gitignore                  # Standard .NET gitignore
   ```

### 3. **Intentional Issues Included**
   
   The code contains 10 intentional issues for candidates to identify:
   
   **Critical:**
   - Wrong authorization on UpdateCategory endpoint (AllowAnonymous instead of admin-only)
   - Inconsistent validation (100 vs 200 character limit for Description)
   
   **Major:**
   - Improper exception handling (catching and re-throwing)
   - Missing return type on CreateCategory endpoint
   - Unused CancellationToken parameter
   - Breaking change in DTO property naming (Name → CategoryName)
   
   **Minor:**
   - Missing input validation
   - Inconsistent logging
   - Magic numbers
   - Incomplete test coverage

### 4. **Technology Stack**
   - .NET 9.0
   - ASP.NET Core Web API
   - Entity Framework Core (In-Memory Database)
   - xUnit for testing
   - FluentAssertions
   - Microsoft.AspNetCore.Mvc.Testing

### 5. **Documentation**
   - **README.md**: Instructions for candidates on how to review the code
   - **SOLUTION_GUIDE.md**: Detailed list of issues and scoring guide (for interviewers only)
   - **CONTRIBUTING.md**: Guidelines for maintaining and using the exercise
   - **LICENSE**: MIT License

## Verification

The project has been tested and verified:
- ✅ Builds successfully (`dotnet build`)
- ✅ Tests pass (`dotnet test`)
- ✅ Contains all intentional issues
- ✅ No private/company information included
- ✅ Ready for public GitHub repository

## Next Steps

To publish this to a public GitHub repository:

1. **Initialize Git Repository:**
   ```bash
   cd /Users/markodjordjevic/clbtx/interview-exercise-api
   git init
   git add .
   git commit -m "Initial commit: Categories API code review exercise"
   ```

2. **Create GitHub Repository:**
   - Go to GitHub and create a new public repository
   - Name suggestion: `backend-code-review-exercise` or similar
   - Do NOT initialize with README (we already have one)

3. **Push to GitHub:**
   ```bash
   git remote add origin <your-github-repo-url>
   git branch -M main
   git push -u origin main
   ```

4. **Important: Keep SOLUTION_GUIDE.md Private**
   - Consider creating a separate private repository for the solution guide
   - Or keep it locally and don't commit it to the public repo
   - You can add it to `.gitignore` if needed

## Using the Exercise

### For Candidates:
1. Share the public GitHub repository link
2. Direct them to read the README.md
3. Ask them to submit a code review document within a specified timeframe

### For Interviewers:
1. Use SOLUTION_GUIDE.md to evaluate submissions
2. Score based on the number and severity of issues found
3. Follow up with discussion about the issues and proposed fixes

## Customization

The exercise can be easily customized:
- Add more endpoints
- Introduce different types of issues
- Adjust complexity level
- Modify the technology stack

All changes should be documented in SOLUTION_GUIDE.md.

## License

This project is licensed under the MIT License, making it safe to share publicly.

---

**Created by:** Celebratix Engineering Team  
**Purpose:** Backend Engineer Interview Exercise  
**Date:** October 19, 2025

