using Xunit;
using System.Collections.Generic;
using System.Linq;
using InterportCargoQuotationSystem.Models;

public class UnitTest_userStory_I3
{
    [Fact]
    public void ShouldReturnOnlyQuotationsBelongingToCustomer()
    {

        var customerEmail = "customer@example.com";
        var allQuotations = new List<Quotation>
        {
            new Quotation { Id = 1, CustomerEmail = "customer@example.com", BasePrice = 1000 },
            new Quotation { Id = 2, CustomerEmail = "other@example.com", BasePrice = 1200 },
            new Quotation { Id = 3, CustomerEmail = "customer@example.com", BasePrice = 800 }
        };


        var customerQuotations = allQuotations
            .Where(q => q.CustomerEmail == customerEmail)
            .ToList();


        Assert.Equal(2, customerQuotations.Count);
        Assert.All(customerQuotations, q => Assert.Equal("customer@example.com", q.CustomerEmail));
    }

    [Fact]
    public void ShouldReturnEmptyListWhenNoQuotationsExist()
    {

        var customerEmail = "new@example.com";
        var allQuotations = new List<Quotation>();

       
        var result = allQuotations
            .Where(q => q.CustomerEmail == customerEmail)
            .ToList();


        Assert.Empty(result);
    }
}
