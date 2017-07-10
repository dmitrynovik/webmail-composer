using System.Net;
using Moq;
using RestSharp;

namespace Mailman.Test
{
    class FakeGoodMailman : IMailman
    {
        public IRestResponse Send(Email e)
        {
            var moq = new Mock<IRestResponse>();
            moq.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);
            return moq.Object;
        }
    }
}
