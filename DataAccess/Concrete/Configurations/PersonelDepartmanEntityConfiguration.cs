using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class PersonelDepartmanEntityConfiguration : IEntityTypeConfiguration<PersonelDepartman>
    {
        public void Configure(EntityTypeBuilder<PersonelDepartman> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PersonelId).IsRequired();
            builder.Property(x => x.DepartmanId).IsRequired();
        }
    }
}
