using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
    {
        public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
        {
        }

        protected override void Verify(ApplicantSkillPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach(var poco in pocos)
            {
                if (poco.StartMonth >12)
                {
                    exceptions.Add(new ValidationException(101, $"StartMonth for Applicant_Skill{poco.Id} cannot be greator than 12"));
                }

                if (poco.EndMonth >12)
                {
                    exceptions.Add(new ValidationException(102, $"EndMonth for Applicant_Skill{poco.Id} cannot be greator than 12"));
                }

                if (poco.StartYear<1900)
                {
                    exceptions.Add(new ValidationException(103, $"StartYear for Applicant_Skill{poco.Id}cannot be less than 1900"));
                }

                if (poco.EndYear<poco.StartYear)
                {
                    exceptions.Add(new ValidationException(104, $"End Year for Applicant_Skill{poco.Id} cannot be less Start Year"));
                }
            }
            if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override ApplicantSkillPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantSkillPoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(ApplicantSkillPoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
