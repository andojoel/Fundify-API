using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Fundify_API.Endpoint
{
    public class ServerEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/server").RequireAuthorization();

            group.MapGet("/ping", () => Results.Ok("Hello from the server !"));
        }
    }
}
