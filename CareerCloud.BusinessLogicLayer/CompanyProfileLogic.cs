using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using System.IO;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            List<string> myextention = new List<string> { ".com", ".ca", ".biz" };
            foreach(var poco in pocos)
            {
                string extention = Path.GetExtension(poco.CompanyWebsite);
                if (!myextention.Contains(extention))
                {
                    exceptions.Add(new ValidationException(600, $"Company Website in Company_profile for {poco.Id} websites must end with the following extensions – .ca, .com, .biz"));
                }

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, $"Contact Phone in Company_profile for {poco.Id} cannot be empty"));
                }
                else
                {
                    string[] phoneparts = poco.ContactPhone.Split('-');
                    if (phoneparts.Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, $"Contact phone in Company_profile for {poco.Id} Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                    else
                    {
                        if (phoneparts[0].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"Contact phone in Company_profile for {poco.Id} Must correspond to a valid phone number (e.g. 416-555-1234)"));
                        }
                        else if (phoneparts[1].Length != 3)
                        {
                            exceptions.Add(new ValidationException(601, $"Contact phone in Company_profile for {poco.Id} Must correspond to a valid phone number (e.g. 416-555-1234)"));
                        }
                        else if (phoneparts[2].Length!=4)
                        {
                            exceptions.Add(new ValidationException(601, $"Contact phone in Company_profile for {poco.Id} Must correspond to a valid phone number (e.g. 416-555-1234)"));
                        }
                                
                        
                    }
                }
                
                             
               
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        public override CompanyProfilePoco Get(Guid id)
        {
            return base.Get(id);
        }
        public override List<CompanyProfilePoco> GetAll()
        {
            return base.GetAll();
        }

        public void Delete(CompanyProfilePoco[] pocos)
        {
           
            base.Delete(pocos);

        }
    }
}
