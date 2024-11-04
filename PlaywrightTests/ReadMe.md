# Playwright BDD Project Overview

## Introduction

This framework leverages Playwright with C# for automating browser interactions, and Extent Reports for comprehensive test reporting. It follows the BDD structure using Gherkin syntax to make test scenarios more understandable and maintainable.

## Project Structure

The project is organized into several key folders that adhere to BDD practices:

- **Features/**: Holds feature files written in Gherkin syntax to describe test scenarios.
  
- **Hooks/**: Contains hooks for setting up and tearing down test scenarios.
  
- **Pages/**: Includes page objects that represent the web pages in the application.
  
- **Steps/**: Contains step definitions for the BDD scenarios.

- **default/**: Includes Extent Reports to provide detailed reporting on test execution.

- **Tests/**: Contains sample tests for demonstration purposes.
  - **SampleTestWithoutBDD.cs**: A simple test without the BDD approach.
  - **SampleScenarioTestWithoutPOM.cs**: A simple scenario test that does not utilize the Page Object Model.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- [Playwright](https://playwright.dev/dotnet/docs/intro) library for .NET.

## Dependencies

This project uses NuGet Package Manager to manage dependencies. Key packages include:
- Microsoft.Playwright: For browser automation.
- AventStack.ExtentReports: For generating HTML reports.

`dotnet add package Microsoft.Playwright`
`dotnet add package SpecFlow.NUnit`
`dotnet add package NUnit`
`dotnet add package AventStack.ExtentReports`

## Initialize Playwright

`dotnet playwright install`

## Run Tests

`dotnet test`
