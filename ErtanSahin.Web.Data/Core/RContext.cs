using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ErtanSahin.Web.Data.Core
{
    public class RContext : DbContext
    {
        public RContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
    }
}
