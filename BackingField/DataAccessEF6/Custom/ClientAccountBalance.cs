using System;

namespace EFDemo.DataAccess
{
    public partial class ClientAccountBalance
    {
        public double Amount
        {
            get
            {
                return Currency == null ? rawAmount??0 : (rawAmount??0) / Math.Pow(10, Currency.DecimalPlaces ?? 0);
            }

            set
            {
                rawAmount = Currency == null ? (int)value : (int)(value * Math.Pow(10, Currency.DecimalPlaces ?? 0));
            }
            
        }
    }
}
