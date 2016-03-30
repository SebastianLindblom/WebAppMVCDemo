using System.Net;
using System.Web.Mvc;
using ClassLibrary;
using Service;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {

        private ServiceController c;
        public UsersController()
        {
            if (c == null)
            {
                c = new ServiceController();
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(c.GetUsers());
        }



        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = c.FindUserFromId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // LOGIN: Users
        public ActionResult Login()
        {
            if (c.IsLoggedIn())
            {
                c.LogOut();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // LOGIN: Users
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "UserId,Username")] User user)
        {

            if (ModelState.IsValid)
            {

                if (user == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                c = new ServiceController();
                user = c.FindUserFromUsername(user.Username);
                if (user == null)
                {
                    return HttpNotFound();
                }


                c.LogIn(user.Username);

                return RedirectToAction("Index", "UserTaskModels");
            }
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Username")] User user)
        {
            if (ModelState.IsValid)
            {
                c.AddPersonal(user);
                
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = c.FindUserFromId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Username")] User user)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(user).State = EntityState.Modified;
      
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = c.FindUserFromId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            User user = c.FindUserFromId(id);
            c.RemoveUser(id);
                       
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }
    }
}
