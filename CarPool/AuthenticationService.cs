using System;
using System.Configuration;
using CarPool.Models;

namespace CarPool
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(string authServiceUri)
        {
            _httpClient = new HttpClient(authServiceUri);
        }

        public User Authenticate(string username, string password)
        {
            return _httpClient.GetAsync<User>(string.Format("/api/user?username={0}&password={1}", username, password));
        }

        public User GetUserById(Guid identifier)
        {
            return _httpClient.GetAsync<User>(string.Format("/api/user/{0}", identifier));
        }
    }
}