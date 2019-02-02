using System;
using System.Collections.Generic;

namespace EFCoreDemo.BusinessEntities
{
    public partial class ClientAccountBalance
    {
        public virtual Client Client { get; set; }
        public virtual Currency Currency { get; set; }
        public double Amount
        {
            get
            {
                return Currency == null ? _amount ?? 0 : (_amount ?? 0) / Math.Pow(10, Currency.DecimalPlaces ?? 0);
            }

            set
            {
                _amount = Currency == null ? (int)value : (int)(value * Math.Pow(10, Currency.DecimalPlaces ?? 0));
            }
        }
        protected int? _amount;
    }
}