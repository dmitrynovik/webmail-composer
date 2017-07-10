using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RestSharp;

namespace Mailman
{
    public abstract class Mailman : IMailman
    {
        public abstract IRestResponse Send(Email e);

        protected void Validate(Email e)
        {
            if (e == null) throw new ArgumentNullException(nameof(e));

            if (string.IsNullOrWhiteSpace(e.Subject) && string.IsNullOrWhiteSpace(e.Body))
                throw new InvalidEmailException("Both email subject and body are ampty.");

            if (!IsValidEmail(e.From)) throw new InvalidEmailException($"From: {e.From} is not a valid email.");
            if (!e.To.Any() && !e.Cc.Any() && !e.Bcc.Any()) throw new InvalidEmailException("No recipients supplied.");

            CheckEmails("To", e.To);
            CheckEmails("Cc", e.Cc);
            CheckEmails("Bcc", e.Bcc);
        }

        private static void CheckEmails(string field, IEnumerable<string> emails)
        {
            var invalid = GetInvalidEmail(emails);
            if (invalid != null)
                throw new InvalidEmailException($"{field}: Email {invalid} is not a valid email.");
        }

        private static string GetInvalidEmail(IEnumerable<string> emails) => emails.FirstOrDefault(e => !IsValidEmail(e));

        private static bool IsValidEmail(string email) =>
            Regex.IsMatch(email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);

    }
}