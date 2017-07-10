using System.Collections.Generic;

namespace Mailman.Test
{
    public static class Emails
    {
        public static Email ValidSingleRecipient => new Email()
        {
            From = "dmitry.novik@gmail.com", To = new[] {"cryinstone@gmail.com"}, Subject = "Hi there!", Body = " ... some text ..."
        };

        public static Email InvalidSender
        {
            get
            {
                var email = ValidSingleRecipient;
                email.From = "abc";
                return email;
            }
        }

        public static Email EmptySender
        {
            get
            {
                var email = ValidSingleRecipient;
                email.From = " ";
                return email;
            }
        }

        public static Email NullSender
        {
            get
            {
                var email = ValidSingleRecipient;
                email.From = null;
                return email;
            }
        }

        public static Email InvalidRecipient
        {
            get
            {
                var email = ValidSingleRecipient;
                email.To = new[] { "abc" };
                return email;
            }
        }

        public static Email EmptyRecipient
        {
            get
            {
                var email = ValidSingleRecipient;
                email.To = new List<string>();
                return email;
            }
        }

        public static Email NullRecipient
        {
            get
            {
                var email = ValidSingleRecipient;
                email.To = null;
                return email;
            }
        }

        public static Email InvalidCc
        {
            get
            {
                var email = ValidSingleRecipient;
                email.Cc = new[] { "ccc" };
                return email;
            }
        }

        public static Email InvalidBcc
        {
            get
            {
                var email = ValidSingleRecipient;
                email.Bcc = new[] { "ccc" };
                return email;
            }
        }
    }
}
