using System;
using System.Collections.Generic;

namespace TableSplitting.BusinessEntities
{
    public partial class Client
    {
        #region Public Properties
        public string Code { get; set; }
        public string Name { get; set; }
        public string CellPhoneNo
        {
            get { return getClientContactInfo().CellPhoneNo; }
            set { getClientContactInfo().CellPhoneNo = value; }
        }
        public string TelePhoneNo
        {
            get { return getClientContactInfo().TelePhoneNo; }
            set { getClientContactInfo().TelePhoneNo = value; }
        }
        public string Email
        {
            get { return getClientContactInfo().Email; }
            set { getClientContactInfo().Email = value; }
        }
        #endregion

        private ClientContactInfo _contactInfo { get; set; }
        private object clientContactInfoInitContext = new object();
        private ClientContactInfo getClientContactInfo()
        {
            if (_contactInfo == null)
            {
                lock (clientContactInfoInitContext) { _contactInfo = new ClientContactInfo(); }
            }
            return _contactInfo;
        }

    }
}