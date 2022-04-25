using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class DongGuanBridgeContext : DbContext
    {
        public DongGuanBridgeContext(DbContextOptions<DongGuanBridgeContext> options) : base(options) { }

        public DbSet<BgeInfoEntityDongGuan> DongGuanBgeInfoEntities { get; set; }
    }
}
