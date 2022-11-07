using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PokemonAccedo.Models.Account;

namespace PokemonAccedo.Api.Data
{
    public class AplicationDbContext : IdentityDbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserIdentity> UserIdentity { get; set; }

    }
}
