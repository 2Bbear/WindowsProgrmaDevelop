using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using WpfAuth.DataLayer;

namespace WpfAuth.ViewModel
{
    class AddUserViewModel : BindableBase
    {
        public AddUserViewModel()
        {
            SubmitCommand = new DelegateCommand(OnSubmitCommand, CanExec);
            CurrentUser = new UserInfo();
            LoadView();
        }

        private bool CanExec(object obj)
        {
            return true;
        }

        private void OnSubmitCommand(object obj)
        {
            AddUserViewModel tmp = obj as AddUserViewModel;
            tmp.CurrentUser.User_Pw = EncryptionService.Encrypt(tmp.CurrentUser.User_Pw);

            StdUser stdUser = new StdUser()
            {
                User_id = tmp.CurrentUser.User_id,
                User_Pw = tmp.CurrentUser.User_Pw
            };

            StdUserRole stdUserRole = new StdUserRole()
            {
                UserId = tmp.CurrentUser.User_id,
                RoleId = tmp.SelectedRole.RoleId
            };

            StdUserDept stdUserDept = new StdUserDept()
            {
                UserId = tmp.CurrentUser.User_id,
                DeptId = tmp.SelectedDept.DeptId
            };

            WpfAuthDbContext db = new WpfAuthDbContext();
            db.StdUsers.Add(stdUser);
            db.UserRoles.Add(stdUserRole);
            db.UserDepts.Add(stdUserDept);
            db.SaveChanges();
        }

        public void LoadView()
        {
            WpfAuthDbContext db = new WpfAuthDbContext();

            StdDepts = db.Depts.ToList();
            Roles = db.Roles.ToList();
        }

        private UserInfo _currentUser;

        public UserInfo CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

        public DelegateCommand SubmitCommand { get; private set; }

        private List<StdDept> _stdDepts;

        public List<StdDept> StdDepts
        {
            get { return _stdDepts; }
            set { SetProperty(ref _stdDepts, value); }
        }

        private StdDept _selectedDept;

        public StdDept SelectedDept
        {
            get { return _selectedDept; }
            set { SetProperty(ref _selectedDept, value); }
        }

        private List<StdRole> _roles;

        public List<StdRole> Roles
        {
            get { return _roles; }
            set { SetProperty(ref _roles, value); }
        }

        private StdRole _selectedRole;

        public StdRole SelectedRole
        {
            get { return _selectedRole; }
            set { SetProperty(ref _selectedRole, value); }
        }

    }
}
