using System;
using System.ComponentModel.DataAnnotations;

namespace InterportCargoQuotationSystem.Models
{
    public class Quotation
    {
        public int Id { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        public DateTime DateIssued { get; set; } = DateTime.Now;

        [Range(1, int.MaxValue, ErrorMessage = "Container count must be positive.")]
        public int ContainerCount { get; set; }

        public bool RequiresQuarantine { get; set; }
        public bool RequiresFumigation { get; set; }

        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal DiscountApplied { get; set; }

        public string Status { get; set; } = "Pending";

        public string? CustomerFeedback { get; set; }
        public bool Booked { get; set; } = false;
        public string OriginCountry { get; set; } = string.Empty;
        public string DestinationCountry { get; set; } = string.Empty;
        public string PackageType { get; set; } = string.Empty;
        public decimal PackageWidth { get; set; }
        public decimal PackageHeight { get; set; }


    }
}
