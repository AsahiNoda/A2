using System.ComponentModel.DataAnnotations;

namespace InterportCargoQuotationSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string FamilyName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string EmployeeType { get; set; } = string.Empty;

        public string? Address { get; set; }

        
        public string PasswordHash { get; set; } = string.Empty;
    }
}
