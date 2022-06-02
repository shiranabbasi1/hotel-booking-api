using HotelBookingApi.Config.Seed;
using HotelBookingApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace HotelBookingApi.Models
{
    public class ApplicationContext : DbContext
    {
        private readonly IFileServiceResolver _fileServiceResolver;
        private readonly SeedSettings _seedSettings;
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelFacility> HotelFacilities { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options,
            IFileServiceResolver fileServiceResolver,
            SeedSettings seedSettings) : base(options)
        {
            _fileServiceResolver = fileServiceResolver;
            _seedSettings = seedSettings;
        }

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

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            IFileService fileService = _fileServiceResolver.Resolve(_seedSettings.FileService);
            string seedJson = fileService.GetText(_seedSettings.FileName);

            JObject obj = JObject.Parse(seedJson);

            List<Country> countries = new List<Country>();
            List<City> cities = new List<City>();

            JObject locations = (JObject)(obj["locations"]);

            int i = 1;
            int j = 1;
            foreach (string countryName in locations.Properties().Select(x => x.Name))
            {
                countries.Add(new Country { Id = i, Name = countryName });
                JArray cityList = (JArray)(locations[countryName]);
                for (int k = 0; k < cityList.Count; k++)
                {
                    cities.Add(new City { Id = j, CountryId = i, Name = cityList[k].ToString() });
                    j++;
                }
                i++;
            }

            List<Facility> facilities = new List<Facility>();
            JArray facilityList = (JArray)(obj["facilities"]);
            for (i = 0; i < facilityList.Count; i++)
            {
                facilities.Add(new Facility { Id = (i + 1), Name = facilityList[i].ToString() });
            }

            builder.Entity<Country>()
                .HasData(countries);

            builder.Entity<City>()
                .HasData(cities);

            builder.Entity<Facility>()
                .HasData(facilities);
        }
    }
}
