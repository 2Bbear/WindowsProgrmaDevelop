using System.Security.Principal;

namespace WpfAuth
{
    public class CustomIdentity : IIdentity
    {
        //public CustomIdentity(string name, string email, string[] roles)
        public CustomIdentity(string name, string roles, string dept)
        {
            Name = name;
            Email = null;
            Roles = roles;
            Dept = dept;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Roles { get; private set; }
        public string Dept { get; private set; }

        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
    }
}
