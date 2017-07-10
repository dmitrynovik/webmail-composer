using System;
using RestSharp;

namespace Mailman.Test
{
    class FakeBadMailman : IMailman
    {
        public IRestResponse Send(Email e)
        {
            throw new Exception("something went wrong");
        }
    }
}