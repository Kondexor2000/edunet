# Eduworknet

Eduworknet is application ASP.NET Core servant to programming concepts management.
Project supports programming course students in information needed to solving tasks seeking.
Shortens time needed on learning about 30%.

---

## Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Functions](#functions)
- [Tech stack](#tech-stack)
- [Additional comments](#additional-comments)
- [Contact](#contact)

## Installation

```bash
git clone https://github.com/Kondexor2000/edunet.git
cd worknet
```

## Configuration

```bash
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet test
python generate_cert.py
python generate_cert2.py
dotnet run --launch-profile https
```
Check the API functionality in the browser: [Swagger UI](http://localhost:5260/swagger/)

## Functions

- Tag and category management by the administrator
- Creating, editing, and deleting topics
- Searching topics
- User role system (authentication and authorization)
- REST API
- API documentation in Swagger

## Tech stack

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI

## Additional comments

- .NET 8 SDK or newer
- PostgreSQL 13 or newer
- Prefered IDE: Visual Studio 2022 or Visual Studio Code
- Cooperation with Front-End Developer is recommended by visual part design
- Login system is created according to education value by programming

## Contact

- If you have any questions or suggestions, get in touch with us on e-mail address: k.kosciecha20@gmail.com
