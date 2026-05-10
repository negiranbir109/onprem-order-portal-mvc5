using System;
using System.Collections.Generic;
using System.Data.Entity;
using LegacyOrderPortal.Models;

namespace LegacyOrderPortal.DAL
{
    public class LegacyDbInitializer : CreateDatabaseIfNotExists<LegacyOrderContext>
    {
        protected override void Seed(LegacyOrderContext context)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Global Operations", Email = "ops@legacy.local", Phone = "555-0110" },
                new Customer { Name = "North District Warehouse", Email = "warehouse@legacy.local", Phone = "555-0120" }
            };

            customers.ForEach(c => context.Customers.Add(c));

            var products = new List<Product>
            {
                new Product { Name = "Thermal Label Printer", SKU = "TL-2100", Price = 349.99m, Description = "Industrial label printing device." },
                new Product { Name = "Rack Storage Unit", SKU = "RSU-12", Price = 1050.00m, Description = "Heavy duty rack for warehouse inventory." }
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { OrderNumber = "ORD-1001", CustomerId = customers[0].CustomerId, OrderDate = DateTime.Today.AddDays(-6), TotalAmount = 499.98m },
                new Order { OrderNumber = "ORD-1002", CustomerId = customers[1].CustomerId, OrderDate = DateTime.Today.AddDays(-3), TotalAmount = 1050.00m }
            };

            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            var items = new List<OrderItem>
            {
                new OrderItem { OrderId = orders[0].OrderId, ProductId = products[0].ProductId, Quantity = 2, UnitPrice = 249.99m },
                new OrderItem { OrderId = orders[1].OrderId, ProductId = products[1].ProductId, Quantity = 1, UnitPrice = 1050.00m }
            };

            items.ForEach(i => context.OrderItems.Add(i));
            base.Seed(context);
        }
    }
}
