using EFCoreDemo.BusinessEntitiesLazyLoadingNoProxy.Extension;
using System;

namespace EFCoreDemo.BusinessEntitiesLazyLoadingNoProxy
{
    public partial class Client 
    {
        public Client() { }

        #region Public Properties 
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        #region Public Perperties from ClientContactInfo Instance
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
        #endregion
        #endregion

        #region Using Lazy Loading to support Entity Split
        #region The LazyLoader Injection
        private Client(Action<object, string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private Action<object, string> _lazyLoader;
        #endregion

        #region internal ClientContactInfo Instance
        private ClientContactInfo ContactInfo
        {
            get { return _lazyLoader.Load(this, ref _contactInfo); }
            set { _contactInfo = value; }
        }
        private ClientContactInfo _contactInfo;
        private void initContactInfo()
        {
            lock (this) { _contactInfo = new ClientContactInfo() { Client = this }; };
        }
        private ClientContactInfo getClientContactInfo()
        {
            if (ContactInfo == null) initContactInfo();
            return _contactInfo;
        }
        #endregion
        #endregion
    }
}
