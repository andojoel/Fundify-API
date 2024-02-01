namespace Fundify_API.DataModels
{
    public class AssetDto
    {
        public required string Id { get; set; }
        public string? Name { get; set; } = "";
        public string? Symbol { get; set; } = "";
        public decimal? Quantity { get; set; } = 0;
        public string? OwnerUsername { get; set; }
        public Guid? WalletId { get; set; }

        public Asset ToAssetDto()
        {
            return new Asset
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
}
