using GamaJira.Enums;
using GamaJira.Interface;
using GamaJira.Models;
using GamaJira.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira
{
    public class JiraProjectFactory
    {
        public static IGJProject CreateJiraProject(GJProjectType projectType, string jiraUrl, GJProject config)
        {
            switch (projectType)
            {
                case GJProjectType.GamaCert:
                    return new GamaCert(jiraUrl, config);
                case GJProjectType.WorkFlow:
                    return new WorkFlow(jiraUrl, config);
                case GJProjectType.RyanTask:
                    return new RyanTask(jiraUrl, config);
                default:
                    return null;
            }
        }
    }
}
