namespace Fundify_API.DataModels;
public record CryptoCurrency : Asset
{
    public decimal? CurrentPrice { get; init; } = 0;
    public decimal? MarketCap { get; init; } = 0;
    public int? MarketCapRank { get; init; } = 0;
    public decimal? PriceChange24h { get; init; }
    public double? PriceChangePercentage_24h { get; init; }
    public string? Image { get; init; } = "";

    public CryptoCurrencyDto ToCryptoCurrencyDto()
    {
        return new CryptoCurrencyDto
        {
            Id = Id,
            WalletId = WalletId,
            CurrentPrice = CurrentPrice,
            MarketCap = MarketCap,
            MarketCapRank = MarketCapRank,
            PriceChange24h = PriceChange24h,
            PriceChangePercentage_24h = PriceChangePercentage_24h,
            Name = Name,
            Symbol = Symbol,
            Image = Image,
            Quantity = Quantity,
            OwnerUsername = OwnerUsername
        };
    }
}
