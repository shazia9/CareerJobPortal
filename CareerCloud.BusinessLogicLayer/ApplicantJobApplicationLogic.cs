using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (ApplicantJobApplicationPoco poco in pocos)
            {
                if (poco.ApplicationDate > DateTime.Now.Date)
                {
                    exceptions.Add(new ValidationException(110, $"Application Date for Applicant_Job_Application{poco.Id} Cannot be greator than today"));

                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
            public override void Add(ApplicantJobApplicationPoco[] pocos)
            {
            Verify(pocos);
            base.Add(pocos);
            }

        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override List<ApplicantJobApplicationPoco> GetAll()
        {
            return base.GetAll();
        }

        public override ApplicantJobApplicationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public void Delete(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
