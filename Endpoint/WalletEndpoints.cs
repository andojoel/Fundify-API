using Carter;
using Fundify_API.DataModels;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Crypto;
using System.Security.Claims;
using System;
using Fundify_API.Data;
using Google.Protobuf.WellKnownTypes;

namespace Fundify_API.Endpoint;
public class WalletEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/wallets").RequireAuthorization();

        group.MapGet("", GetWallets);
        group.MapPost("create", CreateWallet);
        group.MapPut("updateName", UpdateWalletName);
        group.MapDelete("delete/{wallet_id}", DeleteWallet);
    }

    public static IResult GetWallets(
        DatabaseContext db,
        ClaimsPrincipal user)
    {
        try
        {
            var wallets = db.WalletTable.Where(w => w.OwnerUsername == user.Identity!.Name);
            return Results.Ok(RequestDto.Success("Done", wallets));
        }
        catch (Exception e)
        {
            return Results.BadRequest(RequestDto.Failed(e.Message));
        }
    }

    public static async Task<IResult> CreateWallet(
        DatabaseContext db,
        [FromQuery] string name,
        ClaimsPrincipal user)
    {
        try
        {
            Wallet _wallet = new Wallet()
            {
                Id = new Guid(),
                Name = string.IsNullOrEmpty(name) ? "My Wallet" : name,
                OwnerUsername = user.Identity!.Name
            };

            await db.WalletTable.AddAsync(_wallet);
            await db.SaveChangesAsync();
            return Results.Ok(RequestDto.Success("Done", _wallet.ToWalletDto()));
        }
        catch (Exception e)
        {
            return Results.BadRequest(RequestDto.Failed(e.Message));
        }

    }

    public static async Task<IResult> UpdateWalletName(
        DatabaseContext db,
        [FromBody] WalletDto wallet,
        ClaimsPrincipal user)
    {
        try
        {
            Wallet _wallet = 
                db.WalletTable.First(w => w.Id == wallet.Id && w.OwnerUsername == user.Identity!.Name
                );

            _wallet.Name = string.IsNullOrEmpty(wallet.Name) ? "My Wallet" : wallet.Name;

            db.Entry(_wallet).CurrentValues.SetValues(_wallet);
            // db.WalletTable.Update(_wallet);
            await db.SaveChangesAsync();
            return Results.Ok(RequestDto.Success("Done", _wallet.ToWalletDto()));
        }
        catch (Exception e)
        {
            return Results.BadRequest(RequestDto.Failed(e.Message));
        }
    }

    public static async Task<IResult> DeleteWallet(
        DatabaseContext db,
        Guid wallet_id,
        ClaimsPrincipal user)
    {
        try
        {
            Wallet _wallet = 
                db.WalletTable.First(w => w.Id == wallet_id && w.OwnerUsername == user.Identity!.Name
                );

            db.WalletTable.Remove(_wallet);
            await db.SaveChangesAsync();
            return Results.Ok(RequestDto.Success("Done", _wallet.ToWalletDto()));
        }
        catch (Exception e)
        {
            return Results.BadRequest(RequestDto.Failed(e.Message));
        }
    }
}
