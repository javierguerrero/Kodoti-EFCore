using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.Property(x => x.OrderId).HasMaxLength(20);
        }
    }
}
