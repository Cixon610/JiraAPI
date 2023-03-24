using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaJira.Models;

namespace JiraAPI
{
    public class SysConfig
    {
        private static Lazy<SysConfig> _Instance = new Lazy<SysConfig>(() => new SysConfig());
        public static SysConfig Instance => _Instance.Value;
        public string JiraUrl => ConfigurationManager.AppSettings["Jira:Url"];
        public JiraProjectConfig RyanTask => new JiraProjectConfig
        {
            ID = ConfigurationManager.AppSettings["Jira:ID"],
            Name = ConfigurationManager.AppSettings["Jira:Name"],
            Tag = ConfigurationManager.AppSettings["Jira:Tag"],
            UserName = ConfigurationManager.AppSettings["Jira:UserName"],
            Password = ConfigurationManager.AppSettings["Jira:Password"],
        };
    }
}
