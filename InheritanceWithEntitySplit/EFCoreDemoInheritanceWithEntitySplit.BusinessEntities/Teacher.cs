using System;
using EFCoreDemoInheritanceWithEntitySplit.BusinessEntities.Extension;

namespace EFCoreDemoInheritanceWithEntitySplit.BusinessEntities
{
    public partial class Teacher : User
    {
        #region using walk around to get the properties from internalStudent instance
        public string StaffCode
        {
            get { return getInternalTeacher().StaffCode; }
            set { getInternalTeacher().StaffCode = value; }
        }
        public int SalaryGrade
        {
            get { return getInternalTeacher().SalaryGrade; }
            set { getInternalTeacher().SalaryGrade = value; }
        }
        #endregion
        public Teacher() { }
        #region Using Lazy Loading to support Entity Split
        #region The LazyLoader Injection
        private Teacher(Action<object, string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private Action<object, string> _lazyLoader;
        #endregion

        #region internalTeacher Instance
        private InternalTeacher internalTeacher
        {
            get { return _lazyLoader.Load(this, ref _internalTeacher); }
            set { _internalTeacher = value; }
        }
        private InternalTeacher _internalTeacher;
        private void initInernalTeacher()
        {
            lock (this) { _internalTeacher = new InternalTeacher() { Teacher = this }; };
        }
        private InternalTeacher getInternalTeacher()
        {
            if (internalTeacher == null) initInernalTeacher();
            return _internalTeacher;
        }
        #endregion
        #endregion
    }
}
