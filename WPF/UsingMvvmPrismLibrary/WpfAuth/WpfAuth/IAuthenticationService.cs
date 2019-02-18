using System;
using System.Linq;
using WpfAuth.DataLayer;

namespace WpfAuth
{
    public interface IAuthenticationService
    {
        UserInfo AuthenticateUser(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        public UserInfo AuthenticateUser(string username, string clearTextPassword)
        {
            WpfAuthDbContext db = new WpfAuthDbContext();
            string lshashedPwd = EncryptionService.Encrypt(clearTextPassword);

            StdUser _user = db.StdUsers.Where(x => x.User_id.Equals(username) && x.User_Pw.Equals(lshashedPwd)).FirstOrDefault();

            if (_user == null)
                throw new UnauthorizedAccessException("사용 권한이 없습니다. 관리자에게 문의하세요.");

            var _userDept = (from ud in db.UserDepts
                             join dept in db.Depts on ud.DeptId equals dept.DeptId
                             select new { UserId = ud.UserId, DeptId = dept.DeptId }).FirstOrDefault();

            var _userRole = (from us in db.UserRoles
                             join role in db.Roles on us.RoleId equals role.RoleId
                             select new { UserId = us.UserId, RoleId = role.RoleName }).FirstOrDefault();

            UserInfo _userInfo = new UserInfo()
            {
                User_id = _user.User_id,
                RoleId = _userRole?.RoleId,
                DeptId = _userDept?.DeptId
            };

            return _userInfo;
        }

    }


}
