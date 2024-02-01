namespace Fundify_API.DataModels;
public class WalletDto
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? OwnerUsername { get; set; }

    public Wallet ToWallet()
    {
        return new Wallet
        {
            Id = Id,
            Name = Name!,
            OwnerUsername = OwnerUsername
        };
    }
}
