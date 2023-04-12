using GamaJira.Constant;
using GamaJira.Interfaces;
using GamaJira.Models;
using GamaJira.Projects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira
{
    public class JiraProjectFactory
    {
        public GamaJiraConfig JiraProject { get; set; }
        /// <summary>
        ///  Path e.g. @".\SystemConfigs\JiraProjectConfig.json"
        /// </summary>
        /// <param name="JsonConfigPath"></param>
        public JiraProjectFactory(string JsonConfigPath) 
        {
            JiraProject = JsonConvert.DeserializeObject<GamaJiraConfig>(
                File.ReadAllText(JsonConfigPath, Encoding.UTF8));
        }
        public JiraProjectFactory(GamaJiraConfig Config)
        {
            JiraProject = Config;
        }
        public IGJProject CreateJiraProject(string className)
        {
            var projectSettings = JiraProject.Projects.FirstOrDefault(x => x.ClassName == className);
            projectSettings = projectSettings ?? JiraProject.Projects.FirstOrDefault(x => x.ClassName == nameof(Other));
            switch (className)
            {
                case nameof(OA):
                    return new OA(JiraProject.Url, projectSettings);
                case nameof(Hear):
                    return new Hear(JiraProject.Url, projectSettings);
                case nameof(SA35):
                    return new SA35(JiraProject.Url, projectSettings);
                default:
                    return new Other(JiraProject.Url, projectSettings);
            }
        }
    }
}
