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
    public class CompanyLocationController : ApiController
    {
        private CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            var repo = new EFGenericRepository<CompanyLocationPoco>(false);
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("Location/{CompanyLocationId}")]
        [ResponseType(typeof(CompanyLocationPoco))]

        public IHttpActionResult GetCompanyLocation(Guid Id)
        {
            CompanyLocationPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("Location/CompanyLocation")]
        [ResponseType(typeof(List<CompanyLocationPoco>))]

        public IHttpActionResult GetCompanyLocation()
        {
            List<CompanyLocationPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Location")]

        public IHttpActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Location")]
        public IHttpActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Skill")]
        public IHttpActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
