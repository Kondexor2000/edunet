using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Eduworknet.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        // ===== ONE TO ONE =====

        // Django: HR.user = OneToOneField(User)

        // Django: CV.user = OneToOneField(User)

        // ===== ONE TO MANY =====

        // LoginLog.user (FK)

        // Certificate.user

        // Comment.author

        // Opinion.author

        // ===== MANY TO MANY =====

        // OffersJobUser (through table)

        // Transmition.leaders (FK)

        // Transmition.participants (M2M)
    }
}
