using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // ısrequired zorunlu değildi çünkü nulleb değil

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Price).IsRequired().HasPrecision(18,2);

            // nullabele oldugu için yazmasakta olur
            builder.Property(x => x.PictureUri).IsRequired(false);


            // bu iki satırada gerek yoktu çümkü product sınıfında ef geleneyine uygun yazarak ilişkilendirdik 

            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand).WithMany().HasForeignKey(x => x.BrandId);


        }
    }
}
