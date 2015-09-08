using Nancy;

namespace SmartFlow.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => Response.AsRedirect("/smartflow");
        }
    }
}