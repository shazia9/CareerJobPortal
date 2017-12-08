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
    public class ApplicantSkillController : ApiController
    {
        private ApplicantSkillLogic _logic;
        public ApplicantSkillController()
        {
            var repo = new EFGenericRepository<ApplicantSkillPoco>(false);
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("Skill/ApplicantSkill")]
        [ResponseType(typeof(List<ApplicantSkillPoco>))]

        public IHttpActionResult GetApplicantSkill(Guid Id)
        {
           ApplicantSkillPoco app = _logic.Get(Id);
            if (app == null)
            {
                return NotFound();
            }
            return Ok(app);
        }

        public IHttpActionResult GetAllApplicantSkill()
        {
            List<ApplicantSkillPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Skill")]

        public IHttpActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Skill")]
        public IHttpActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Skill")]
        public IHttpActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
