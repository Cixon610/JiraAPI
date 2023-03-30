using Atlassian.Jira;
using GamaJira;
using GamaJira.Constant;
using GamaJira.Models;
using GamaJira.Projects;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace JiraAPI.Controllers
{
    [Route("api/jira/{action}")]
    public class JiraController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JiraController));
        [HttpPost]
        public string CreateIssue()
        {
            var settings = SysConfig.Instance.JiraProject.Projects
                .FirstOrDefault(x => x.ClassName == nameof(RyanTask));

            //var jira = JiraProjectFactory.CreateJiraProject(SysConfig.Instance.JiraProject.Url, settings);
            return "";
            //var issue = jira.CreateIssue();
            //return JsonConvert.SerializeObject(issue,Formatting.Indented);
        }
        [HttpPost]
        public string WebHookTest(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            logger.Debug(json);
            return json;
        }
    }
}
