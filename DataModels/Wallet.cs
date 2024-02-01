using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Fundify_API.DataModels;
public class Wallet
{
    [Key]
    public required Guid? Id { get; set; }
    public required string Name { get; set; }
    public string? OwnerUsername { get; set; }

    public WalletDto ToWalletDto()
    {
        return new WalletDto
        {
            Id = Id,
            Name = Name,
            OwnerUsername = OwnerUsername
        };
    }
}
