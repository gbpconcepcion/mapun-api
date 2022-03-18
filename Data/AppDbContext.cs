using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using mapun_api.Models.Entities;

namespace mapun_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> USERS { get; set; }

        public DbSet<mapunRole> ROLES { get; set; }

        public DbSet<Zone> ZONES { get; set; }

        public DbSet<Property> PROPERTIES { get; set; }

        public DbSet<PropertyLog> PLOGS { get; set; }

        public DbSet<PropertyStatus> PSTATUSES { get; set; }

        public DbSet<PropertyEnhancement> PENHANCEMENTS { get; set; }


        public DbSet<BaseRate> BRATES { get; set; }

        public DbSet<MiscRate> MRATES { get; set; }

        public DbSet<ZoneRate> ZRATES { get; set; }

        public DbSet<EnhancementRate> ERATES { get; set; }

        public DbSet<Payment> PAYMENTS { get; set; }

        public DbSet<PaymentStatus> PAYSTATUSES { get; set; }

        public DbSet<Assessment> ASSESSMENTS { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("mapun");

            modelBuilder
                .Entity<User>()
                .Property(u => u.USER_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<mapunRole>()
                .Property(u => u.ROLE_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<Zone>()
                .Property(u => u.ZONE_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<ZoneRate>()
                .Property(u => u.ZRATE_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<Property>()
                .Property(u => u.PROPERTY_ID)
                .HasDefaultValueSql("newsequentialid()");


            modelBuilder
                .Entity<PropertyLog>()
                .Property(u => u.PLOG_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<PropertyStatus>()
                .Property(u => u.PSTATUS_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<PropertyEnhancement>()
                .Property(u => u.PENHANCEMENT_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<EnhancementRate>()
                .Property(u => u.ERATE_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<BaseRate>()
                .Property(u => u.BRATE_ID)
                .HasDefaultValueSql("newsequentialid()");


            modelBuilder
                .Entity<MiscRate>()
                .Property(u => u.MRATE_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<PaymentStatus>()
                .Property(u => u.PAYSTATUS_ID)
                .HasDefaultValueSql("newsequentialid()");



            modelBuilder
                .Entity<Assessment>()
                .Property(u => u.ASSESSMENT_ID)
                .HasDefaultValueSql("newsequentialid()");

            modelBuilder
                .Entity<User>()
                .HasOne(u => u.ROLE)
                .WithMany(u => u.USERS)
                .HasForeignKey(u => u.ROLE_ID);

            modelBuilder
                .Entity<User>()
                .HasOne(u => u.ROLE)
                .WithMany(u => u.USERS)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder
                .Entity<Zone>()
                .HasOne(u => u.ZRATE)
                .WithMany(u => u.AFFECTED_ZONES)
                .HasForeignKey(u => u.ZONE_ID);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.ZONE)
                .WithMany(u => u.PROPERTIES)
                .HasForeignKey(u => u.ZONE_ID);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.ZONE)
                .WithMany(u => u.PROPERTIES)
                .OnDelete(DeleteBehavior.ClientNoAction);



            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.PSTATUS)
                .WithMany(u => u.PROPERTIES)
                .HasForeignKey(u => u.PSTATUS_ID);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.PSTATUS)
                .WithMany(u => u.PROPERTIES)
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.ENHANCEMENT)
                .WithMany(u => u.PROPERTIES)
                .HasForeignKey(u => u.PEHANCEMENT_ID);


            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.ENHANCEMENT)
                .WithMany(u => u.PROPERTIES)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.BRATE)
                .WithMany(u => u.AFFECTED_PROPERTIES)
                .HasForeignKey(u => u.BRATE_ID);


            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.BRATE)
                .WithMany(u => u.AFFECTED_PROPERTIES)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.MRATE)
                .WithMany(u => u.AFFECTED_PROPERTIES)
                .HasForeignKey(u => u.MRATE_ID);

            modelBuilder
                .Entity<Property>()
                .HasOne(u => u.MRATE)
                .WithMany(u => u.AFFECTED_PROPERTIES)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder
                .Entity<PropertyEnhancement>()
                .HasOne(u => u.ERATE)
                .WithMany(u => u.AFFECTED_TYPES)
                .HasForeignKey(u => u.ERATE_ID);

            modelBuilder
                .Entity<PropertyLog>()
                .HasOne(u => u.PROPERTY)
                .WithMany(u => u.HISTORY)
                .HasForeignKey(u => u.PROPERTY_ID);

            modelBuilder
                .Entity<PropertyLog>()
                .HasOne(u => u.USER)
                .WithMany(u => u.HISTORY)
                .HasForeignKey(u => u.USER_ID);

            modelBuilder
                .Entity<PropertyLog>()
                .HasOne(u => u.USER)
                .WithMany(u => u.HISTORY)
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder
                .Entity<Payment>()
                .HasOne(u => u.PROPERTY)
                .WithMany(u => u.PAYMENT_HISTORY)
                .HasForeignKey(u => u.PROPERTY_ID);

            modelBuilder
                .Entity<Payment>()
                .HasOne(u => u.PAYSTATUS)
                .WithMany(u => u.PAYMENTS)
                .HasForeignKey(u => u.PAYSTATUS_ID);

            modelBuilder
                .Entity<Payment>()
                .HasOne(u => u.PAYSTATUS)
                .WithMany(u => u.PAYMENTS)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder
                .Entity<Assessment>()
                .HasOne(u => u.PROPERTY)
                .WithMany(u => u.ASSESSMENTS)
                .HasForeignKey(u => u.PROPERTY_ID);


            modelBuilder
                .Entity<User>()
                .HasMany(p => p.PROPERTIES)
                .WithMany(p => p.ASSESSORS);

            modelBuilder
                .Entity<Property>()
                .HasMany(p => p.ASSESSORS)
                .WithMany(p => p.PROPERTIES);






        }

        public Task<int> SaveSessionChangesAsync(CancellationToken cancellationToken = new(), Guid user = new())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("UPDATED_BY").CurrentValue = user;
                entityEntry.Property("DATE_UPDATED").CurrentValue = Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime());

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CREATED_BY").CurrentValue = user;
                    entityEntry.Property("DATE_CREATED").CurrentValue = Instant.FromDateTimeUtc(DateTime.Now.ToUniversalTime());
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}