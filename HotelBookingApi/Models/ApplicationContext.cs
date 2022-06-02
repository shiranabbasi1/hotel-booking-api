using Microsoft.EntityFrameworkCore;

namespace HotelBookingApi.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>()
                .HasMany<City>(x => x.Cities)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            builder.Entity<Hotel>()
                .HasOne<City>(x => x.City)
                .WithMany(x => x.Hotels)
                .HasForeignKey(x => x.CityId);

            builder.Entity<HotelFacility>()
                .HasKey(hf => new { hf.HotelId, hf.FacilityId });

            builder.Entity<HotelFacility>()
                .HasOne(x => x.Facility)
                .WithMany(x => x.HotelFacilities)
                .HasForeignKey(x => x.FacilityId);

            builder.Entity<HotelFacility>()
                .HasOne(x => x.Hotel)
                .WithMany(x => x.HotelFacilities)
                .HasForeignKey(x => x.HotelId);
        }
    }
}
