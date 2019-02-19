using System;
using EFCoreDemoInheritanceWithEntitySplit.BusinessEntities.Extension;

namespace EFCoreDemoInheritanceWithEntitySplit.BusinessEntities
{
    public partial class Student : User
    {
        #region using walk around to get the properties from internalStudent instance
        public string StudentCode
        {
            get { return getInternalStudent().StudentCode; }
            set { getInternalStudent().StudentCode = value; }
        }
        public int GradeLevel
        {
            get { return getInternalStudent().GradeLevel; }
            set { getInternalStudent().GradeLevel = value; }
        }
        #endregion
        public Student() { }
        #region Using Lazy Loading to support Entity Split
        #region The LazyLoader Injection
        private Student(Action<object, string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }
        private Action<object, string> _lazyLoader;
        #endregion

        #region internalStudent Instance
        private InternalStudent internalStudent
        {
            get { return _lazyLoader.Load(this, ref _internalStudent); }
            set { _internalStudent = value; }
        }
        private InternalStudent _internalStudent;
        private void initInernalStudent()
        {
            lock (this) { _internalStudent = new InternalStudent() { Student = this }; };
        }
        private InternalStudent getInternalStudent()
        {
            if (internalStudent == null) initInernalStudent();
            return _internalStudent;
        }
        #endregion
        #endregion
    }
}
