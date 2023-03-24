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

namespace JiraAPI.Controllers
{
    [Route("api/jira/{action}")]
    public class JiraController : ApiController
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JiraController));
        public string GetIssue()
        {
            return "";
        }
        public string CreateIssue()
        {
            return "";
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
