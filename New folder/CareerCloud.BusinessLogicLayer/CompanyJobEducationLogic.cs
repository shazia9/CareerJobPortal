using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
             foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(200, $"Major in Company_job_education for {poco.Id} must be at least 2 characters"));
                }
                else if (poco.Major.Length<2)
                {
                    exceptions.Add(new ValidationException(200, $"Major in Company_job_education for {poco.Id} must be at least 2 characters"));
                }

                if (poco.Importance<0)
                {
                    exceptions.Add(new ValidationException(201, $"Importance in Company_job_education for {poco.Id} cannot be less than 0 "));
                }

               
            }
             if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override CompanyJobEducationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobEducationPoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
