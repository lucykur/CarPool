using Nancy;
using Nancy.Security;

namespace CarPool.Modules
{
    public class SecureModule: NancyModule
    {
        public SecureModule() : base("/secure")
        {
           this.RequiresAuthentication();
           Get["/"] = _ => View["index"];
        }
    }
}