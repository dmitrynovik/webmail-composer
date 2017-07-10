using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Mailman
{
    public class SendgridEmail
    {
        public class Person
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Personalization
        {
            [JsonProperty("to")]
            public ICollection<Person> To { get; set; }

            [JsonProperty("cc")]
            public ICollection<Person> Cc { get; set; }

            [JsonProperty("bcc")]
            public ICollection<Person> Bcc { get; set; }

            [JsonProperty("subject")]
            public string Subject { get; set; }
        }

        public class Content
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        [JsonProperty("from")]
        public Person From { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("content")]
        public List<Content> Body { get; set; }

        [JsonProperty("personalizations")]
        public ICollection<Personalization> Personalizations { get; set; }

        public static explicit operator SendgridEmail(Email e)
        {
            return new SendgridEmail
            {
                Body = new List<Content>(new [] { new Content() { Type = "text/plain", Value = e.Body } }),
                Subject = e.Subject,
                From = new Person { Email = e.From },
                Personalizations = new[] 
                {
                    new Personalization
                    {
                        To = e.To != null && e.To.Any() ? e.To.Select(x => new Person { Email = x }).ToArray() : null,
                        Cc = e.Cc != null && e.Cc.Any() ? e.Cc.Select(x => new Person { Email = x }).ToArray() : null,
                        Bcc = e.Bcc != null && e.Bcc.Any() ? e.Bcc.Select(x => new Person { Email = x }).ToArray() : null
                    }
                }
            };
        }
    }
}
