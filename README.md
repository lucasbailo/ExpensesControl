# Expenses Control

**Transform Spending Into Smarter Financial Success**

Built with:

- JSON  
- Docker  
- NuGet  

---

## Table of Contents

- [Overview](#overview)  
- [Getting Started](#getting-started)  
  - [Prerequisites](#prerequisites)  
  - [Installation](#installation)  
- [Usage](#usage)  
- [Testing](#testing)  

---

## Overview

ExpensesControl is a modern, modular backend API designed for secure and scalable expense management.  
Built with **.NET 9.0**, it integrates:

- user authentication  
- expense tracking  
- analytics and insights  

The goal is to provide a clean, maintainable architecture with secure user handling and financial dashboards.

### Advantages

- **Modular Architecture** – clear separation between Application, Domain, and Infrastructure  
- **JWT Authentication** – secure user login and session management  
- **Expense Analytics Dashboard** – categorized + monthly insights  
- **Dockerized Deployment** – consistent builds for dev and production  
- **Entity Framework Core + SQL Server** – robust persistence layer  
- **Configurable & Extensible** – easy to adapt for different environments  

---

## Getting Started

### Prerequisites

- C# / .NET 9  
- NuGet  
- Docker (optional)

---

## Installation

### 1. Clone the repository

```bash
git clone https://github.com/lucasbailo/ExpensesControl
```

### 2. Navigate into the folder

```bash
cd ExpensesControl
```

### 3. Install dependencies

**Using NuGet:**

```bash
dotnet restore
```

---

## Usage

### Run with .NET

```bash
dotnet run
```

---

## Testing

**.NET**
```bash
dotnet test
```
