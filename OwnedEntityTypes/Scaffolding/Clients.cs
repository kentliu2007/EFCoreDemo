using System;
using System.Collections.Generic;

namespace Scaffolding
{
    public partial class Clients
    {
        public int ClientId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ClientContactInfo ClientContactInfo { get; set; }
    }
}
