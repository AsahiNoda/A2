using Xunit;
using InterportCargoQuotationSystem.Services;

namespace InterportCargoQuotationSystem.Tests
{
    public class DiscountServiceTests
    {
        [Theory]
        [InlineData(4, false, false, 0.00)]
        [InlineData(6, true, false, 0.025)]
        [InlineData(6, true, true, 0.05)]
        [InlineData(11, true, true, 0.10)]
        public void GetDiscountRate_ReturnsExpectedRate(int containers, bool quarantine, bool fumigation, decimal expected)
        {
            // Act
            var result = DiscountService.GetDiscountRate(containers, quarantine, fumigation);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
