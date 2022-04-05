using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public sealed class MsDbContext : ProjectDbContext
    {
        public MsDbContext(DbContextOptions<MsDbContext> options, IConfiguration configuration)
            : base(options, configuration)
        {
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
