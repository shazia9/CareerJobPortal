using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CareerCloud.MVC.Models
{
    public class JobPostVM
    {

        //CompanyJob Table
        [Key]
        public Guid Company { get; set; }
        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }
        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }
        [Column("Is_Company_Hidden")]
        public bool IsCompanyHidden { get; set; }
        //CompanyJobDescription
        [Column("Job_Name")]
        public string JobName { get; set; }
        [Column("Job_Descriptions")]
        public string JobDescriptions { get; set; }
        //CompanyJobSkill
        public string Skill { get; set; }
        [Column("Skill_Level")]
        public string SkillLevel { get; set; }
        
        public int Importance { get; set; }
        //CompanyJobEducation
        public string Major { get; set; }
        
        public Int16 EduImportance { get; set; }
    }
}