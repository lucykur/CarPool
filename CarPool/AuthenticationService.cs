using System;
using CarPool.Models;

namespace CarPool
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpclient;

        public AuthenticationService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public User Authenticate(string username, string password)
        {
            return _httpclient.GetAsync<User>(string.Format("/api/user?username={0}&password={1}", username, password));
        }

        public User GetUserById(Guid identifier)
        {
            return _httpclient.GetAsync<User>(string.Format("/api/user/{0}", identifier));
        }
    }
}