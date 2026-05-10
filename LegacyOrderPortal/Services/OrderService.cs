using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using LegacyOrderPortal.DAL;
using LegacyOrderPortal.Logging;
using LegacyOrderPortal.Models;
using LegacyOrderPortal.ViewModels;

namespace LegacyOrderPortal.Services
{
    public class OrderService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly FileLogger logger = new FileLogger();
        private readonly string supportEmail;

        public OrderService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            supportEmail = WebConfigurationManager.AppSettings["SupportEmail"] ?? "support@legacy.local";
        }

        public IEnumerable<OrderListViewModel> GetOrderList()
        {
            return unitOfWork.OrderRepository.GetAllOrders().Select(order => new OrderListViewModel
            {
                OrderId = order.OrderId,
                OrderNumber = order.OrderNumber,
                CustomerName = order.Customer?.Name ?? "Unknown",
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                ItemCount = order.OrderItems?.Count ?? 0
            }).ToList();
        }

        public Order GetOrderDetails(int id)
        {
            return unitOfWork.OrderRepository.GetOrderById(id);
        }

        public OrderEditViewModel BuildOrderEditModel()
        {
            return BuildOrderEditModel(new OrderEditViewModel { OrderDate = DateTime.Today });
        }

        public OrderEditViewModel BuildOrderEditModel(int id)
        {
            var existing = GetOrderDetails(id);
            if (existing == null)
            {
                return null;
            }

            return new OrderEditViewModel
            {
                OrderId = existing.OrderId,
                OrderNumber = existing.OrderNumber,
                CustomerId = existing.CustomerId,
                OrderDate = existing.OrderDate,
                TotalAmount = existing.TotalAmount,
                Customers = GetCustomersSelectList(existing.CustomerId)
            };
        }

        public OrderEditViewModel BuildOrderEditModel(OrderEditViewModel model)
        {
            return new OrderEditViewModel
            {
                OrderId = model.OrderId,
                OrderNumber = model.OrderNumber,
                CustomerId = model.CustomerId,
                OrderDate = model.OrderDate,
                TotalAmount = model.TotalAmount,
                Customers = GetCustomersSelectList(model.CustomerId)
            };
        }

        public void CreateOrder(OrderEditViewModel model)
        {
            var order = new Order
            {
                OrderNumber = model.OrderNumber,
                CustomerId = model.CustomerId,
                OrderDate = model.OrderDate,
                TotalAmount = model.TotalAmount
            };

            unitOfWork.OrderRepository.AddOrder(order);
            unitOfWork.Save();
            logger.Log($"Order created: {order.OrderNumber} by {supportEmail}");
        }

        public void UpdateOrder(OrderEditViewModel model)
        {
            var order = unitOfWork.OrderRepository.GetOrderById(model.OrderId);
            if (order == null)
            {
                throw new InvalidOperationException("Order not found.");
            }

            order.OrderNumber = model.OrderNumber;
            order.CustomerId = model.CustomerId;
            order.OrderDate = model.OrderDate;
            order.TotalAmount = model.TotalAmount;

            unitOfWork.OrderRepository.UpdateOrder(order);
            unitOfWork.Save();
            logger.Log($"Order updated: {order.OrderNumber} by {supportEmail}");
        }

        private IEnumerable<SelectListItem> GetCustomersSelectList(int selectedId)
        {
            return unitOfWork.Context.Customers.OrderBy(c => c.Name).ToList().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CustomerId.ToString(),
                Selected = c.CustomerId == selectedId
            });
        }
    }
}
