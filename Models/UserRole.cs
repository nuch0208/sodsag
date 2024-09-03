using System.ComponentModel.DataAnnotations;

namespace sodsag.Models
{
    public class UserRole
    {
        [Key]
        public int RoldId { get; set; } 
        public string Role { get; set; }
    }
}