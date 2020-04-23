using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;
        private const decimal Iva = 0.18m;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.Orders
                           .Include(x => x.Client)
                            .ThenInclude(x => x.Country)
                           .ToList();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                           .Include(x => x.Client)
                            .ThenInclude(x => x.Country)
                           .ToListAsync();
        }
        public void Create(Order order)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                //01. obtener el correlativo de la orden 2019-0001
                PrepareOrderNumber(order);

                //02. completar los campos pendientes
                PrepareDetail(order);
                prepareOrderAmounts(order);

                order.RegisteredAt = DateTime.Now;

                //03. crear la orden
                _context.Add(order);
                _context.SaveChanges();

                trans.Commit();
            }
        }

        private void prepareOrderAmounts(Order order)
        {
            order.SubTotal = order.Items.Sum(x => x.SubTotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }

        private void PrepareDetail(Order order)
        {
            foreach (var detail in order.Items)
            {
                detail.Total = detail.Quantity * detail.UnitPrice;
                detail.Iva = detail.Total * Iva;
                detail.SubTotal = detail.Total - detail.Iva;
            }
        }

        private void PrepareOrderNumber(Order order)
        {
            var orderNumber = _context.OrderNumbers.Single(x => x.Year == DateTime.Now.Year);
            orderNumber.Value++;

            order.OrderId = orderNumber.Year.ToString() + "-" + orderNumber.Value.ToString().PadLeft(5, '0');
        }
    }
}