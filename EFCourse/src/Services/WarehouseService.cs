using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using Services.ComplexModels;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class WarehouseService
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _context.Warehouses
                           .Include(x => x.Products)
                            .ThenInclude(x => x.Product)
                           .ToList();
        }

        // Memory option
        //public IEnumerable<WarehouseProductReport> GetAllWithProducts()
        //{
        //    var warehouses = this.GetAll();
        //    var warehouseProducts = warehouses.SelectMany(x => x.Products).ToList();

        //    // Linq query expression vs lambda expression
        //    return (
        //        from w in warehouses
        //        from wp in warehouseProducts.Where(x => x.WarehouseId == w.WarehouseId)
        //        select new WarehouseProductReport
        //        {
        //            WarehouseName = w.Name,
        //            ProductName = wp.Product.Name,
        //            ProductPrice = wp.Product.Price
        //        }
        //    ).ToList();
        //}

        public IEnumerable<WarehouseProductReport> GetAllWithProducts()
        {
            return (
                from w in _context.Warehouses
                from wp in _context.WarehouseProduct.Where(x => x.WarehouseId == w.WarehouseId)
                select new WarehouseProductReport
                {
                    WarehouseName = w.Name,
                    ProductName = wp.Product.Name,
                    ProductPrice = wp.Product.Price
                }
            ).ToList();
        }

        public void Remove(int id)
        {
            //_context.Remove(new Warehouse { WarehouseId = id });
            //_context.SaveChanges();

            var originalEntry = _context.Warehouses.Single(x => x.WarehouseId == id);
            originalEntry.IsDeleted = true;
            _context.Update(originalEntry);
            _context.SaveChanges();
        }

        public void Remove(List<int> ids)
        {
            var warehouses = ids.Select(x => new Warehouse
            {
                WarehouseId = x
            }).ToList();
            _context.RemoveRange(warehouses);
            _context.SaveChanges();
        }
    }
} 