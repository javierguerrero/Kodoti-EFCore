using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.ClientNumber).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasOne(x => x.Country)
                         .WithMany(x => x.Clients)
                         .HasForeignKey(x => x.Country_Id);

            entityBuilder.HasData(
                new  Client
                {
                    ClientId = 1,
                    ClientNumber = "41811389",
                    Name = "Javier Guerrero"
                },
                new Client
                {
                    ClientId = 2,
                    ClientNumber = "987654321",
                    Name = "AmbarTech"
                }
            );
        }
    }
}
