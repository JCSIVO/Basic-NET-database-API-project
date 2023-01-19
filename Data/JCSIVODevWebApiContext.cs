using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JCSIVODevWebApi.Models;

namespace JCSIVODevWebApi.Data
{
    public class JCSIVODevWebApiContext : DbContext
    {
        public JCSIVODevWebApiContext (DbContextOptions<JCSIVODevWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<JCSIVODevWebApi.Models.Personas> Personas { get; set; } = default!;
    }
}
