using System;
using System.ComponentModel.DataAnnotations;

namespace InterportCargoQuotationSystem.Models
{
    /// <summary>
    /// Represents a quotation in the cargo system.
    /// </summary>
    public class Quotation
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int ContainerCount { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal BasePrice { get; set; }

        public bool RequiresQuarantine { get; set; }

        public bool RequiresFumigation { get; set; }

        /// <summary>
        /// Total calculated amount for the quotation.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The current status of the quotation (e.g., Pending, Approved, Rejected).
        /// </summary>
        public string Status { get; set; } = "Pending";

        /// <summary>
        /// Indicates whether a discount was applied.
        /// </summary>
        public bool DiscountApplied { get; set; }

        /// <summary>
        /// Feedback provided by the customer after reviewing the quotation.
        /// </summary>
        public string? CustomerFeedback { get; set; }

        /// <summary>
        /// Date the quotation was created.
        /// </summary>
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
