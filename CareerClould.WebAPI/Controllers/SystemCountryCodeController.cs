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
    [RoutePrefix("api/CareerCloud/System/v1")]
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _code;

        public SystemCountryCodeController()
        {
            var repo = new EFGenericRepository<SystemCountryCodePoco>(false);
            _code = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("CountryCode/{Code}")]
        [ResponseType(typeof(SystemCountryCodePoco))]

        public IHttpActionResult GetSystemCountryCode(String code)
        {
            SystemCountryCodePoco syscode = _code.Get(code);
            if (syscode == null)
            {
                return NotFound();
            }
            return Ok(syscode);

        }

        [HttpGet]
        [Route("CountryCode")]
        [ResponseType(typeof(List<SystemCountryCodePoco>))]

        public IHttpActionResult GetAllSystemCountryCode()
        {
            List<SystemCountryCodePoco> Pocos = _code.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("CountryCode")]

        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] syscode)
        {
            _code.Add(syscode);
            return Ok();

        }

        [HttpPut]
        [Route("CountryCode")]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] syscode)
        {
            _code.Update(syscode);
            return Ok();
        }

        [HttpDelete]
        [Route("CountryCode")]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] syscode)
        {
            _code.Delete(syscode);
            return Ok();
        }
    }
}
