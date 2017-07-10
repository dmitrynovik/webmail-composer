using System.Net;
using NUnit.Framework;

namespace Mailman.Test
{
    [TestFixture]
    public class CompositeMailmanTest
    {
        private readonly IMailman _bad = new FakeBadMailman();
        private readonly IMailman _good = new FakeGoodMailman();

        [Test]
        public void When_At_Least_One_Mailman_Is_Good_Result_Ok()
        {
            var composite = new CompositeMailman(_bad, _good);
            var result = composite.Send(Emails.ValidSingleRecipient);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public void When_All_Mailmen_Bad_Error()
        {
            var composite = new CompositeMailman(_bad, _bad);
            Assert.Throws<AllServersDownException>(() => composite.Send(Emails.ValidSingleRecipient));
        }
    }
}
