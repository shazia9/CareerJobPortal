﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantSkillController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: ApplicantSkill
        public ActionResult Index()
        {
            var applicantSkill = db.ApplicantSkill.Include(a => a.ApplicantProfile);
            return View(applicantSkill.ToList());
        }

        // GET: ApplicantSkill/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = db.ApplicantSkill.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency");
            return View();
        }

        // POST: ApplicantSkill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Skill,SkillLevel,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantSkillPoco applicantSkillPoco)
        {
            if (ModelState.IsValid)
            {
                applicantSkillPoco.Id = Guid.NewGuid();
                db.ApplicantSkill.Add(applicantSkillPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantSkillPoco.Applicant);
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = db.ApplicantSkill.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantSkillPoco.Applicant);
            return View(applicantSkillPoco);
        }

        // POST: ApplicantSkill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Skill,SkillLevel,StartMonth,StartYear,EndMonth,EndYear,TimeStamp")] ApplicantSkillPoco applicantSkillPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantSkillPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.ApplicantProfile, "Id", "Currency", applicantSkillPoco.Applicant);
            return View(applicantSkillPoco);
        }

        // GET: ApplicantSkill/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantSkillPoco applicantSkillPoco = db.ApplicantSkill.Find(id);
            if (applicantSkillPoco == null)
            {
                return HttpNotFound();
            }
            return View(applicantSkillPoco);
        }

        // POST: ApplicantSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ApplicantSkillPoco applicantSkillPoco = db.ApplicantSkill.Find(id);
            db.ApplicantSkill.Remove(applicantSkillPoco);
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
