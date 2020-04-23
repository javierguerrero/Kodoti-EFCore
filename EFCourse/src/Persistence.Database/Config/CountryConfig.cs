using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class CountryConfig
    {
        public CountryConfig(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasData(
                new Country { 
                    CountryId = 1,
                    Name = "Peru"
                },
                new Country
                {
                    CountryId = 2,
                    Name = "México"
                }
            );

        }
    }
}
