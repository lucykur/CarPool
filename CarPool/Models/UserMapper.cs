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
            if (context.CurrentUser == null) return null;
            var user = _authenticationService.GetUserById(identifier);
            return new AuthenticatedUser
            {
                UserName = user.Username
            };
        }
    }
}