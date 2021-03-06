using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Configurations
{
    public class UnvanEntityConfiguration : IEntityTypeConfiguration<Unvan>
    {
        public void Configure(EntityTypeBuilder<Unvan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UnvanKodu).IsRequired();
            builder.Property(x => x.UnvanAdi).IsRequired();

        }
    }
}
