using GamaJira.Constant;
using GamaJira.Interfaces;
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
        public static IGJProject CreateJiraProject(string jiraUrl, GJProject config)
        {
            switch (config.ClassName)
            {
                case nameof(OA):
                    return new OA(jiraUrl, config);
                case nameof(Hear):
                    return new Hear(jiraUrl, config);
                case nameof(Others):
                    return new Others(jiraUrl, config);
                case nameof(RyanTask):
                    return new RyanTask(jiraUrl, config);
                case nameof(SA35):
                    return new SA35(jiraUrl, config);
            }

            return null;
        }
    }
}
