using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        {
        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exception = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (poco.CurrentSalary <0)
                {
                    exception.Add(new ValidationException(111, $"Current Salary for Applicant_Profile{poco.Id} cannot be negative"));
                }

                if (poco.CurrentRate < 0)
                {
                    exception.Add(new ValidationException(112, $"Current Rate for Applicant_Profile{poco.Id} cannot be negative"));

                }

                if (exception.Count >0)
                {
                    throw new AggregateException(exception);
                }
            }
        }

        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override List<ApplicantProfilePoco> GetAll()
        {
            return base.GetAll();
        }

        public override ApplicantProfilePoco Get(Guid id)
        {
            return base.Get(id);
        }

        public void Delete(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
