using System;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace Mailman
{ 
    public class SendgridMailman : Mailman
    {
        private readonly string _url, _user, _secret;

        public SendgridMailman(string url, string user, string secret)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
            if (string.IsNullOrWhiteSpace(user)) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(secret)) throw new ArgumentNullException(nameof(secret));

            _url = url;
            _user = user;
            _secret = secret;
        }

        public SendgridMailman() : this(ConfigurationManager.AppSettings["sendgrid.url"],
            ConfigurationManager.AppSettings["sendgrid.user"],
            ConfigurationManager.AppSettings["sendgrid.secret"]) { }

        public override IRestResponse Send(Email e)
        {
            Validate(e);

            var client = new RestClient { BaseUrl = new Uri(_url) };
            client.AddDefaultHeader("Authorization", $"Bearer {_secret}");
            client.AddDefaultHeader("Content-Type", "application/json");

            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };
            request.AddBody((SendgridEmail) e);
            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}
