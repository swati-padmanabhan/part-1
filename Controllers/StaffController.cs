using System;
using System.Linq;
using System.Web.Mvc;
using ContactAppProject.Data;
using ContactAppProject.Models;
using NHibernate.Linq;

namespace ContactAppProject.Controllers
{
    [Authorize(Roles = "Staff")]

    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewStaffDetails()
        {
            var userId = (Guid)Session["UserId"];
            using (var session = NHibernateHelper.CreateSession())
            {
                var staffDetails = session.Query<User>().FetchMany(u => u.Contacts)
                                              .SingleOrDefault(u => u.Id == userId);

                if (staffDetails != null)
                {
                    return View(staffDetails);
                }
            }
            return RedirectToAction("Login", "User");
        }

    }
}