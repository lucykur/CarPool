using Nancy;

namespace CarPool
{
    public class CarPoolModule : NancyModule
    {
        public CarPoolModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}