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
    public class CompanyDescriptionController : ApiController
    {
        private CompanyDescriptionLogic _logic;
        public CompanyDescriptionController()
        {
            var repo = new EFGenericRepository<CompanyDescriptionPoco>(false);
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("Description/{CompanyDescriptionId}")]
        [ResponseType(typeof(CompanyDescriptionPoco))]

        public IHttpActionResult GetCompanyDescription(Guid Id)
        {
            CompanyDescriptionPoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }

        [HttpGet]
        [Route("Description/CompanyDescription")]
        [ResponseType(typeof(List<CompanyDescriptionPoco>))]

        public IHttpActionResult GetCompanyDescription()
        {
            List<CompanyDescriptionPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Description")]

        public IHttpActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Description")]
        public IHttpActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Description")]
        public IHttpActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
