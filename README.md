Eduworknet

Eduworknet to projekt aplikacji ASP.NET Core, która umożliwia zarządzanie wyszukiwaniami pojęć programistycznych, aby nie trzeba było prosić o pomoc ogólnodostępną wyszukiwarkę internetową oraz narzędzi sztucznej inteligencji. Projekt może pomóc uczestnikom kursów programistycznych w przypadku pogubienia się podczas wykonywania zadań sformułowanych przez prowadzących kursu. O zarządzaniu tematami, tagami i kategoriami decydują prowadzący kursów lub osoby upoważnione przez prowadzącego kursów. W sprawie wizualnej części projektu wymagana jest współpraca z Front-End Developerem, zgodnie z zaleceniami koncentracji na back-end.

Instalacja

    Sklonuj za pomocą git clone https://github.com/Kondexor2000/edunet.git
    Przejdź do katalogu projektu: cd worknet
    Otwórz projekt w preferowanym środowisku programistycznym (np. Visual Studio, Visual Studio Code)

UWAGA!

    W celu sprawdzenia, czy API działa, stosuje się Swagger

Testy automatyczne (jednostkowe i integracyjne)

    Uruchamia się za pomocą dotnet test

Konfiguracja

    Utwórz plik konfiguracyjny appsettings.json w katalogu Eduworknet
    dotnet add package nazwa_biblioteki
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    dotnet run

Funkcje

    Zarządzanie tagami i kategoriami przez administratora
    Tworzenie, edycja i usuwanie tematów
    Przeszukiwanie tematów

Tech stack

    ASP.NET Core 8
    Entity Framework Core
    PostgreSQL
    Swagger / OpenAPI

Zaległe informacje

    Aplikacja korzysta z frameworka ASP.NET Core 3.1
    Aplikacja korzysta z bazy danych PostgreSQL
    Aplikacja korzysta z autoryzacji i autoryzacji ról

Kontakt

Jeśli masz jakiekolwiek pytań lub sugestii, skontaktuj się z nami na adres e-mail: k.kosciecha20@gmail.com
