using System.Net;
using NUnit.Framework;

namespace Mailman.Test
{
    [TestFixture]
    public class MailgunTest : MailmanTest
    {
        public override IMailman Mailman => new MailgunMailman();

        [Test]
        public void When_Email_Valid_Send_Ok() => Assert.AreEqual(HttpStatusCode.OK, ExecuteTest(Emails.ValidSingleRecipient).StatusCode);

        // Most of the tests are in the base class MailmanTest as they are the same
    }
}
