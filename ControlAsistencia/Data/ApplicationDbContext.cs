using ControlAsistencia.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlAsistencia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Programa> Programa { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Competencia>Competencia { get; set; }

    }
}
