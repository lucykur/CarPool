using Nancy;

namespace CarPool.Modules
{
    public class CarPoolModule : NancyModule
    {
        public CarPoolModule()
        {
            Get["/"] = _ => View["index"];
            Get["/hello"] = _ => View["index"];
          
        }

     
    }
}