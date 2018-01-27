using System.Net.Mail;
using System.Threading.Tasks;

namespace CommunicationDevices.ExchangeBehavior.Http
{
    public class HttpBaseExchangeBehavior
    {
        public async Task<bool> Send(string message)
        {
            return false;
        }
    }
}