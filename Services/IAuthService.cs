using Eduworknet.DTOs;
namespace Worknet.Services
{
    public interface IAuthService
    {
        // Logowanie - zwraca token JWT lub null
        Task<string?> LoginAsync(LoginDto dto);

        // Rejestracja - zwraca token JWT po pomyślnej rejestracji lub null
        Task<string?> RegisterAsync(RegisterDto dto);

        // Odświeżenie tokena (opcjonalne)
        Task<string?> RefreshTokenAsync(string expiredToken);

        // Wylogowanie (np. usuwanie tokenu z bazy / czarnej listy)
        Task LogoutAsync(string username);
    }
}