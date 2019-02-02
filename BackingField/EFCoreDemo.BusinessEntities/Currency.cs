using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.BusinessEntities
{
    public partial class Currency
    {
        public Currency()
        {
            ClientAccountBalances = new HashSet<ClientAccountBalance>();
        }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<int> DecimalPlaces { get; set; }
        public virtual ICollection<ClientAccountBalance> ClientAccountBalances { get; set; }
    }
}
