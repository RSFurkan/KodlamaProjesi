using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class PersonelUnvanEntityConfiguration : IEntityTypeConfiguration<PersonelUnvan>
    {
        public void Configure(EntityTypeBuilder<PersonelUnvan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PersonelId).IsRequired();
            builder.Property(x => x.UnvanId).IsRequired();

        }
    }
}
