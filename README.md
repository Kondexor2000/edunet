# Eduworknet

Eduworknet is application ASP.NET Core servant to programming concepts management.
Project supports programming course students in information needed to solving tasks seeking.
Shortens time needed on learning about 30%.

---

## Spis treści

- [Instalacja](#instalacja)
- [Konfiguracja](#konfiguracja)
- [Funkcje](#funkcje)
- [Tech stack](#tech-stack)
- [Uwagi dodatkowe](#uwagi-dodatkowe)
- [Kontakt](#kontakt)

## Instalacja

```bash
git clone https://github.com/Kondexor2000/edunet.git
cd worknet
```

## Konfiguracja

```bash
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet test
python generate_cert.py
python generate_cert2.py
dotnet run --launch-profile https
```
Sprawdź działanie API w przeglądarce: [Swagger UI](http://localhost:5260/swagger/)

## Funkcje

- Zarządzanie tagami i kategoriami przez administratora
- Tworzenie, edycja i usuwanie tematów
- Wyszukiwanie tematów
- System ról użytkowników (uwierzytelnianie i autoryzacja)
- API REST
- Dokumentacja API w Swagger

## Tech stack

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI

## Uwagi dodatkowe

- .NET 8 SDK lub nowszy
- PostgreSQL 13 lub nowszy
- Preferowane IDE: Visual Studio 2022 lub Visual Studio Code
- Cooperation with Front-End Developer is zalecana by visual part design

## Kontakt

- If you have any questions or suggestions, get in touch with us on e-mail address: k.kosciecha20@gmail.com
