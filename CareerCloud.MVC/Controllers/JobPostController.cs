using CareerCloud.BusinessLogicLayer;
using CareerCloud.MVC.Models;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerCloud.MVC.Controllers
{
    public class JobPostController : Controller
    {

        private CompanyJobLogic cjlogic;
        private CompanyJobDescriptionLogic cjdlogic;
        private CompanyJobSkillLogic cjslogic;
        private CompanyJobEducationLogic cjelogic;

        // GET: JobPost
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
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
    }

    
}