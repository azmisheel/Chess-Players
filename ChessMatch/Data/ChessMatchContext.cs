using System.Numerics;
using Microsoft.EntityFrameworkCore;
using ChessMatch.Models;

namespace ChessMatch.Data
{
    public class ChessMatchContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public string UserName
        {
            get; private set;
        }

        public ChessMatchContext(DbContextOptions<ChessMatchContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            if (_httpContextAccessor.HttpContext != null)
            {
                //We have a HttpContext, but there might not be anyone Authenticated
                UserName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unknown";
            }
            else
            {
                //No HttpContext so seeding data
                UserName = "Seed Data";
            }
        }
        [ActivatorUtilitiesConstructor]
        public ChessMatchContext(DbContextOptions<ChessMatchContext> options)
            : base(options)
        {
            _httpContextAccessor = null!;
            UserName = "Seed Data";
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany<Player>(p => p.Players)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Country>()
                .HasIndex(p => p.Name)
                .IsUnique();

			modelBuilder.Entity<Player>()
				.HasIndex(p => p.Name)
				.IsUnique();

		}
    }
}
