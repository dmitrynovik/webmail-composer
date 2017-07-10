using RestSharp;

namespace Mailman
{
    public interface IMailman
    {
        IRestResponse Send(Email e);
    }
}
