using System.Net;
using NUnit.Framework;

namespace Mailman.Test
{
    [TestFixture]
    public class SendgridTest : MailmanTest
    {
        public override IMailman Mailman  => new SendgridMailman();

        [Test]
        public void When_Email_Valid_Send_Accepted() => Assert.AreEqual(HttpStatusCode.Accepted, ExecuteTest(Emails.ValidSingleRecipient).StatusCode);

        // Most of the tests are in the base class MailmanTest as they are the same
    }
}
