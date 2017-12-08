using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistoryLogic : BaseLogic<ApplicantWorkHistoryPoco>
    {
        public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
        {
        }

        protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(var poco in pocos)
            {
                if (poco.CompanyName.Length<=2)
                {
                    exceptions.Add(new ValidationException(105, $"CompanyName in Applicant_Work_History for {poco.Id} cannot be less than 2 Characters"));
                }
            }

            if (exceptions.Count >0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override ApplicantWorkHistoryPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantWorkHistoryPoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(ApplicantWorkHistoryPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
