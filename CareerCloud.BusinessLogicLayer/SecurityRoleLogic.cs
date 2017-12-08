using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class SecurityRoleLogic : BaseLogic<SecurityRolePoco>
    {
        public SecurityRoleLogic(DataAccessLayer.IDataRepository<SecurityRolePoco> repository) : base(repository)
        {
        }

        protected override void Verify(SecurityRolePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Role))
                {
                    exceptions.Add(new ValidationException(800, $"Role in Security_Role for {poco.Id} cannot be empty"));
                }
            }
            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(SecurityRolePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override SecurityRolePoco Get(Guid id)
        {
            return base.Get(id);
        }
        public override List<SecurityRolePoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(SecurityRolePoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
