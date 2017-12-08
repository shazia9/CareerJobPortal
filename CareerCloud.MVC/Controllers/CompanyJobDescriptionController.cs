using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobDescriptionController : Controller
    {
        // private CareerCloudContext db = new CareerCloudContext();
        private CompanyJobDescriptionLogic cjdlogic;

        public CompanyJobDescriptionController()
        {
            var Repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            cjdlogic = new CompanyJobDescriptionLogic(Repo);
        }

        // GET: CompanyJobDescription
        public ActionResult Index(Guid id)
        {
            return View(cjdlogic.GetAll().Where(a => a.Job == id).ToList());
        }

        // GET: CompanyJobDescription/Details/5
        //public ActionResult Details(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CompanyJobDescriptionPoco companyJobDescriptionPoco = db.CompanyJobDescription.Find(id);
        //    if (companyJobDescriptionPoco == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(companyJobDescriptionPoco);
        //}

        // GET: CompanyJobDescription/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CompanyJobDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobName,JobDescriptions")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                CompanyJobDescriptionPoco[] cp = new CompanyJobDescriptionPoco[] { companyJobDescriptionPoco };
                cjdlogic.Add(cp);
                return RedirectToAction("Index");
            }

            ViewBag.Job = companyJobDescriptionPoco.Job;
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco CompanyJobDescriptionPoco = cjdlogic.Get(id);
            if (CompanyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }

            return View(CompanyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobName,JobDescriptions")] CompanyJobDescriptionPoco companyJobDescriptionPoco)
        {
            if (ModelState.IsValid)
            {
                CompanyJobDescriptionPoco[] CompanyJobDescription = new CompanyJobDescriptionPoco[] { companyJobDescriptionPoco };
                cjdlogic.Update(CompanyJobDescription);
                return RedirectToAction("Index");
            }
            ViewBag.Job = companyJobDescriptionPoco.Job;
            return View(companyJobDescriptionPoco);
        }

        // GET: CompanyJobDescription/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobDescriptionPoco companyJobDescriptionPoco = cjdlogic.Get(id);
            if (companyJobDescriptionPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobDescriptionPoco);
        }

        // POST: CompanyJobDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobDescriptionPoco companyJobDescriptionPoco = cjdlogic.Get(id);
            CompanyJobDescriptionPoco[] companyjobdescription = new CompanyJobDescriptionPoco[] { companyJobDescriptionPoco };
            cjdlogic.Delete(companyjobdescription);
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
