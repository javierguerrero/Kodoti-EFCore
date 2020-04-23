using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ProductExtraInformationConfig
    {
        public ProductExtraInformationConfig(EntityTypeBuilder<ProductExtraInformation> entityBuilder)
        {
            entityBuilder.Property(x => x.SKU).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
