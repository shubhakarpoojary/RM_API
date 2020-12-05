using System.Net.Mail;

namespace WServices.Controllers
{
    internal class mailaddress : MailAddress
    {
        public mailaddress(string address) : base(address)
        {
        }
    }
}