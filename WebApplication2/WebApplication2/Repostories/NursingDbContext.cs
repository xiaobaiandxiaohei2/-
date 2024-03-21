using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApplication2.Model.Entity;

namespace WebApplication2.Repostories
{
    public class NursingDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public NursingDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //映射数据表
        public DbSet<AdminInfo> adminInfos { get; set; }
        public DbSet<SeniorInfo> seniorInfos { get; set; }
        public DbSet<GuardianInfo> guardianInfos { get; set; }
        public DbSet<RoomInfo> roomInfos { get; set; }
        public DbSet<CaregiverInfo> caregiverInfos { get; set; }
        public DbSet<BookingInfo> bookingInfos { get; set; }
        public DbSet<HospitalizationRecordInfo> hospitalizationRecordInfos { get; set; }
        public DbSet<ApplicationInfo> applicationInfos { get; set; }
        public DbSet<SuggestionInfo> suggestionInfos { get; set; }
        public DbSet<HealthDataItemInfo> healthDataItemInfos { get; set; }

        //连接配置
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString = configuration.GetConnectionString("CompanyConnString");
            optionsBuilder.UseSqlServer(connectionString);
        }


        #region 数据表配置

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminInfo>().ToTable("Admin");
            modelBuilder.Entity<SeniorInfo>().ToTable("Senior");
            modelBuilder.Entity<GuardianInfo>().ToTable("Guardian");
            modelBuilder.Entity<RoomInfo>().ToTable("Room");
            modelBuilder.Entity<CaregiverInfo>().ToTable("Caregiver");
            modelBuilder.Entity<BookingInfo>().ToTable("Booking");
            modelBuilder.Entity<HospitalizationRecordInfo>().ToTable("HospitalizationRecord");
            modelBuilder.Entity<ApplicationInfo>().ToTable("Application");
            modelBuilder.Entity<SuggestionInfo>().ToTable("Suggestion");
            modelBuilder.Entity<HealthDataItemInfo>().ToTable("HealthDataItem");
        }

        #endregion
    }
}
