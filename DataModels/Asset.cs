using Fundify_API.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fundify_API.DataModels;
public record Asset : IAsset
{
    [Key]
    public required string Id { get; init; }
    [Required]
    public string? Name { get; init; } = "";
    [Required]
    public string? Symbol { get; init; } = "";
    public decimal? Quantity { get; init; } = 0;
    public string? OwnerUsername { get; init; }
    public Guid? WalletId { get; init; }

    public bool CheckOwner(string? username)
    {
        return username == OwnerUsername;
    }

    public bool CheckWalletId(Guid guid)
    {
        return guid == WalletId;
    }

    public AssetDto ToAssetDto()
    {
        return new AssetDto
        {
            Id = Id,
            Name = Name,
            Symbol = Symbol,
            Quantity = Quantity,
            OwnerUsername = OwnerUsername,
            WalletId = WalletId
        };
    }
}
