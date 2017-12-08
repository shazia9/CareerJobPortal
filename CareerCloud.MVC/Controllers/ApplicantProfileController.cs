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
    public class ApplicantProfileController : Controller
    {
        

        private ApplicantProfileLogic aplogic;
        public ApplicantProfileController()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>();
            aplogic = new ApplicantProfileLogic(repo);
        }

        // GET: ApplicantProfile
        public ActionResult Index()
        {
            
            return View(aplogic.GetAll());
        }

        // GET: ApplicantProfile/Details/5
        public ActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ApplicantProfilePoco applicantProfilePoco = aplogic.Get(Id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: ApplicantProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                
                ApplicantProfilePoco[] applicantProfile = new ApplicantProfilePoco[] { applicantProfilePoco };
                aplogic.Add(applicantProfile);
                return RedirectToAction("Index");
            }

            
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ApplicantProfilePoco applicantProfilePoco = aplogic.Get(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
           
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CurrentSalary,CurrentRate,Currency,Country,Province,Street,City,PostalCode")] ApplicantProfilePoco applicantProfilePoco)
        {
            if (ModelState.IsValid)
            {
                
                ApplicantProfilePoco[] applicantProfile=new ApplicantProfilePoco[] { applicantProfilePoco};
                aplogic.Update(applicantProfile);
                return RedirectToAction("Index");
            }
           
            return View(applicantProfilePoco);
        }

        // GET: ApplicantProfile/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ApplicantProfilePoco applicantProfilePoco = aplogic.Get(id);
            if (applicantProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantProfilePoco);
        }

        // POST: ApplicantProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            
            ApplicantProfilePoco applicantProfilePoco = aplogic.Get(id);
            ApplicantProfilePoco[] applicantProfile = new ApplicantProfilePoco[] { applicantProfilePoco };
            aplogic.Delete(applicantProfile);
            return RedirectToAction("Index");
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
