using AspnetCoreRC2Poc.RouteSample;
using Microsoft.AspNetCore.Routing;
namespace AspnetCoreRC2Poc.Middleware
{
    public class RouteMiddleware
    {
        private readonly RouteHandler _next;
        private readonly HelloRoute helloRoute;
        public  RouteMiddleware(RouteHandler next, HelloRoute route){
           _next = next;
        }

    }
}