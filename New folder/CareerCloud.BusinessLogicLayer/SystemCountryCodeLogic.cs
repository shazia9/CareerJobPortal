﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
   public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco> _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repo)
        {
            _repository = repo;
        }

        protected void verify (SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach(var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, $"Code in SystemCountryCode for {poco.Code} cannot be empty"));

                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, $"Name in SystemCountrycode for {poco.Code} cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }

        public void Add(SystemCountryCodePoco[] pocos)
        {
            verify(pocos);
            

            _repository.Add(pocos);

        }

        public void Update(SystemCountryCodePoco[]pocos)
        {
            verify(pocos);
            _repository.Update(pocos);


        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
           
            _repository.Remove(pocos);
        }

        public  List<SystemCountryCodePoco> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public  SystemCountryCodePoco Get(string Code)
        {
            return _repository.GetSingle(c => c.Code == Code);
        }



    }
}
