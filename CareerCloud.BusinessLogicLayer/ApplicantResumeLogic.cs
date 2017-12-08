﻿using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
    {
        public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
        {
        }

        protected override void Verify(ApplicantResumePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

           foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Resume))
                {
                    exceptions.Add(new ValidationException(113, $"Resume for Applicant_Resume{poco.Id}cannot be empty"));
                }

                
            }
           if (exceptions.Count>0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override ApplicantResumePoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantResumePoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(ApplicantResumePoco[] pocos)
        {
            Verify(pocos);
            base.Delete(pocos);
        }
    }
}
