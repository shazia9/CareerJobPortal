using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext
   : DbContext
    {

        public CareerCloudContext():base("dbconnection")
        {

        }
        public CareerCloudContext(bool createProxy=true) : base("dbconnection")
        {
            Configuration.ProxyCreationEnabled = createProxy;
        }

        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }

        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }

        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocationpoco { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { set; get; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCode { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantEducation)
                .WithRequired(ae => ae.ApplicantProfile)
                .HasForeignKey(e => e.Applicant);
                

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantJobApplicant)
                .WithRequired(aj => aj.ApplicantProfile)
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantWorkHistory)
                .WithRequired(aw => aw.ApplicantProfile)
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantResume)
                .WithRequired(ar => ar.ApplicantProfile)
                .HasForeignKey(e => e.Applicant);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(ap => ap.ApplicantSkill)
                .WithRequired(ak => ak.ApplicantProfile)
                .HasForeignKey(e => e.Applicant);



            modelBuilder.Entity<SystemCountryCodePoco>()
                .Ignore(sc => sc.ApplicantProfile);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .Ignore(sc => sc.ApplicantWorkHistory);







            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cp => cp.ApplicantJobApplication)
                .WithRequired(aj => aj.CompanyJob)
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobDescription)
                .WithRequired(cd => cd.CompanyJob)
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobEducation)
                .WithRequired(ce => ce.CompanyJob)
                .HasForeignKey(e => e.Job);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(cj => cj.CompanyJobSkill)
                .WithRequired(cs => cs.CompanyJob)
                .HasForeignKey(e => e.Job);





            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cp => cp.CompanyJob)
                .WithRequired(cj => cj.CompanyProfile)
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cp => cp.CompanyDescription)
                .WithRequired(cd => cd.CompanyProfile)
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cp => cp.CompanyLocation)
                .WithRequired(cl => cl.CompanyProfile)
                .HasForeignKey(e => e.Company);

            modelBuilder.Entity<SystemLanguageCodePoco>()
               .Ignore(sl => sl.CompanyDescription);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(sr => sr.SecurityLoginRole)
                .WithRequired(sl => sl.SecurityRole)
                .HasForeignKey(e => e.Role);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(sl => sl.SecurityLoginRole)
                .WithRequired(sr => sr.SecurityLogin)
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(sl => sl.ApplicantProfile)
                .WithRequired(ap => ap.SecurityLogin)
                .HasForeignKey(e => e.Login);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(sl => sl.SecurityLoginLog)
                .WithRequired(sg => sg.SecurityLogin)
                .HasForeignKey(e => e.Login);


            //mapping for properties
            //timestamp
            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<ApplicantEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<ApplicantJobApplicationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<ApplicantProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<ApplicantSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<ApplicantWorkHistoryPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyJobEducationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyJobSkillPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyJobPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyJobDescriptionPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyLocationPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<CompanyProfilePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<SecurityLoginPoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();

            modelBuilder.Entity<SecurityLoginsRolePoco>()
                .Property(e => e.TimeStamp)
                .IsRowVersion();
                
                


















        }
    }
}
