using FormProject.Data.Concrate.EFCore.Config;
using FormProject.Data.Concrate.EFCore.Extensions;
using FormProject.Entity.Concrate;
using FormProject.Entity.Concrate.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Data.Concrate.EFCore.Context
{
    public class FormProjectContext : IdentityDbContext<User, Role, string>
    {
        public FormProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Fields> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FormConfig).Assembly);

            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
    }
}
