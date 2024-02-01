using Carter;
using Fundify_API.Data;
using System.Security.Claims;

namespace Fundify_API.Controllers
{
    public class DashboardController : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/dashboard").RequireAuthorization();

            group.MapGet("", GetDashboard);
        }

        // GET: DashboardController/Details/5
        public static IResult GetDashboard(
            DatabaseContext db,
            ClaimsPrincipal user
            )
        {

            return Results.Ok($"Hello {user.Identity!.Name} !");
        }
    }
}
