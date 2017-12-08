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
    public class CompanyJobController : Controller
    {
        //private CareerCloudContext db = new CareerCloudContext();
        private CompanyJobLogic cjlogic;

        public CompanyJobController()
        {
            var Repo = new EFGenericRepository<CompanyJobPoco>();
            cjlogic = new CompanyJobLogic(Repo);
        }

        // GET: CompanyJob
        public ActionResult Index(Guid id)
        {
            return View(cjlogic.GetAll().Where(i=>i.Company==id));
        }

        // GET: CompanyJob/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            CompanyJobPoco companyJobPoco = cjlogic.Get(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CompanyJob/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company,ProfileCreated,IsInactive,IsCompanyHidden")] CompanyJobPoco companyJobPoco)
        {
            if (ModelState.IsValid)
            {
                //companyJobPoco.Id = Guid.NewGuid();
                //db.CompanyJob.Add(companyJobPoco);
                //db.SaveChanges();
                CompanyJobPoco[] cj = new CompanyJobPoco[] { companyJobPoco };
                cjlogic.Add(cj);
                return RedirectToAction("Index");
            }

            //ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            ViewBag.Company = companyJobPoco.Company;
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            CompanyJobPoco companyJobPoco = cjlogic.Get(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // POST: CompanyJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company,ProfileCreated,IsInactive,IsCompanyHidden,TimeStamp")] CompanyJobPoco companyJobPoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(companyJobPoco).State = EntityState.Modified;
                //db.SaveChanges();
                CompanyJobPoco[] companyjob = new CompanyJobPoco[] { companyJobPoco };
                cjlogic.Update(companyjob);
                return RedirectToAction("Index");
            }
            ViewBag.Company = companyJobPoco.Company;
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            CompanyJobPoco companyJobPoco = cjlogic.Get(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobPoco);
        }

        // POST: CompanyJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobPoco companyjobPoco = cjlogic.Get(id);
            CompanyJobPoco[] companyjob = new CompanyJobPoco[] { companyjobPoco };
            cjlogic.Delete(companyjob);
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
