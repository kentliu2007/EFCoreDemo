using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.BusinessEntities
{
    public partial class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<int> DecimalPlaces { get; set; }
    }
}
