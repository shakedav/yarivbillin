using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing.DataObjects
{
    public class Project
    {
        public int ProjectCode {get;  set;}
        public string ProjectName { get; set; }
        public string ContactMan { get; set; }
        public string ContactManGendre { get; set; }
        public string ContactManDescription { get; set; }
        public string ContactManPhone { get; set; }
        public string ContactManMail { get; set; }
        public string InviterProjectName { get; set; }
        public int InviterProjectCode { get; set; }
        public string ProjectDescription { get; set; }
        public int ClientCode { get; set; }

        public Project()
        {
        }

        public Project(int projectCode, int clientCode)
        {
            ProjectCode = projectCode;
            ClientCode = clientCode;
        }


        public Project(int projectCode, string projectName, string contactMan, string contactManGendre, string contactManDescription
                        , string contactManPhone, string contactManMail, string inviterProjectName, int inviterProjectCode, string projectDescription, int clientCode)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
            ContactMan = contactMan;
            ContactManGendre = contactManGendre;
            ContactManDescription = contactManDescription;
            ContactManPhone = contactManPhone;
            ContactManMail = contactManMail;
            InviterProjectName = inviterProjectName;
            InviterProjectCode = inviterProjectCode;
            ProjectDescription = projectDescription;
            ClientCode = clientCode;
        }
    }
}
