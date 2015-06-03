using CarPool.Models;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace CarPool.Modules
{
    public class AuthModule : NancyModule
    {
        private readonly AuthenticationService _authenticationService;

        public AuthModule(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

            Get["/login"] = LogIn;
            Post["/login"] = _ => AuthenticateUser();
        }

        private static dynamic LogIn(object arg)
        {
            return new LoginModel();
        }

        private Response AuthenticateUser()
        {
            var loginModel = this.Bind<LoginModel>();
            
            if (loginModel.Username == null || loginModel.Password == null) return HttpStatusCode.Unauthorized;

            var user = _authenticationService.Authenticate(loginModel.Username, loginModel.Password);

            return user != null ? this.LoginAndRedirect(user.Id) : HttpStatusCode.Unauthorized ;
        }
    }
}