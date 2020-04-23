using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Services.QueryHelpers
{
    public static class ClientQueryHelper
    {
        public static IQueryable<Client> GetBaseQuery(this DbSet<Client> query) 
        {
            return query.Include(x => x.Country)
                        .AsQueryable();
        }
    }
}
