using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
    {
        public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyLocationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CountryCode))
                {
                    exceptions.Add(new ValidationException(500, $"Country Code in Company_Location for {poco.Id} cannot be empty"));

                }
                if(string.IsNullOrEmpty(poco.Province))
                {
                    exceptions.Add(new ValidationException(501, $"Province in Company_Location for {poco.Id} cannot be empty"));

                }
                 if (string.IsNullOrEmpty(poco.Street))
                {
                    exceptions.Add(new ValidationException(502, $"Street in Company_Location for {poco.Id} cannot be empty"));
                }
                if(string.IsNullOrEmpty(poco.City))
                {
                    exceptions.Add(new ValidationException(503, $"City in Company_Location for {poco.Id}cannot be empty"));
                }
                 if (string.IsNullOrEmpty(poco.PostalCode))
                {
                    exceptions.Add(new ValidationException(504, $"Postal Code in company_Location for {poco.Id} cannot be empty"));
                }


            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }

        public override void Add(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override CompanyLocationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyLocationPoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(CompanyLocationPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }

   

}
