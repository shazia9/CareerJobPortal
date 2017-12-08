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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;
        public CompanyJobController()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>(false);
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("Job/{CompanyJobId}")]
        [ResponseType(typeof(CompanyJobPoco))]

        public IHttpActionResult GetCompanyJob(Guid Id)
        {
            CompanyJobPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }
        [HttpGet]
        [Route("Job/CompanyJob")]
        [ResponseType(typeof(List<CompanyJobPoco>))]

        public IHttpActionResult GetCompanyJob()
        {
            List<CompanyJobPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Job")]

        public IHttpActionResult PostCompanyJob([FromBody] CompanyJobPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Job")]
        public IHttpActionResult PutCompanyJob([FromBody] CompanyJobPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Job")]
        public IHttpActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
