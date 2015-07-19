using System;
using CarPool;
using CarPool.Models;

namespace Carpool.Tests.ServiceStubs
{
    public class AuthenticationServiceStub : IAuthenticationService
    {
        public User Authenticate(string username, string password)
        {
            if (username == "demo" && password == "demo")
                return new User {Id = Guid.NewGuid(), Username = username};
            return null;
        }

        public User GetUserById(Guid identifier)
        {
            throw new NotImplementedException();
        }
    }
}