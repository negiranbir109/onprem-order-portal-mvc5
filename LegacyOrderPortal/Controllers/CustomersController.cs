using System.Linq;
using System.Web.Mvc;
using LegacyOrderPortal.DAL;

namespace LegacyOrderPortal.Controllers
{
    public class CustomersController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var customers = unitOfWork.Context.Customers.OrderBy(c => c.Name).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = unitOfWork.Context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}
