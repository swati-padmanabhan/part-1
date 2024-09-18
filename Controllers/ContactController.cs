using System;
using System.Linq;
using System.Web.Mvc;
using ContactAppProject.Data;
using ContactAppProject.Models;

namespace ContactAppProject.Controllers
{
    [Authorize(Roles = "Staff")]
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContacts(Guid userId)
        {
            userId = (Guid)Session["UserId"];
            using (var session = NHibernateHelper.CreateSession())
            {
                var contacts = session.Query<Contact>().Where(c => c.User.Id == userId).ToList();

                if (contacts.Count > 0)
                {
                    return Json(contacts, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(500);
            }
        }

        public ActionResult AddContact(Contact contact)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    contact.User = session.Get<User>(Session["UserId"]);
                    session.Save(contact);
                    txn.Commit();
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }


            }

        }


    }
}