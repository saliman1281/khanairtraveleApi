using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.CommonModel.CommonModel;

namespace DBCore.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<RepresentativeRequest> RepresentativeRequests { get; set; }
        public DbSet<AirLineRequest> AirLineRequests { get; set; }
        public DbSet<TicketTypeRequest> TicketTypeRequests { get; set; }
        public DbSet<VisaTypeRequest> VisaTypeRequests { get; set; }
    }
}
