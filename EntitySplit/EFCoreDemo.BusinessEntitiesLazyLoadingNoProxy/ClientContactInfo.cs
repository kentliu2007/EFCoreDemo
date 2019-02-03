using System;
using System.Collections.Generic;

namespace EFCoreDemo.BusinessEntitiesLazyLoadingNoProxy
{
    public partial class ClientContactInfo
    {
        public Client Client { get; set; }
        public string MailAddress { get; set; }
        public string CellPhoneNo { get; set; }
        public string TelephoneNo { get; set; }
    }
}