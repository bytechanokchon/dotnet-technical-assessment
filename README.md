# Dotnet Technical Assessment

This repository contains my implementation for the provided .NET technical assessment.

## Setup

### Prerequisites

* .NET SDK
* Docker Desktop
* MySQL

### 1. Create MySQL Database

For this assessment, MySQL is configured to run using Docker.

You can create the database by running:

```bash
docker run --name local-db \
  -e MYSQL_ROOT_PASSWORD=root \
  -e MYSQL_DATABASE=assessment \
  -p 3306:3306 \
  -d mysql:latest
```

### 2. Update Database

The project includes Entity Framework Core migrations.

Open **Package Manager Console** in Visual Studio and run:

```powershell
Update-Database -Project Infrastructures -StartupProject Assessment
```

If the database update fails due to migration-related issues, you can recreate the initial migration:

```powershell
Add-Migration InitialDb -Project Infrastructures -StartupProject Assessment
```

Then run:

```powershell
Update-Database -Project Infrastructures -StartupProject Assessment
```

## Assessment Answers

### 1. Product API

The answer for Question 1 can be verified using:

```http
GET https://localhost:7089/api/Product
```

### 2. Sort Character API

The answer for Question 2 can be verified using:

```http
GET https://localhost:7089/api/Product/SortCharacter/{text}
```

### 3. Book API

The answer for Question 3 can be verified using:

```http
GET https://localhost:7089/api/Book
```

## Authentication

The login API is provided for demonstrating JWT authentication.

No request parameters are required because the user information is mocked for the purpose of generating an authentication token.

```http
POST https://localhost:7089/api/Auth/Login
```

After obtaining the token, it can be used to authorize requests through Swagger.

> **Note:** When entering the token in Swagger, it is not necessary to include the `Bearer` prefix.

## Notes

* The database configuration is intended for local development and assessment purposes.
* The user data used for authentication is mocked and is not intended for production use.
* HTTPS certificate warnings may appear when running the application locally.

Thank you for reviewing my submission.
