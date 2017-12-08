using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CareerCloud.WCF
{
    [ServiceContract]
    interface IApplicant
    {
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string Id);

        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);

        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);

        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);

        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string Id);

        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);

        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string Id);

        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);

        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string Id);

        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);



    }
}
