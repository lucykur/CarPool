using Nancy;

namespace CarPool
{
    public class CarPoolModule : NancyModule
    {
        public CarPoolModule()
        {
            Get["/"] = _ => View["Content/templates/app"];
            Get["/hello"] = _ => View["Content/templates/app"];
        }

     
    }
}