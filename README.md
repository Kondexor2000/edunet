# Eduworknet

Eduworknet to aplikacja ASP.NET Core służąca do zarządzania pojęciami programistycznymi.
Projekt wspiera uczestników kursów programistycznych w wyszukiwaniu informacji potrzebnych do rozwiązywania zadań.
Skraca czas potrzebny na przyswajanie wiedzy o 30%.

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
- Współpraca z Front-End Developerem zalecana przy projektowaniu części wizualnej

## Kontakt

- Jeśli masz jakiekolwiek pytań lub sugestii, skontaktuj się z nami na adres e-mail: k.kosciecha20@gmail.com
