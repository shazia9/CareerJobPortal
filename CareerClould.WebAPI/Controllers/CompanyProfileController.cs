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
    public class CompanyProfileController : ApiController
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            var repo = new EFGenericRepository<CompanyProfilePoco>(false);
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("Profile/{CompanyProfileId}")]
        [ResponseType(typeof(CompanyProfilePoco))]

        public IHttpActionResult GetCompanyProfile(Guid Id)
        {
            CompanyProfilePoco appId = _logic.Get(Id);
            if (appId == null)
            {
                return NotFound();
            }
            return Ok(appId);

        }
        [HttpGet]
        [Route("Profile/CompanyProfile")]
        [ResponseType(typeof(List<CompanyProfilePoco>))]

        public IHttpActionResult GetCompanyProfile()
        {
            List<CompanyProfilePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Profile")]

        public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] app)
        {
            _logic.Add(app);
            return Ok();

        }

        [HttpPut]
        [Route("Profile")]
        public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] app)
        {
            _logic.Update(app);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] app)
        {
            _logic.Delete(app);
            return Ok();
        }
    }
}
