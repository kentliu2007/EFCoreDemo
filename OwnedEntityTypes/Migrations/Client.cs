using System;
using System.Collections.Generic;

namespace Migrations
{
    public partial class Client
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ClientContactInfo ContactInfo { get; set; }
    }
}