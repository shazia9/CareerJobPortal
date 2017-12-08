using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyDescription))
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription in Company_description for {poco.Id} cannot be empty"));
                }
                else if (poco.CompanyDescription.Length<=2)
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription in Company_Description for {poco.Id} must be Greator than two characters"));
                }
                if (string.IsNullOrEmpty(poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName in Company_Description for {poco.Id} cannot be empty"));
                    
                }
                else if(poco.CompanyName.Length<=2)
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName in Company_Description for {poco.Id} must be Greator than two characters "));
                }

            }
            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override CompanyDescriptionPoco Get(Guid id)
        {
            return base.Get(id);
        }
        public override List<CompanyDescriptionPoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
