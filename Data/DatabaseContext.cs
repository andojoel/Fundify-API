using Fundify_API.DataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fundify_API.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Wallet> WalletTable { get; set; } = null!;
        public DbSet<CryptoCurrency> CryptoCurrencyTable { get; set; } = null!;
    }
}
