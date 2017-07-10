using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mailman
{
    public class Email
    {
        public Email()
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();
        }

        [EmailAddress]
        [Required]
        public string From { get; set; }

        public ICollection<string> To { get; set; }

        public ICollection<string> Cc { get; set; }

        public ICollection<string> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

    }
}
