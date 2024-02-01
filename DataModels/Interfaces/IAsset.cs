using System.ComponentModel.DataAnnotations;

namespace Fundify_API.DataModels.Interfaces;
public interface IAsset : IOwnerChecker, IWalletChecker
{
    [Key]
    public string Id { get; init; }
    [Required]
    public string? Name { get; init; }
    [Required]
    public string? Symbol { get; init; }
    public decimal? Quantity { get; init; }
    public string? OwnerUsername { get; init; }
    public Guid? WalletId { get; init; }
    public AssetDto? ToAssetDto();
}
