using System;
using System.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Mailman
{
    public class MailgunMailman : Mailman
    {
        private readonly string _url, _authHeader, _authSecret;

        public MailgunMailman(string url, string authHeader, string authSecret)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrWhiteSpace(authHeader)) throw new ArgumentNullException(nameof(authHeader));
            if (string.IsNullOrWhiteSpace(authSecret)) throw new ArgumentNullException(nameof(authSecret));

            _url = url;
            _authHeader = authHeader;
            _authSecret = authSecret;
        }

        public MailgunMailman() : this(ConfigurationManager.AppSettings["mailgun.url"],
            ConfigurationManager.AppSettings["mailgun.authHeader"],
            ConfigurationManager.AppSettings["mailgun.authSecret"]) {  }

        public override IRestResponse Send(Email e)
        {
            Validate(e);

            var client = new RestClient
            {
                BaseUrl = new Uri(_url),
                Authenticator = new HttpBasicAuthenticator(_authHeader, _authSecret)
            };

            var request = new RestRequest();
            request.AddParameter("domain", "sandbox6fffdad805c4466a929f80afd6405f22.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", e.From);
            request.AddParameter("to", string.Join(",", e.To));
            request.AddParameter("subject", e.Subject);
            request.AddParameter("text", e.Body);
            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}
