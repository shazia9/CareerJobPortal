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
    public class SecurityLoginsRoleController : ApiController
    {
        private SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            var repo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("loginsRole/{loginsRoleId}")]
        [ResponseType(typeof(SecurityLoginsRolePoco))]

        public IHttpActionResult GetSecurityLoginsRole(Guid Id)
        {
            SecurityLoginsRolePoco seclogin = _logic.Get(Id);
            if (seclogin == null)
            {
                return NotFound();
            }
            return Ok(seclogin);

        }

        [HttpGet]
        [Route("loginsRole")]
        [ResponseType(typeof(List<SecurityLoginsRolePoco>))]

        public IHttpActionResult GetAllSecurityLoginRole()
        {
            List<SecurityLoginsRolePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("loginsRole")]

        public IHttpActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLogin)
        {
            _logic.Add(securityLogin);
            return Ok();

        }

        [HttpPut]
        [Route("loginsRole")]
        public IHttpActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLogin)
        {
            _logic.Update(securityLogin);
            return Ok();
        }

        [HttpDelete]
        [Route("loginRole")]
        public IHttpActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] securityLogin)
        {
            _logic.Delete(securityLogin);
            return Ok();
        }
    }
}
