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
    public class CompanyJobEducationController : Controller
    {
        private CareerCloudContext db = new CareerCloudContext();

        // GET: CompanyJobEducation
        public ActionResult Index()
        {
            var companyJobEducation = db.CompanyJobEducation.Include(c => c.CompanyJob);
            return View(companyJobEducation.ToList());
        }

        // GET: CompanyJobEducation/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id");
            return View();
        }

        // POST: CompanyJobEducation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Major,Importance,TimeStamp")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                companyJobEducationPoco.Id = Guid.NewGuid();
                db.CompanyJobEducation.Add(companyJobEducationPoco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Major,Importance,TimeStamp")] CompanyJobEducationPoco companyJobEducationPoco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyJobEducationPoco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.CompanyJob, "Id", "Id", companyJobEducationPoco.Job);
            return View(companyJobEducationPoco);
        }

        // GET: CompanyJobEducation/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            if (companyJobEducationPoco == null)
            {
                return HttpNotFound();
            }
            return View(companyJobEducationPoco);
        }

        // POST: CompanyJobEducation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CompanyJobEducationPoco companyJobEducationPoco = db.CompanyJobEducation.Find(id);
            db.CompanyJobEducation.Remove(companyJobEducationPoco);
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
