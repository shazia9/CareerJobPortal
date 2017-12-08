using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerClould.WebAPI.Controllers
{
    [RoutePrefix("api/Applicant/v1")]
    public class ApplicantProfileController : ApiController
    {
        private ApplicantProfileLogic _logic;
        public ApplicantProfileController()
        {
            var repo = new EFGenericRepository<ApplicantProfilePoco>(false);
            _logic = new ApplicantProfileLogic(repo);
        }
        [HttpGet]
        [Route("Profile/{ApplicantProfileId}")]
        [ResponseType(typeof(ApplicantProfilePoco))]

        public IHttpActionResult GetApplicantProfile(Guid Id)
        {
            ApplicantProfilePoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("Profile/ApplicantProfile")]
        [ResponseType(typeof(List<ApplicantProfilePoco>))]

        public IHttpActionResult GetApplicantProfile()
        {
            List<ApplicantProfilePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Profile")]

        public IHttpActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] appJob)
        {
            _logic.Add(appJob);
            return Ok();

        }

        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] appJob)
        {
            _logic.Update(appJob);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public IHttpActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] appJob)
        {
            _logic.Delete(appJob);
            return Ok();
        }
    }
}
