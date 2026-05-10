using System.Linq;
using System.Web.Mvc;
using LegacyOrderPortal.DAL;

namespace LegacyOrderPortal.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            var products = unitOfWork.Context.Products.OrderBy(p => p.Name).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = unitOfWork.Context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}
