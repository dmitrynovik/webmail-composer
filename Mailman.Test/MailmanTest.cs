using System;
using NUnit.Framework;
using RestSharp;

namespace Mailman.Test
{
    public abstract class MailmanTest
    {
        public abstract IMailman Mailman { get; }

        protected IRestResponse ExecuteTest(Email e)
        {
            var response = Mailman.Send(e);
            Console.WriteLine(response.Content);
            return response;
        }

        [Test]
        public void When_Sender_Empty_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.EmptySender));

        [Test]
        public void When_Sender_Null_Exception_Thrown() => Assert.Throws<ArgumentNullException>(() => ExecuteTest(Emails.NullSender));

        [Test]
        public void When_Sender_Invalid_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.InvalidSender));

        [Test]
        public void When_Recipient_Empty_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.EmptyRecipient));

        [Test]
        public void When_Recipient_Null_Exception_Thrown() => Assert.Throws<ArgumentNullException>(() => ExecuteTest(Emails.NullRecipient));

        [Test]
        public void When_Recipient_Invalid_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.InvalidRecipient));

        [Test]
        public void When_Cc_Invalid_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.InvalidCc));

        [Test]
        public void When_Bcc_Invalid_Exception_Thrown() => Assert.Throws<InvalidEmailException>(() => ExecuteTest(Emails.InvalidBcc));
    }
}