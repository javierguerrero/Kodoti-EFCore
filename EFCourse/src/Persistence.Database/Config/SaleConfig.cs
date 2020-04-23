using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class SaleConfig
    {
        public SaleConfig(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.HasKey(x =>  new { x.Year, x.Month });
        }
    }
}
