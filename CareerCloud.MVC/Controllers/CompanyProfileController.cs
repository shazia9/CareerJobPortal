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
using CareerCloud.BusinessLogicLayer;

namespace CareerCloud.MVC.Controllers
{
    public class CompanyProfileController : Controller
    {
        //private CareerCloudContext db = new CareerCloudContext();
        private CompanyProfileLogic cplogic;

        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>();
            cplogic = new CompanyProfileLogic(repo);
        }
        // GET: CompanyProfile
        public ActionResult Index()
        {
            //return View(db.CompanyProfile.ToList());
            return View(cplogic.GetAll());
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            CompanyProfilePoco companyProfilePoco = cplogic.Get(id);

            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                //companyProfilePoco.Id = Guid.NewGuid();
                //db.CompanyProfile.Add(companyProfilePoco);
                //db.SaveChanges();
                CompanyProfilePoco[] CompanyProfile = new CompanyProfilePoco[] { companyProfilePoco };
                cplogic.Add(CompanyProfile);
                return RedirectToAction("Index");
            }

            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            CompanyProfilePoco companyProfilePoco = cplogic.Get(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationDate,CompanyWebsite,ContactPhone,ContactName,CompanyLogo")] CompanyProfilePoco companyProfilePoco)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(companyProfilePoco).State = EntityState.Modified;
                //db.SaveChanges();
               CompanyProfilePoco[] companyProfile = new CompanyProfilePoco[] { companyProfilePoco };
                cplogic.Update(companyProfile);
                return RedirectToAction("Index");
            }
            return View(companyProfilePoco);
        }

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfilePoco companyProfilePoco = cplogic.Get(id);
            if (companyProfilePoco == null)
            {
                return HttpNotFound();
            }
            return View(companyProfilePoco);
        }

        // POST: CompanyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            //CompanyProfilePoco companyProfilePoco = db.CompanyProfile.Find(id);
            //db.CompanyProfile.Remove(companyProfilePoco);
            //db.SaveChanges();
            CompanyProfilePoco companyProfilePoco = cplogic.Get(id);
            CompanyProfilePoco[] companyProfile = new CompanyProfilePoco[] { companyProfilePoco };
            cplogic.Delete(companyProfile);
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
