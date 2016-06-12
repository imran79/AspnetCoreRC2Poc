using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace AspnetCoreRC2Poc.RouteSample
{

    public class HelloRoute : Microsoft.AspNetCore.Routing.IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }

        public Task RouteAsync(RouteContext context)
        {
            var name = context.RouteData.Values["name"] as string;
            if (String.IsNullOrEmpty(name))
            {
                return Task.FromResult(0);
            }
            var requestPath = context.HttpContext.Request.Path;
            if (requestPath.StartsWithSegments("/Hello", StringComparison.OrdinalIgnoreCase))
            {
                context.Handler = async c =>
                {
                    await c.Response.WriteAsync($"Hi, {name}!");
                };
            }
            return Task.FromResult(0);
        }
    }

   public static class ReqeustBuilderExtensions
    {
        public static IRouteBuilder AddHelloRoute(this IRouteBuilder routeBuilder,
            IApplicationBuilder app)
        {
            routeBuilder.Routes.Add(new Route(new HelloRoute(),
                "hello/{name:alpha}", 
                app.ApplicationServices.GetService<IInlineConstraintResolver>()));

            return routeBuilder;
        }
    }

}