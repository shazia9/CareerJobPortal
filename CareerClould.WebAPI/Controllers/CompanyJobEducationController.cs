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
    [RoutePrefix("api/Company/v1")]
    public class CompanyJobEducationController : ApiController
    {
        private CompanyJobEducationLogic _logic;
        public CompanyJobEducationController()
        {
            var repo = new EFGenericRepository<CompanyJobEducationPoco>(false);
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("JobEducation/{CompanyJobEducationId}")]
        [ResponseType(typeof(CompanyJobEducationPoco))]

        public IHttpActionResult GetCompanyJobEducation(Guid Id)
        {
            CompanyJobEducationPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }
        [HttpGet]
        [Route("JobEducation/CompanyJobEducation")]
        [ResponseType(typeof(List<CompanyJobEducationPoco>))]

        public IHttpActionResult GetCompanyJobEducation()
        {
            List<CompanyJobEducationPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("JobEducation")]

        public IHttpActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("JobEducation")]
        public IHttpActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("JobEducation")]
        public IHttpActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
