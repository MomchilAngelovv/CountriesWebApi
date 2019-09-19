using Countries.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace Countries.Data
{
    public class CountriesDbContext : DbContext
    {
        public CountriesDbContext(DbContextOptions<CountriesDbContext> options)
            : base(options)
        {

        }

        public DbSet<AlternativeSpelling> AlternativeSpellings { get; set; }
        public DbSet<Border> Borders { get; set; }
        public DbSet<CallingCode> CallingCodes { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryBorder> CountryBorder { get; set; }
        public DbSet<CountryCurrency> CountryCurrency { get; set; }
        public DbSet<CountryLanguage> CountryLanguage { get; set; }
        public DbSet<CountryRegionalBlock> CountryRegionalBlock { get; set; }
        public DbSet<CountryTimeZone> CountryTimeZone { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<InternetDomain> InternetDomains { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<RegionalBlock> RegionalBlocks { get; set; }
        public DbSet<TimeZone> TimeZones { get; set; }
        public DbSet<Translations> Translations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryBorder>()
                .HasKey(e => new { e.CountryId, e.BorderId });

            modelBuilder.Entity<CountryCurrency>()
                .HasKey(e => new { e.CountryId, e.CurrencyId });

            modelBuilder.Entity<CountryLanguage>()
                .HasKey(e => new { e.CountryId, e.LanguageId });

            modelBuilder.Entity<CountryRegionalBlock>()
                .HasKey(e => new { e.CountryId, e.RegionalBlockId });

            modelBuilder.Entity<CountryTimeZone>()
                .HasKey(e => new { e.CountryId, e.TimeZoneId });
        }
    }
}
