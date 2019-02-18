using System.ComponentModel.DataAnnotations;

namespace WpfAuth.DataLayer
{
    public class StdUser
    {
        [Key]
        public string User_id { get; set; }
        public string User_Pw { get; set; }
        public string Group_Name { get; set; }
        public string User_Name { get; set; }
        public string E_Mail { get; set; }
        public string Description { get; set; }
    }
}
