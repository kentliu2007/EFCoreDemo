using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.BusinessEntities
{
    public partial class Client
    {
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string MailAddress
        {
            get { return getClientContactInfo().MailAddress; }
            set { getClientContactInfo().MailAddress = value; }
        }
        public string CellPhoneNo
        {
            get { return getClientContactInfo().CellPhoneNo; }
            set { getClientContactInfo().CellPhoneNo = value; }
        }
        public string TelephoneNo
        {
            get { return getClientContactInfo().TelephoneNo; }
            set { getClientContactInfo().TelephoneNo = value; }
        }
        public virtual ClientContactInfo ContactInfo { get; set; }

        protected void initContactInfo()
        {
            lock (this) { ContactInfo = new ClientContactInfo() { Client = this }; };
        }
        protected ClientContactInfo getClientContactInfo()
        {
            if (ContactInfo == null) initContactInfo();
            return ContactInfo;
        }
    }
}
