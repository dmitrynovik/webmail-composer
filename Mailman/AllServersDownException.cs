using System;

namespace Mailman
{
    public class AllServersDownException : ApplicationException
    {
        public AllServersDownException() : base("All mail servers are down.") {  }
    }
}