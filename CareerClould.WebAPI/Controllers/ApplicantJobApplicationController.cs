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
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;
        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("JobApplication/{ApplicantJobApplicationId}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]

        public IHttpActionResult GetApplicantJobApplication(Guid Id)
        {
            ApplicantJobApplicationPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("JobApplication/ApplicantJobApplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]

        public IHttpActionResult GetApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("ApplicantJob")]

        public IHttpActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] appJob)
        {
            _logic.Add(appJob);
            return Ok();

        }

        [HttpPut]
        [Route("ApplicantJob")]
        public IHttpActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] appJob)
        {
            _logic.Update(appJob);
            return Ok();
        }

        [HttpDelete]
        [Route("ApplicantJob")]
        public IHttpActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] appJob)
        {
            _logic.Delete(appJob);
            return Ok();
        }
    }
}
