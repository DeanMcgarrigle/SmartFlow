using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using SmartFlow.Entity;

namespace SmartFlow.DataAccess
{
    public class SmartFlowContext : DbContext
    {
        public SmartFlowContext()
            : base(@"

Data Source=172.17.61.10;
Database=SmartFlow;
User Id=sa;
Password=mha405741

")
        {
            Database.CommandTimeout = 360;
        }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<FloorLocation> FloorLocations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FloorConfig> FloorConfigs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccessPointConfig> AccessPointConfigs { get; set; }
        public DbSet<DashboardConfig> DashboardConfigs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(SmartFlowContext).Assembly);
        }
    }

    public class AccessPointConfigConfiguration : EntityTypeConfiguration<AccessPointConfig>
    {
        public AccessPointConfigConfiguration()
        {
            HasKey(x => new { x.ApMac, x.Name });
        }
    }

    public class DashboardConfigConfiguration : EntityTypeConfiguration<DashboardConfig>
    {
        public DashboardConfigConfiguration()
        {
            HasKey(x => x.RecordId);
            Property(x => x.RecordId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.RecordId);
            Property(x => x.RecordId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    public class FloorConfigConfiguration : EntityTypeConfiguration<FloorConfig>
    {
        public FloorConfigConfiguration()
        {
            HasKey(x => x.Name);
        }
    }

    public class FloorConfiguration : EntityTypeConfiguration<Floor>
    {
        public FloorConfiguration()
        {
            HasKey(x => new { x.Name, x.ApMac });
            HasMany(x => x.FloorLocations).WithRequired(x => x.Floor).HasForeignKey(x => new { x.Name, x.ApMac }).WillCascadeOnDelete(true);
        }
    }

    public class ObservationConfiguration : EntityTypeConfiguration<Observation>
    {
        public ObservationConfiguration()
        {
            HasKey(x => x.RecordId);
            Property(x => x.RecordId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ClientMac).HasMaxLength(128);
            HasRequired(x => x.Location).WithRequiredPrincipal(x => x.Observation).WillCascadeOnDelete(true);
        }
    }

    public class LocationConfiguration : EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            HasKey(x => x.RecordId);
            HasMany(x => x.FloorLocations).WithRequired(x => x.Location).HasForeignKey(x => x.LocationRecordId).WillCascadeOnDelete(true);
        }
    }

    public class FloorLocationConfiguration : EntityTypeConfiguration<FloorLocation>
    {
        public FloorLocationConfiguration()
        {
            HasKey(x => new { x.Name, x.ApMac, x.LocationRecordId });
        }
    }
}