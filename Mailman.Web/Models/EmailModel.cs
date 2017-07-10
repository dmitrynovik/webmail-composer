using System.ComponentModel.DataAnnotations;

namespace Mailman.Web.Models
{
    public class EmailModel
    {
        [EmailAddress]
        [Required]
        public string From { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$")]
        public string To { get; set; }

        [RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$")]
        public string Cc { get; set; }

        [RegularExpression(@"^([\w+-.%]+@[\w-.]+\.[A-Za-z]{2,4},?)+$")]
        public string Bcc { get; set; }

        public bool HasErrors { get; set; }
        public string Error { get; set; }
    }
}