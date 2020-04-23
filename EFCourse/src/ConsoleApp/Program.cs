using BetterConsoleTables;
using Common;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(Parameter.ConnectionString);
            var context = new ApplicationDbContext(optionsBuilder.Options);

            var clientService = new ClientService(context);
            var productService = new ProductService(context);
            var warehouseService = new WarehouseService(context);
            var orderService = new OrderService(context);

            using (context)
            {
                //var clients = new List<Client> {
                //    new Client {
                //        ClientId = 5,
                //        Name = "Alfa"
                //    },
                //    new Client {
                //        ClientId = 6,
                //        Name = "Omega"
                //    }
                //};
                //clientService.Update(clients);

                //var client = new Client
                //{
                //    ClientId = 6,
                //    ClientNumber = "123456789",
                //    Country_Id = 1,
                //    Name = "Papaya SRL"
                //};
                //clientService.Update(client);

                // Remove
                //warehouseService.Remove(8);
                //warehouseService.Remove(new List<int> { 5,6,7 });

                // Add order
                var newOrder = new Order
                {
                    ClientId = 2,
                    Items = new List<OrderDetail>
                    {
                        new OrderDetail {
                            ProductId = 1,
                            UnitPrice = 400,
                            Quantity = 2,
                        },
                        new OrderDetail {
                            ProductId = 2,
                            UnitPrice = 1300,
                            Quantity = 4,
                        }
                    }
                };
                //orderService.Create(newOrder);
                //PrintClientsTable(clientService);
                //PrintClientTable(clientService, 3);
                //PrintClientTable(clientService);
                //PrintProductsTable(productService);
                //ProductsExistsByName(productService, "Guitarra eléctrica Fender Squier");
                //PrintWarehousesAndProducts(warehouseService);
                //PrintProductsByPagingTable(productService);
                //PrintWarehousesAndProductsComplex(warehouseService);
                //PrintOrders(orderService).Wait();

                //warehouseService.Remove(4);
                //PrintWarehouses(warehouseService);
            }
            Console.Read();
        }
        
        static void PrintWarehouses (WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAll();
            var table = new Table("WarehouseId", "Name");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.WarehouseId, warehouse.Name);
            }
            Console.Write(table.ToString());
        }


        static async Task PrintOrders(OrderService orderService)
        {
            var table = new Table("OrderId", "Client", "Country", "Iva", "SubTotal", "Total");
            var orders = await orderService.GetAllAsync();

            foreach (var order in orders)
            {
                table.AddRow(
                    order.OrderId,
                    order.Client.Name,
                    order.Client.Country.Name,
                    order.Iva,
                    order.SubTotal,
                    order.Total);
            }

            Console.Write(table.ToString());
        }

        static void PrintWarehousesAndProductsComplex(WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAllWithProducts();
            var table = new Table("Warehouse", "Product", "Price");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.WarehouseName, warehouse.ProductName, warehouse.ProductPrice);
            }

            Console.Write(table.ToString());
        }

        static void PrintProductsByPagingTable(ProductService productService)
        {
            var page = 0;

            do
            {
                var table = new Table("ProductId", "Name", "Price");
                var products = productService.GetPaged(page, 10);

                if (!products.Any())
                {
                    Console.WriteLine("No hay más registros que visualizar ...");
                    break;
                }

                foreach (var product in products)
                {
                    table.AddRow(product.ProductId, product.Name, product.Price);
                }

                Console.Write(table.ToString());
                Console.WriteLine("Presione enter para seguir buscando");
                Console.ReadLine();

                Console.Clear();

                page++;
            } while (true);
        }

        private static void PrintWarehousesAndProducts(WarehouseService warehouseService)
        {
            var warehouses = warehouseService.GetAll();
            var table = new Table("Warehouse", "Product", "Price");

            foreach (var warehouse in warehouses)
            {
                table.AddRow(warehouse.Name);

                foreach (var warehouseProduct in warehouse.Products)
                {
                    table.AddRow("", warehouseProduct.Product.Name, warehouseProduct.Product.Price);
                }
            }

            Console.Write(table.ToString());
        }

        private static void PrintProductsTable(ProductService productService)
        {
            var products = productService.GetAll(true);

            var table = new Table("ProductId", "Name", "Price");

            foreach (var product in products)
            {
                table.AddRow(product.ProductId, product.Name, product.Price);
            }

            Console.Write(table.ToString());
        }

        private static void ProductsExistsByName(ProductService productService, string name)
        {
            var exists = productService.ExistsByName(name);

            Console.WriteLine(exists ? "Product exists" : "Product not exists");
        }

        private static void PrintClientsTable(ClientService clientService)
        {
            var clients = clientService.GetAll();

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            foreach (var client in clients)
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
            }

            Console.Write(table.ToString());
        }

        private static void PrintClientTable(ClientService clientService, int id)
        {
            var client = clientService.Get(id);

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            if (client != null)
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
                Console.Write(table.ToString());
            }
        }

        private static void PrintClientTable(ClientService clientService)
        {
            var client = clientService.GetFirstClient();

            var table = new Table("ClientId", "ClientNumber", "Name", "Country");

            if (client != null)
            {
                table.AddRow(client.ClientId, client.ClientNumber, client.Name, client.Country?.Name ?? "-");
                Console.Write(table.ToString());
            }
        }

        private static void TestConnection(ApplicationDbContext context)
        {
            var isConnected = false;
            try
            {
                isConnected = context.Database.EnsureCreated(); //
            }
            catch (Exception)
            {
                throw;
            }

            if (isConnected)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connection successful");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection unsuccessful");
            }

            Console.Read();
        }
    }
}