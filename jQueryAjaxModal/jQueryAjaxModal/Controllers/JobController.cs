using jQueryAjaxModal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryAjaxModal.Controllers
{
    public class JobController : Controller
    {
        private JobDBEntities db = new JobDBEntities();
        // GET: Job
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetJobs()
        {
            List<Job> jobs = db.Jobs.ToList();
            

            var items = jobs.Select(row => new JobViewModel() {ID = row.ID,
                Name = row.Name,
                Salary = row.Salary,
                Datecreated = row.Datecreated,
                Activated = row.Activated });

            return Json(new { data = items }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Job());
            else
            {
                Job job = db.Jobs.Where(model => model.ID == id).FirstOrDefault();
                return View(job);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Job job)
        {
            if (job.ID == 0)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return Json(new { success = true, message = "Inserted successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Entry(job).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Updated successfully" }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Job job = db.Jobs.Where(model => model.ID == id).FirstOrDefault();
            var jobEmpToDelete = db.JobEmployees.Where(x => x.Job.ID == job.ID);
            db.JobEmployees.RemoveRange(jobEmpToDelete);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return Json(new { success = true, message = "Deleted successfully" }, JsonRequestBehavior.AllowGet);
        }


    }
}