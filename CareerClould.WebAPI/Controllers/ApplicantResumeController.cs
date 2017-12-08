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
    public class ApplicantResumeController : ApiController
    {
        private ApplicantResumeLogic _logic;
        public ApplicantResumeController()
        {
            var repo = new EFGenericRepository<ApplicantResumePoco>(false);
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("Resume/{ApplicantResumeId}")]
        [ResponseType(typeof(ApplicantResumePoco))]

        public IHttpActionResult GetApplicantResume(Guid Id)
        {
            ApplicantResumePoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("Resume/ApplicantResume")]
        [ResponseType(typeof(List<ApplicantResumePoco>))]

        public IHttpActionResult GetApplicantResume()
        {
            List<ApplicantResumePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Resume")]

        public IHttpActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Resume")]
        public IHttpActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Resume")]
        public IHttpActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
