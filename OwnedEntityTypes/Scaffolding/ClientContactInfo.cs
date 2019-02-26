using System;
using System.Collections.Generic;

namespace Scaffolding
{
    public partial class ClientContactInfo
    {
        public int ClientId { get; set; }
        public string CellPhoneNo { get; set; }
        public string TelePhoneNo { get; set; }
        public string Email { get; set; }
        public virtual Clients Client { get; set; }
    }
}
