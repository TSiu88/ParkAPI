using Microsoft.EntityFrameworkCore;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public ParkApiContext(DbContextOptions<ParkApiContext> options)
        : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }
    public DbSet<State> States { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<State>()
      .HasData(
        new State { StateId = 1, Name = "California", NumberParks = 4},
        new State { StateId = 2, Name = "Washington", NumberParks = 3},
        new State { StateId = 3, Name = "Wyoming", NumberParks = 1},
        new State { StateId = 4, Name = "Hawaii", NumberParks = 1}
      );

      builder.Entity<Park>()
      .HasData(
        new Park { ParkId = 1, Name = "Redwood National Park", Type = "national", Description = "Forest of Redwooods", Location = "Del Norte", StateId = 1},
        new Park { ParkId = 2, Name = "Pinnacles National Park", Type = "national", Description = "Rock Monaliths", Location = "Salinas Valley", StateId = 1},
        new Park { ParkId = 3, Name = "Sequoia National Park", Type = "national", Description = "Forest of Sequoias", Location = "Visalia", StateId = 1},
        new Park { ParkId = 4, Name = "Mount Diablo State Park", Type = "state", Description = "Mountain of Diablo Range", Location = "Contra Costa", StateId = 1},
        new Park { ParkId = 5, Name = "Olympic National Park", Type = "national", Description = "Many ecosystems", Location = "Olympic Penninsula", StateId = 2},
        new Park { ParkId = 6, Name = "Mount Pilchuck State Park", Type = "state", Description = "Cascades Mountain", Location = "Snohomish County", StateId = 2},
        new Park { ParkId = 7, Name = "Yellowstone National Park", Type = "national", Description = "First national park", Location = "Wyoming, Montana, Idaho", StateId = 3},
        new Park { ParkId = 8, Name = "Waianapanapa State Park", Type = "state", Description = "Tide pools, caves, water tubes", Location = "Maui", StateId = 4},
        new Park { ParkId = 9, Name = "Lake Wenatchee State Park", Type = "state", Description = "Recreational activities, camping", Location = "Leavenworth", StateId = 2}
      );
    }
  }
}