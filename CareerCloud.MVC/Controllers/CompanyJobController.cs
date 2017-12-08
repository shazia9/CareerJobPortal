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
using CareerCloud.MVC.Models;
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyJobController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();
        private CompanyJobLogic cjlogic;
        private CompanyJobDescriptionLogic cjdlogic;
        private CompanyJobSkillLogic cjslogic;
        private CompanyJobEducationLogic cjelogic;

        // GET: CompanyJob
        public ActionResult Index()
        {
            var companyJob = db.CompanyJob.Include(c => c.CompanyProfile);
            return View(companyJob.ToList());
        }

        // GET: CompanyJob/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
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
        public ActionResult Create(JobPostVM viewmodel)
        {
            CompanyJobPoco companyjob = new CompanyJobPoco();
            companyjob.ProfileCreated = viewmodel.ProfileCreated;
            companyjob.IsInactive = viewmodel.IsInactive;
            companyjob.IsCompanyHidden = viewmodel.IsCompanyHidden;
            companyjob.Company = viewmodel.Company;

            CompanyJobPoco[] cj = new CompanyJobPoco[] { companyjob };
            cjlogic.Add(cj);

            CompanyJobDescriptionPoco companyjobdescription = new CompanyJobDescriptionPoco();
            companyjobdescription.JobDescriptions = viewmodel.JobDescriptions;
            companyjobdescription.JobName = viewmodel.JobName;
            CompanyJobDescriptionPoco[] cjd = new CompanyJobDescriptionPoco[] { companyjobdescription };
            cjdlogic.Add(cjd);

            CompanyJobSkillPoco companyjobskill = new CompanyJobSkillPoco();
            companyjobskill.Skill = viewmodel.Skill;
            companyjobskill.SkillLevel = viewmodel.SkillLevel;
            companyjobskill.Importance = viewmodel.Importance;
            CompanyJobSkillPoco[] cjs = new CompanyJobSkillPoco[] { companyjobskill };
            cjslogic.Add(cjs);

            CompanyJobEducationPoco companyjobeducation = new CompanyJobEducationPoco();
            companyjobeducation.Major = viewmodel.Major;
            companyjobeducation.Importance = viewmodel.EduImportance;
            CompanyJobEducationPoco[] cje = new CompanyJobEducationPoco[] { companyjobeducation };
            cjelogic.Add(cje);

            return RedirectToAction("Index");
        }

        // GET: CompanyJob/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            if (companyJobPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // POST: CompanyJob/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,ProfileCreated,IsInactive,IsCompanyHidden,TimeStamp")] CompanyJobPoco companyJobPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.CompanyProfile, "Id", "CompanyWebsite", companyJobPoco.Company);
            return View(companyJobPoco);
        }

        // GET: CompanyJob/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
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
            CompanyJobPoco companyJobPoco = db.CompanyJob.Find(id);
            db.CompanyJob.Remove(companyJobPoco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
