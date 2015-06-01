using System;
using Nancy;

namespace AuthenticationService
{
    public class AuthModule :NancyModule
    {
        private readonly UserRepository _userRepository;

        public AuthModule(UserRepository userRepository): base("api")
        {
            _userRepository = userRepository;

            Get["/user"] = _ => AuthenticateUser();
            Get["/user/{id}"] = _ => GetUser(_.id);
        }

        private Response GetUser(Guid id)
        {
            var user = _userRepository.GetById(id);

            return user == null ? HttpStatusCode.NotFound : Response.AsJson(user);
        }

        private Response AuthenticateUser()
        {
            string username = Request.Query["username"];
            string password = Request.Query["password"];
            var user = _userRepository.Get(username, password);

            return user == null ? HttpStatusCode.NotFound : Response.AsJson(user);
        }
    }
}