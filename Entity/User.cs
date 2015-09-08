using System;
using System.Collections.Generic;
using Nancy.Security;

namespace SmartFlow.Entity
{
    public class User : IUserIdentity
    {
        public Guid RecordId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}