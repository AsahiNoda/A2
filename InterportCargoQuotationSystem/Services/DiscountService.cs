namespace InterportCargoQuotationSystem.Services
{
    public static class DiscountService
    {
        public static decimal GetDiscountRate(int containerCount, bool quarantine, bool fumigation)
        {
            if (containerCount > 10 && quarantine && fumigation)
                return 0.10m;
            if (containerCount > 5 && quarantine && fumigation)
                return 0.05m;
            if (containerCount > 5 && (quarantine || fumigation))
                return 0.025m;
            return 0.0m;
        }
    }
}
