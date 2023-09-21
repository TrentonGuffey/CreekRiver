using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7},
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Tentrr", ImageUrl="https://hips.hearstapps.com/hmg-prod/images/pmx070118summercamping-005-1529681336.jpg?resize=1200:*"},
            new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Cozy Acre", ImageUrl="https://camperreport.com/wp-content/uploads/2021/03/MinutemanCG-1024x576.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Bush Style", ImageUrl="https://i.pinimg.com/564x/9f/67/53/9f67535d9b23437e36c83e8827ea4fda.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 4, Nickname = "Mountain Side", ImageUrl="https://blog-assets.thedyrt.com/uploads/2019/07/hammock-camper-view.jpg"},
            new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "River Run", ImageUrl="https://content.artofmanliness.com/uploads/2016/07/hammock.jpg"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Trenton", LastName = "Guffey", Email = "trenton.guffey@gmail.com"},
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate = new DateTime(2023, 09, 28), CheckoutDate = new DateTime(2023, 10, 01)},
        });
    }
}
