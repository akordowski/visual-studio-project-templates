# Visual Studio Project Templates

This repository contains custom full configured Visual Studio project templates.

## Setup

Install templates

```bash
./scripts/install.ps1
```

Uninstall templates

```bash
./scripts/uninstall.ps1
```

## Templates

### Console App

A full configured project template for CLI projects.

Packages:

- `Microsoft.Extensions.DependencyInjection`
- `Serilog`
- `Serilog.Sinks.Console`
- `Serilog.Sinks.File`
- `Spectre.Console.Cli`

**Visual Studio:** Console App (Custom)

```bash
# Install
dotnet new install ./src/ConsoleApplicationCSharp/

# Uninstall
dotnet new uninstall ./src/ConsoleApplicationCSharp/

# Create
dotnet new console-custom --name Project
```

### xUnit Test Project

A full configured project template base test classes.

Packages:

- `FluentAssertions`
- `Moq`
- `Verify.XunitV3`
- `XunitXml.TestLogger`

**Visual Studio:** xUnit Test Project (Custom)

```bash
# Install
dotnet new install ./src/XUnitCSharp/

# Uninstall
dotnet new uninstall ./src/XUnitCSharp/

# Create
dotnet new console-custom --name Project.Tests
```
