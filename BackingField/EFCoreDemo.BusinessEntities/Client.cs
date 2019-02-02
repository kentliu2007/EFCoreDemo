using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.BusinessEntities
{
    public partial class Client
    {
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public virtual ClientAccountBalance AccountBalance { get; set; }

    }
}
