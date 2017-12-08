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
    public class CompanyJobsDescriptionController : ApiController
    {
        private CompanyJobDescriptionLogic _logic;
        public CompanyJobsDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("JobDescription/{CompanyJobDescriptionId}")]
        [ResponseType(typeof(CompanyJobDescriptionPoco))]

        public IHttpActionResult GetCompanyJobsDescription(Guid Id)
        {
            CompanyJobDescriptionPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }
        [HttpGet]
        [Route("JobDescription/CompanyJobsDescription")]
        [ResponseType(typeof(List<CompanyJobDescriptionPoco>))]

        public IHttpActionResult GetCompanyJobsDescription()
        {
            List<CompanyJobDescriptionPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("JobDescription")]

        public IHttpActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("JobDescription")]
        public IHttpActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("JobDescription")]
        public IHttpActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
