using System.Linq;
using System.Web.Mvc;
using InterantionalBusinessMen.DAL;
using InterantionalBusinessMen.ViewModels;

namespace InterantionalBusinessMen.Controllers
{
    public class HomeController : Controller
    {
        private GNBContext db = new GNBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = from executive in db.Executives
                                                   group executive by executive.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       ExecutiveCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}