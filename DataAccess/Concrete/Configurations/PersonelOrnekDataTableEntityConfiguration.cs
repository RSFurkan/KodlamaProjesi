using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class PersonelOrnekDataTableEntityConfiguration : IEntityTypeConfiguration<PersonelOrnekDataTable>
    {
        public void Configure(EntityTypeBuilder<PersonelOrnekDataTable> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IseGirisTarihi).IsRequired();
        }
    }
}
