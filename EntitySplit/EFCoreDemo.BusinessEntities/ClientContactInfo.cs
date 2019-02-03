using System;
using System.Collections.Generic;

namespace EFCoreDemo.BusinessEntities
{
    public partial class ClientContactInfo
    {
        public virtual Client Client { get; set; }
        public string MailAddress { get; set; }
        public string CellPhoneNo { get; set; }
        public string TelephoneNo { get; set; }
    }
}