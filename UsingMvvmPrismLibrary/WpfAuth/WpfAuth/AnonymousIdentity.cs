namespace WpfAuth
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() : base(string.Empty, string.Empty, string.Empty)
        {
        }
    }
}
