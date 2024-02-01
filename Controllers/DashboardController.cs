using Carter;
using Fundify_API.Data;

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
            DatabaseContext db
            )
        {
            return TypedResults.Ok("Ok");
        }
    }
}
