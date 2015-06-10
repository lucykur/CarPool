using Nancy;

namespace CarPool.Modules
{
    public class CarPoolModule : NancyModule
    {
        public CarPoolModule()
        {
            Get["/"] = _ => View["home"];
            Get["/hello"] = _ => View["home"];
        }

     
    }
}