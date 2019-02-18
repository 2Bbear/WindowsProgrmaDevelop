using System.ComponentModel.DataAnnotations;

namespace WpfAuth.DataLayer
{
    public class StdRole
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string UpRoleId { get; set; }
    }
}
