using Microsoft.AspNetCore.Identity;

namespace DeepDive11.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
