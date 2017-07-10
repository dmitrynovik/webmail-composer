using System;
using System.Collections.Generic;
using System.Diagnostics;
using RestSharp;

namespace Mailman
{
    public class CompositeMailman : IMailman
    {
        private readonly ICollection<IMailman> _senders;

        public CompositeMailman()
        {
            _senders = new List<IMailman>(new IMailman[] { new SendgridMailman(), new MailgunMailman() });
        }

        public CompositeMailman(params IMailman[] senders)
        {
            _senders = new List<IMailman>(senders.Length);
            foreach (var sender in senders)
            {
                _senders.Add(sender);
            }
        }

        public IRestResponse Send(Email e)
        {
            foreach (var sender in _senders)
            {
                try
                {
                    return sender.Send(e);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
            throw new AllServersDownException();
        }
    }
}
