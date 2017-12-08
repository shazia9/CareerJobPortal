using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class ApplicantResumeController : Controller
    {
        // GET: ApplicantResume

        private ApplicantResumeLogic arlogic;
        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>();
            arlogic = new ApplicantResumeLogic(repo);
        }
        public ActionResult Index(Guid Id)
        {
            return View(arlogic.GetAll().Where(a => a.Applicant == Id).ToList());
        }
    }
}