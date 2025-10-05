# LavenderSpiritAPI

LavenderSpiritAPI to nowoczesne RESTful API stworzone w technologii ASP.NET Core 8, umożliwiające zarządzanie wolontariuszami, organizacjami oraz wydarzeniami. Projekt wspiera rejestrację, autoryzację, zarządzanie eventami i relacjami wiele-do-wielu pomiędzy użytkownikami a wydarzeniami.

## Spis treści

- [Funkcjonalności](#funkcjonalności)
- [Technologie](#technologie)
- [Wymagania](#wymagania)
- [Instalacja](#instalacja)
- [Konfiguracja](#konfiguracja)
- [Uruchomienie](#uruchomienie)
- [Struktura projektu](#struktura-projektu)
- [Przykładowe endpointy](#przykładowe-endpointy)
- [Bezpieczeństwo](#bezpieczeństwo)
- [Swagger / OpenAPI](#swagger--openapi)
- [Autorzy](#autorzy)

---

## Funkcjonalności

- Rejestracja i logowanie organizacji oraz wolontariuszy
- Zarządzanie wydarzeniami (tworzenie, usuwanie, pobieranie)
- Przypisywanie wolontariuszy do wydarzeń (relacja wiele-do-wielu)
- Przypisywanie wydarzeń do organizacji (relacja jeden-do-wielu)
- Walidacja danych wejściowych (DataAnnotations)
- Autoryzacja JWT
- Dokumentacja API (Swagger)

## Technologie

- .NET 8 (ASP.NET Core Web API)
- Entity Framework Core 9 (SQL Server)
- AutoMapper
- JWT Authentication
- Swagger (Swashbuckle)
- C# 12

## Wymagania

- .NET 8 SDK
- SQL Server (np. LocalDB)
- Visual Studio 2022 lub nowszy

## Instalacja

1. **Klonowanie repozytorium**
2. **Przygotowanie bazy danych**
- Upewnij się, że SQL Server jest uruchomiony.
- Skonfiguruj connection string w pliku `appsettings.json` lub `appsettings.Development.json`:
  ```json
  "ConnectionStrings": {
    "DefaultConnectionString": "Server=(localdb)\\mssqllocaldb;Database=LavenderSpiritDb;Trusted_Connection=True;"
  }
  ```

3. **Migracje bazy danych**

## Konfiguracja

- Pliki konfiguracyjne: `appsettings.json`, `appsettings.Development.json`
- Ustawienia JWT w sekcji `Authentication`
- Connection string w sekcji `ConnectionStrings`

## Uruchomienie
Aplikacja domyślnie uruchomi się na `https://localhost:5001` lub `http://localhost:5000`.

## Struktura projektu

- `Controllers/` – kontrolery API
- `Models/` – modele domenowe (np. `Organization`, `LavEvent`, `Voluntree`)
- `DTOs/` – obiekty transferowe (DTO)
- `Services/` – logika biznesowa
- `Data/` – kontekst bazy danych (`AppDbContext`)
- `Migrations/` – migracje EF Core

## Struktura bazy danych
<img width="1042" height="868" alt="image" src="https://github.com/user-attachments/assets/f39fcb2a-edd7-4b8e-ac29-6366aec8e812" />

## Przykładowe endpointy

### Organizacje

- `POST /Organization` – rejestracja organizacji
- `GET /Organization` – lista organizacji
- `GET /Organization/{organizationID}` – wydarzenia danej organizacji

### Wolontariusze

- `POST /Voluntree` – rejestracja wolontariusza

### Wydarzenia

- `POST /Event/{userID}` – utworzenie wydarzenia
- `GET /Event` – lista wydarzeń
- `GET /Event/{eventID}` – szczegóły wydarzenia
- `DELETE /Event/{userID}/{eventID}` – usunięcie wydarzenia

## Bezpieczeństwo

- Autoryzacja oparta o JWT Bearer
- Hasła przechowywane w postaci hashowanej (zalecane)
- Walidacja danych wejściowych

## Swagger / OpenAPI

Po uruchomieniu aplikacji w trybie deweloperskim dokumentacja API dostępna jest pod `/swagger`.

## Autorzy
- [Maria Bludova](https://github.com/longlongint24)
- [Martyna Jagoda](https://github.com/martynajagoda)
- [Mateusz Poszelężny](https://github.com/Mitfort)
- [Rafał Jarczyk](https://github.com/RafDrzej)
- [Jakub Taranek](https://github.com/QbaTa)
- [Michał Pytlarz](https://github.com/MichalPytlarz)

---

> Projekt rozwijany w celach edukacyjnych i społecznych. Wszelkie uwagi i pull requesty są mile widziane!
