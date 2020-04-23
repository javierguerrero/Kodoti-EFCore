using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Guitarra eléctrica Fender Squier",
                    Price = 700
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Guitarra eléctrica Suhr",
                    Price = 2500
                }
            );
        }
    }
}
