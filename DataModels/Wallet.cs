using System.ComponentModel.DataAnnotations;

namespace Fundify_API.DataModels;
public class Wallet
{
    [Key]
    public required Guid id { get; set; }
    public required string name { get; set; }
    public string? ownerUserName { get; set; }
}
