using Microsoft.EntityFrameworkCore;
using TimeTracker.Model;



namespace TimeTracker.Contexts

{

    public class TrackerDbContext : DbContext

    {

        public TrackerDbContext()

        {

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }
        public DbSet<TimeRecord> TimeRecords { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            string dbTimeTrackerConnString = "User ID=localttuser01;Password=Something@1234;Host=localhost;Port=5432;Database=localtimetrackerdb;Connection Lifetime=0;";

            optionsBuilder.UseNpgsql(dbTimeTrackerConnString);

        }

    }

}