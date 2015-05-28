using Nancy;

namespace CarPool
{
    public class CarPoolModule : NancyModule
    {
        public CarPoolModule()
        {
            Get["/"] = _ => View["templates/app"];
            Get["/hello"] = _ => View["templates/app"];
        }

     
    }
}