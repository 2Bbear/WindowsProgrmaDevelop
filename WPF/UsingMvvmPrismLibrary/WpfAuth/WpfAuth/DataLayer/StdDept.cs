using System.ComponentModel.DataAnnotations;

namespace WpfAuth.DataLayer
{
    public class StdDept
    {
        [Key]
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string UpDeptId { get; set; }
    }
}
