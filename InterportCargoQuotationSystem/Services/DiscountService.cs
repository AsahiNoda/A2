using System;

namespace InterportCargoQuotationSystem.Services
{
    public class DiscountService
    {
        /// <summary>
        /// Calculates discount amount for a quotation.
        /// </summary>
        /// <param name="basePrice">The base price of the quotation.</param>
        /// <param name="containerCount">The number of containers requested.</param>
        /// <param name="requiresQuarantine">True if quarantine is required.</param>
        /// <param name="requiresFumigation">True if fumigation is required.</param>
        /// <returns>The discount amount to be applied (in dollars).</returns>
        public decimal Calculate(decimal basePrice, int containerCount, bool requiresQuarantine, bool requiresFumigation)
        {
            decimal discount = 0;

            
            if (containerCount >= 10)
                discount += 100;
            else if (containerCount >= 5)
                discount += 50;

            
            if (requiresQuarantine)
                discount += 20;

            if (requiresFumigation)
                discount += 30;

           
            if (discount > basePrice)
                discount = basePrice;

            return discount;
        }
    }
}
