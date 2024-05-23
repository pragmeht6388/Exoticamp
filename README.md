//Author Name- Saumya Tiwari (23/05/2024)
# Exoticamp Project

## Overview

This guide provides step-by-step instructions to build and run the Exoticamp application. Ensure you have all necessary dependencies installed before proceeding.

## Prerequisites

- .NET SDK
- Visual Studio or any other compatible IDE
- NuGet Package Manager

## Build and Run Instructions

Follow these steps to build and run the Exoticamp application:

### 1. Set the Startup Project

1. Open the solution in Visual Studio.
2. In the Solution Explorer, navigate to the `src` folder.
3. Locate the `Exoticamp.Api` project inside the `API` directory.
4. Right-click on `Exoticamp.Api`.
5. Select `Set as Startup Project`.

### 2. Update Databases

#### Using Package Manager Console

1. Go to the `Tools` menu in Visual Studio.
2. Select `NuGet Package Manager`.
3. Choose `Package Manager Console`.

#### Update Identity Database

1. In the `Package Manager Console`, select `Exoticamp.Identity` from the dropdown menu.
2. Execute the following command:
   ```powershell
   update-database -Context IdentityDbContext

#### Update Application Database
1. In the Package Manager Console, select Exoticamp.Persistence from the dropdown menu.
2. Execute the following command
   ```powershell
   update-database -Context ApplicationDbContext

### 3. Run the Application
1. Press F5 or click on the Start button in Visual Studio to run the application.