namespace Fundify_API.DataModels;
public class CryptoCurrencyDto : AssetDto
{
    public decimal? CurrentPrice { get; set; } = 0;
    public decimal? MarketCap { get; set; } = 0;
    public int? MarketCapRank { get; set; } = 0;
    public decimal? PriceChange24h { get; set; }
    public double? PriceChangePercentage_24h { get; set; }
    public string? Image { get; set; } = "";

    public CryptoCurrency ToCryptoCurrencyDto()
    {
        return new CryptoCurrency
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
