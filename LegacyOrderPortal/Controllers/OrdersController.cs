using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LegacyOrderPortal.DAL;
using LegacyOrderPortal.Services;
using LegacyOrderPortal.ViewModels;

namespace LegacyOrderPortal.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        private readonly OrderService orderService;

        public OrdersController()
        {
            orderService = new OrderService(unitOfWork);
        }

        public ActionResult Index()
        {
            var list = orderService.GetOrderList();
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var order = orderService.GetOrderDetails(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult Create()
        {
            var model = orderService.BuildOrderEditModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = orderService.BuildOrderEditModel(model);
                return View(model);
            }

            orderService.CreateOrder(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var model = orderService.BuildOrderEditModel(id);
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = orderService.BuildOrderEditModel(model);
                return View(model);
            }

            orderService.UpdateOrder(model);
            return RedirectToAction("Index");
        }
    }
}
