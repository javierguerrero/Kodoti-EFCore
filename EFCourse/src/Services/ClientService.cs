using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using Services.QueryHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Client Get(int id)
        {
            return _context.Clients.SingleOrDefault(x => x.ClientId == id);
        }

        public Client GetFirstClient()
        {
            return _context.Clients.First();
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
                           .GetBaseQuery()
                           .OrderByDescending(x => x.ClientId)
                           .ToList();
        }

        public void Create(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
        }

        public void Create(List<Client> clients)
        {
            _context.AddRange(clients);
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            var originalEntry = _context.Clients.Single(x => x.ClientId == client.ClientId);
            originalEntry.Name = client.Name;
            _context.SaveChanges();

            // Guardar forma desconectada
            //_context.Update(client);
            //_context.SaveChanges();
        }

        public void Update(List<Client> clients)
        {
            var ids = clients.Select(x => x.ClientId);
            var entries = _context.Clients.Where(x => ids.Contains(x.ClientId)).ToList();

            foreach (var entry in entries)
            {
                var client = clients.Single(x => x.ClientId == entry.ClientId);
                entry.Name = client.Name;
            }
            _context.SaveChanges();
        }
    }
}