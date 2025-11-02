# Getting Started with BIMS Inventory Management System

## Quick Setup

### Prerequisites
• [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
• Any terminal/command prompt
• Optional: [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Running
1. **Clone the repository**
   ```
   git clone https://github.com/boricua007/BIMS_InventoryManagementSystem.git
   cd BIMS_InventoryManagementSystem
   ```

2. **Build the application**
   ```
   dotnet build
   ```

3. **Run the application**
   ```
   cd BIMS
   dotnet run
   ```

4. **Use the console interface**
   • The application will display a menu-driven interface
   • Follow the on-screen prompts to manage your inventory

## Navigation & Learning Guide

This console application demonstrates fundamental C# programming concepts through a practical inventory management system. The application focuses on core programming principles rather than complex user interfaces.


## Development Setup (Optional)

### For Development/Modification
If you want to modify or extend the application:

1. **Open in IDE**
   ```
   # Visual Studio
   start BIMS.sln
   
   # VS Code
   code .
   ```

2. **Hot Reload Development**
   ```
   dotnet watch run
   ```

3. **Project Structure**
   ```
   ├── Program.cs       # Main application logic and menu system
   ├── BIMS.csproj     # Project configuration
   └── bin/obj/        # Build artifacts
   ```

## Learning Objectives

This application demonstrates:

• C# syntax and language fundamentals
• Object-oriented programming with classes and properties
• Data structures and collection manipulation
• Input validation and error handling techniques
• Console application development patterns
• Method design and code organization
• Control structures (loops, conditionals, switch statements)