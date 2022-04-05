using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class DepartmanEntityConfiguration : IEntityTypeConfiguration<Departman>
    {
        public void Configure(EntityTypeBuilder<Departman> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Ad).IsRequired();
            builder.Property(x => x.Kod).IsRequired(); 
        }
    }
}
