using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLCuDan.DAL.Model;

namespace QLCuDan.DAL.Data
{
    public class QLCuDanDALContext : DbContext
    {
        public QLCuDanDALContext (DbContextOptions<QLCuDanDALContext> options)
            : base(options)
        {
        }

        public DbSet<QLCuDan.DAL.Model.Apartment> Apartment { get; set; } = default!;
        public DbSet<QLCuDan.DAL.Model.Citizen> Citizen { get; set; } = default!;
        public DbSet<QLCuDan.DAL.Model.CitizenApartment> CitizenApartment { get; set; } = default!;
    }
}
