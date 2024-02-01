using Carter;
using Fundify_API.DataModels;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using System.Security.Claims;
using System;
using Fundify_API.Data;

namespace Fundify_API.Endpoint
{
    public class WalletEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/wallet").RequireAuthorization();

            group.MapGet("", GetWallets);
        }

        public static IResult GetWallets(
            DatabaseContext db,
            ClaimsPrincipal user)
        {
            try
            {
                var wallets = db.WalletTable.Where(w => w.ownerUserName == user.Identity!.Name);
                return Results.Ok(RequestDto.Success("Done", wallets));
            }
            catch (Exception e)
            {
                return Results.BadRequest(RequestDto.Failed("Error matching data"));
            }
        }
    }
}
