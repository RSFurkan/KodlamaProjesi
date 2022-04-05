using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public class PersonelEntityConfiguration : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ad).IsRequired();
            builder.Property(x => x.SicilNumarasi).IsRequired();
            builder.Property(x => x.SoyAd).IsRequired();
            builder.Property(x => x.Cinsiyet).IsRequired();
            builder.Property(x => x.CepTelefonu).IsRequired(); 

        }
    }
}
