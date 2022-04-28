using EFDataAccessLibrary.Models;
using GDBS.Shared.Data;
using GDBS.Shared.Data.Entity.Jket;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess
{
    public class BirdgeContext : DbContext
    {
        public BirdgeContext(DbContextOptions<BirdgeContext> options) : base(options) { }
        //public DbSet<Person> People { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<DetectionStaticTest> DetectionStaticTests { get; set; }
        public DbSet<BridgeTaskEntity> BridgeTaskEntities { get; set; }
        public DbSet<TaskGroupEntity> TaskGroupEntities { get; set; }
        public DbSet<TaskInstitutionEntity> TaskInstitutionEntities { get; set; }
        public DbSet<DetectionLoadTestEntity> DetectionLoadTestEntities { get; set; }
        public DbSet<BgeLineInfoEntity> BgeLineInfoEntities { get; set; }
        public DbSet<BgeInfoEntityNew> BgeInfoEntityNews { get; set; }
        public DbSet<MntSubjectEntity> MntSubjectEntities { get; set; }
        public DbSet<BgeAutoMonitorAppConfigEntity> BgeAutoMonitorAppConfigEntities { get; set; }



    }
}
