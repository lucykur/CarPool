using System.Collections.Generic;
using Nancy.Security;

namespace CarPool.Models
{
    public class AuthenticatedUser : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; private set; }
    }
}