using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ClassLibrary;

using Service;
namespace WebApp.Controllers
{
    public class UserTaskModelsController : Controller
    {

        private ServiceController c;
        public UserTaskModelsController()
        {
            if(c== null)
            {
                c = new ServiceController();
            }
        }

        // GET: UserTaskModels
        public ActionResult Index()
        {

            return View(c.GetTasksClosest());
        }

        // GET: UserTaskModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTaskModel userTaskModel = c.FindTaskFromId(id);
      
            if (userTaskModel == null)
            {
                return HttpNotFound();
            }
            return View(userTaskModel);
        }

        // GET: UserTaskModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTaskModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskId,TaskName,Date,Where,UserId")] UserTaskModel userTaskModel)
        {
            if (ModelState.IsValid)
            {
                c.AddTask(userTaskModel);
                return RedirectToAction("Index");
            }

            ViewBag.UserId = LoggedIn.Username;
            return View(userTaskModel);
        }

        // GET: UserTaskModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            UserTaskModel userTaskModel = null; // inte klar
            if (userTaskModel == null)
            {
                return HttpNotFound();
            }
          //  ViewBag.UserId = new SelectList(db.User, "UserId", "Username", userTaskModel.UserId);
            return View(userTaskModel);
        }

        // POST: UserTaskModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,TaskName,Date,Where,UserId")] UserTaskModel userTaskModel)
        {
            if (ModelState.IsValid)
            {
               // db.Entry(userTaskModel).State = EntityState.Modified;
         
                return RedirectToAction("Index");
            }
           // ViewBag.UserId = new SelectList(db.User, "UserId", "Username", userTaskModel.UserId);
            return View(userTaskModel);
        }

        // GET: UserTaskModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           UserTaskModel userTaskModel = c.FindTaskFromId(id);
           
            if (userTaskModel == null)
            {
                return HttpNotFound();
            }
            return View(userTaskModel);
        }

        // POST: UserTaskModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            c.RemoveTask(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
