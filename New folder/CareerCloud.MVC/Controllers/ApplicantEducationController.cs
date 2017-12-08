using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantEducationController : Controller
    {
        // GET: ApplicantEducation

        private ApplicantEducationLogic aelogic;

        public ApplicantEducationController()
        {
            var Repo = new EFGenericRepository<ApplicantEducationPoco>();
            aelogic = new ApplicantEducationLogic(Repo);
        }
        
        public ActionResult Index(Guid Id)

        {
           
            
            return View(aelogic.GetAll().Where(a=>a.Applicant==Id).ToList());
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Include ="Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent")]ApplicantEducationPoco Appedu)
        {
            if (ModelState.IsValid)
            {
                ApplicantEducationPoco[] ae = new ApplicantEducationPoco[] { Appedu };
                aelogic.Add(ae);
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = Appedu.Applicant;
            return View(Appedu);
        }

        // GET: ApplicantEducation/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            ApplicantEducationPoco applicantEducationPoco = aelogic.Get(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent")] ApplicantEducationPoco applicantEducationPoco)
        {
            if (ModelState.IsValid)
            {
               
                ApplicantEducationPoco[] applicantEducation = new ApplicantEducationPoco[] { applicantEducationPoco };
                aelogic.Update(applicantEducation);
                return RedirectToAction("Index");
            }
             ViewBag.Applicant = applicantEducationPoco.Applicant;
            return View(applicantEducationPoco);
        }

        // GET: ApplicantEducation/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ApplicantEducationPoco applicantEducationPoco = aelogic.Get(id);
            if (applicantEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantEducationPoco);
        }

        // POST: ApplicantEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            
            ApplicantEducationPoco applicantEducationPoco = aelogic.Get(id);
            ApplicantEducationPoco[] applicantEducation = new ApplicantEducationPoco[] { applicantEducationPoco };
            aelogic.Delete(applicantEducation);
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