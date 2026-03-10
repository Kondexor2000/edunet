# Eduworknet

Eduworknet to aplikacja ASP.NET Core służąca do zarządzania pojęciami programistycznymi.
Projekt wspiera uczestników kursów programistycznych w wyszukiwaniu informacji potrzebnych do rozwiązywania zadań.  

---

## Spis treści

- [Instalacja](#instalacja)
- [Konfiguracja](#konfiguracja)
- [Funkcje](#funkcje)
- [Tech stack](#tech-stack)
- [Dodatkowe informacje](#dodatkowe-informacje)
- [Kontakt](#kontakt)

## Instalacja

1. git clone https://github.com/Kondexor2000/edunet.git
2. cd worknet

## Konfiguracja

1. Utwórz plik konfiguracyjny appsettings.json w katalogu Eduworknet
2. dotnet restore
3. dotnet ef migrations add InitialCreate
4. dotnet ef database update
5. dotnet test
6. dotnet run
7. http://localhost:5260/swagger/

## Funkcje

- Zarządzanie tagami i kategoriami przez administratora
- Tworzenie, edycja i usuwanie tematów
- Wyszukiwanie tematów
- System ról użytkowników
- API REST
- dokumentację Swagger

## Tech stack

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI

## Dodatkowe informacje

- Aplikacja korzysta z frameworka ASP.NET Core 3.1
- Aplikacja korzysta z bazy danych PostgreSQL
- Aplikacja korzysta z autoryzacji i autoryzacji ról

## Kontakt

- Jeśli masz jakiekolwiek pytań lub sugestii, skontaktuj się z nami na adres e-mail: k.kosciecha20@gmail.com
