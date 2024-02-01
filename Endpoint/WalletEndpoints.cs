using Carter;
using Microsoft.AspNetCore.Mvc;

namespace Fundify_API.Endpoint
{
    public class WalletEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/wallet").RequireAuthorization();

            group.MapGet("", () => Results.Ok("You get your wallet"));
        }
    }
}
