using InterportCargoQuotationSystem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace InterportCargoQuotationSystem.Tests
{
    public class QuotationTests
    {
        [Fact]
        public void CreateQuotation_WithValidData_ShouldPassValidation()
        {
            var quotation = new Quotation
            {
                CustomerEmail = "test@example.com",
                ContainerCount = 3,
                BasePrice = 1000m
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(quotation, new ValidationContext(quotation), validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void CreateQuotation_MissingEmail_ShouldFailValidation()
        {
            var quotation = new Quotation
            {
                ContainerCount = 3,
                BasePrice = 1000m
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(quotation, new ValidationContext(quotation), validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("CustomerEmail"));
        }

        [Fact]
        public void CreateQuotation_WithNegativeContainerCount_ShouldFailValidation()
        {
            var quotation = new Quotation
            {
                CustomerEmail = "test@example.com",
                ContainerCount = -2,
                BasePrice = 500m
            };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(quotation, new ValidationContext(quotation), validationResults, true);

            Assert.False(isValid);
        }
    }
}
