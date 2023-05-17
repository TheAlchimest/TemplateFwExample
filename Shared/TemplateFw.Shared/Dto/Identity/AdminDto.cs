using System;

namespace TemplateFwExample.Shared.Dtos.Identity
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public bool? CanManageServices { get; set; }
        public bool? CanManageFaqs { get; set; }
        public bool? CanManagePolls { get; set; }
        public bool? CanManageVotings { get; set; }
        public bool? CanManageComplaints { get; set; }
        public bool? CanManageAnnounces { get; set; }
        public bool? CanManageAdmins { get; set; }
        public bool? CanManageMobile { get; set; }
        public bool? CanManageIndividualsAccounts { get; set; }
        public bool? CanManageInternalBusinessAccounts { get; set; }
        public bool? CanManageExternalBusinessAccounts { get; set; }
        public bool? CanManageGovernmentAccounts { get; set; }
        public bool? CanManageServiceProvidersAccounts { get; set; }
        public bool? CanManageSecurityAccounts { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
