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
    [RoutePrefix("api/Security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            var repo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginsLog/{loginLogId}")]
        [ResponseType(typeof(SecurityLoginsLogPoco))]

        public IHttpActionResult GetSecurityLoginLog(Guid Id)
        {
            SecurityLoginsLogPoco seclogin = _logic.Get(Id);
            if (seclogin == null)
            {
                return NotFound();
            }
            return Ok(seclogin);

        }

        [HttpGet]
        [Route("loginsLog")]
        [ResponseType(typeof(List<SecurityLoginsLogPoco>))]

        public IHttpActionResult GetAllSecurityLoginLog()
        {
            List<SecurityLoginsLogPoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("loginsLog")]

        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLogin)
        {
            _logic.Add(securityLogin);
            return Ok();

        }

        [HttpPut]
        [Route("loginsLog")]
        public IHttpActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLogin)
        {
            _logic.Update(securityLogin);
            return Ok();
        }

        [HttpDelete]
        [Route("loginsLog")]
        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] securityLogin)
        {
            _logic.Delete(securityLogin);
            return Ok();
        }
    }
}
