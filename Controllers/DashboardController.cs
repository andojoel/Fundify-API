using Carter;
using Fundify_API.Data;
using Fundify_API.DataModels;
using System.Security.Claims;

namespace Fundify_API.Controllers
{
    public class DashboardController : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/dashboard").RequireAuthorization();

            group.MapGet("/", GetDashboard);
        }

        // GET: DashboardController/Details/5
        public static IResult GetDashboard(
            DatabaseContext db,
            ClaimsPrincipal user
            )
        {
            var dashboard = new
            {
                username = user.Identity!.Name,
                wallets = new List<Wallet>()
            };

            var requestDto = RequestDto.Success("Done", dashboard);

            return Results.Ok(requestDto);
        }
    }
}
