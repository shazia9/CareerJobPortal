using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CareerCloud.Pocos;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareerCloud.MVC.Models
{
    public class ApplicantJobsviewmodel
    {

        //Column from ApplicantJobApplication
        [Key]
        public Guid Job { get; set; }
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
        //column from CompanyJobDescription
        public string JobName { get; set; }
        [Column("Job_Descriptions")]
        public string JobDescriptions { get; set; }

        //column from CompanyDescription
        [Column("Company_Name")]
        public string CompanyName { get; set; }

    }
}