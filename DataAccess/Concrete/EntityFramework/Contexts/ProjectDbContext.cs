 
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
                                                                               : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Let's also implement the general version.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
                                                                        : base(options)
        {
            Configuration = configuration;
        }
        protected IConfiguration Configuration { get; }

        public DbSet<Departman> Departman { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<PersonelDepartman> PersonelDepartman { get; set; }
        public DbSet<PersonelOrnekDataTable> PersonelOrnekDataTable { get; set; }
        public DbSet<PersonelUnvan> PersonelUnvan { get; set; }
        public DbSet<Unvan> Unvan { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaProjesiContext"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
