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
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);
            _logic = new SystemLanguageCodeLogic(repo);

        }

        [HttpGet]
        [Route("LanguageCode/{LangId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]

        public IHttpActionResult GetSystemLanguageCode(String code)
        {
            SystemLanguageCodePoco syscode = _logic.Get(code);
            if (syscode == null)
            {
                return NotFound();
            }
            return Ok(syscode);

        }

        [HttpGet]
        [Route("LanguageCode")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]

        public IHttpActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("LanguageCode")]

        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] syscode)
        {
            _logic.Add(syscode);
            return Ok();

        }

        [HttpPut]
        [Route("LanguageCode")]
        public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] syscode)
        {
            _logic.Update(syscode);
            return Ok();
        }

        [HttpDelete]
        [Route("LanguageCode")]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] syscode)
        {
            _logic.Delete(syscode);
            return Ok();
        }
    }
}
