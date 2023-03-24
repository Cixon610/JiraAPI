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
        public static IJiraProject CreateJiraProject(JiraProjectType projectType, string jiraUrl, JiraProjectConfig config)
        {
            switch (projectType)
            {
                case JiraProjectType.GamaCert:
                    return new GamaCert(jiraUrl, config);
                case JiraProjectType.WorkFlow:
                    return new WorkFlow(jiraUrl, config);
                case JiraProjectType.RyanTask:
                    return new RyanTask(jiraUrl, config);
                default:
                    return null;
            }
        }
    }
}
