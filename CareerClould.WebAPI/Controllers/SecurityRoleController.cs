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
    public class SecurityRoleController : ApiController
    {
        private SecurityRoleLogic _logic;

        public SecurityRoleController()
        {
            var repo = new EFGenericRepository<SecurityRolePoco>(false);
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("Role/{RoleId}")]
        [ResponseType(typeof(SecurityRolePoco))]

        public IHttpActionResult GetSecurityRole(Guid Id)
        {
            SecurityRolePoco seclogin = _logic.Get(Id);
            if (seclogin == null)
            {
                return NotFound();
            }
            return Ok(seclogin);

        }

        [HttpGet]
        [Route("Role")]
        [ResponseType(typeof(List<SecurityRolePoco>))]

        public IHttpActionResult GetAllSecurityRole()
        {
            List<SecurityRolePoco> Pocos = _logic.GetAll();
            return Ok(Pocos);

        }

        [HttpPost]
        [Route("Role")]

        public IHttpActionResult PostSecurityRole([FromBody] SecurityRolePoco[] securityLogin)
        {
            _logic.Add(securityLogin);
            return Ok();

        }

        [HttpPut]
        [Route("Role")]
        public IHttpActionResult PutSecurityRole([FromBody] SecurityRolePoco[] securityLogin)
        {
            _logic.Update(securityLogin);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public IHttpActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] securityLogin)
        {
            _logic.Delete(securityLogin);
            return Ok();
        }
    }
}
