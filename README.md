# Eduworknet

Eduworknet to projekt aplikacji ASP.NET Core, który umożliwia zarządzanie wyszukiwaniami pojęć programistycznych. Celem projektu jest wsparcie uczestników kursów programistycznych, aby nie musieli korzystać z publicznych wyszukiwarek ani narzędzi AI w przypadku problemów z zadaniami. Zarządzanie tematami, tagami i kategoriami odbywa się przez prowadzących kurs lub osoby upoważnione przez nich.  

---

## Spis treści

- [Instalacja](#instalacja)
- [Konfiguracja](#konfiguracja)
- [Funkcje](#funkcje)
- [Tech stack](#tech-stack)
- [Zaległe informacje](#zaległe-informacje)
- [Kontakt](#kontakt)

## Instalacja

1. Sklonuj za pomocą git clone https://github.com/Kondexor2000/edunet.git
2. Przejdź do katalogu projektu: cd worknet
3. Otwórz projekt w preferowanym środowisku programistycznym (np. Visual Studio, Visual Studio Code)

## Konfiguracja

1. Utwórz plik konfiguracyjny appsettings.json w katalogu Eduworknet
2. dotnet add package nazwa_biblioteki
3. dotnet ef migrations add InitialCreate
4. dotnet ef database update
5. dotnet test
6. dotnet run
7. http://localhost:5260/swagger/

## Funkcje

- Zarządzanie tagami i kategoriami przez administratora
- Tworzenie, edycja i usuwanie tematów
- Wyszukiwanie tematów

## Tech stack

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger / OpenAPI

## Zaległe informacje

- Aplikacja korzysta z frameworka ASP.NET Core 3.1
- Aplikacja korzysta z bazy danych PostgreSQL
- Aplikacja korzysta z autoryzacji i autoryzacji ról

## Kontakt

- Jeśli masz jakiekolwiek pytań lub sugestii, skontaktuj się z nami na adres e-mail: k.kosciecha20@gmail.com
