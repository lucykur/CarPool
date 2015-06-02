using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace CarPool.Models
{
    public class UserMapper: IUserMapper
    {
        private readonly AuthenticationService _authenticationService;

        public UserMapper(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var user = _authenticationService.GetUserById(identifier);
            if (user == null) return null;

            return new AuthenticatedUser
            {
                UserName = user.Username
            };
          
        }
    }
}