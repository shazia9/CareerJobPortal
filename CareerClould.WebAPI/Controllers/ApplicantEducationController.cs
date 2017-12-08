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
    [RoutePrefix("api/CareerCloud/Applicant/v1")]
    public class ApplicantEducationController : ApiController
    {
        private ApplicantEducationLogic _logic;
        public ApplicantEducationController()
        {
            var repo = new EFGenericRepository<ApplicantEducationPoco>(false);
            _logic = new ApplicantEducationLogic(repo);
        }
          
        [HttpGet]
        [Route("Education/{ApplicantEducationId}")]
        [ResponseType(typeof(ApplicantEducationPoco))]

        public IHttpActionResult GetApplicantEducation(Guid Id)
        {
            ApplicantEducationPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("Education/ApplicantEducation")]
        [ResponseType(typeof(List<ApplicantEducationPoco>))]

        public IHttpActionResult GetApplicantEducation()
        {
            List<ApplicantEducationPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Education")]

        public IHttpActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] appeducation)
        {
            _logic.Add(appeducation);
            return Ok();

        }

        [HttpPut]
        [Route("Education")]
        public IHttpActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] appeducation)
        {
            _logic.Update(appeducation);
            return Ok();
        }

        [HttpDelete]
        [Route("Education")]
        public IHttpActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] appeducation)
        {
            _logic.Delete(appeducation);
            return Ok();
        }

    }
}
