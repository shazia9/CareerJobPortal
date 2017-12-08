using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {

        }

        protected override void Verify(ApplicantEducationPoco[] pocos)

        {



            List<ValidationException> exception = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exception.Add(new ValidationException(107, $"Major for ApplicantEducation{poco.Id} Cannot be empty"));
                }
                else if (poco.Major.Length < 3)
                {
                    exception.Add(new ValidationException(107, $"Major for ApplicantEducation{poco.Id} Cannot be less than 3 characters"));

                }

                if (poco.StartDate > DateTime.Now.Date)
                {
                    exception.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} Cannot be greater than today"));

                }

                if (poco.CompletionDate < poco.StartDate)
                {
                    exception.Add(new ValidationException(109, $"Completion date for ApplicantEducation{poco.Id} cannot be earlier than StartDate"));
                }
            }
            if (exception.Count > 0)
            {
                throw new AggregateException(exception);
            }


        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);

            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public void Delete(ApplicantEducationPoco[] pocos)
        {
           
            base.Delete(pocos);
        }

        public override List<ApplicantEducationPoco> GetAll()
        {
            return base.GetAll();
        }

        public override ApplicantEducationPoco Get(Guid id)
        {
            return base.Get(id);
        }
    }
}
