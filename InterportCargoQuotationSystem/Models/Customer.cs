using System.ComponentModel.DataAnnotations;

namespace InterportCargoQuotationSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string FamilyName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, Phone]
        public string PhoneNumber { get; set; } = "";

        public string? CompanyName { get; set; }

        [Required]
        public string Address { get; set; } = "";


        public string PasswordHash { get; set; } = ""; 
    }
}
