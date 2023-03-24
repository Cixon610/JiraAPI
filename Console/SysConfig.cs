using System;
using System.Collections.Generic;
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
        public string GamaJiraUrl => "https://gamania-group.atlassian.net/";
        public JiraProjectConfig GamaCert => new JiraProjectConfig
        {
            ID ="",
            Name = "GHQ - GamaCert",
            Tag = "GGC",
            UserName = "g-ryanchang@gamania.com",
            Password = "ATATT3xFfGF0_r0y41m_G579pvYWODFovphDhTuwS1PIwAmsjmkKHo6Ngg_pu_gPVw1ASFGJ2IS2Uv7PQZw1r73xZHGEQY9XRKt1sueNLrkRsjEWUw168wRTP-AWjrhUvIsZE_IqiduSGcKv6ERQ45EGB9VzSfOkHX0MaE8ILaI7LVq5Y6r2ono=02676CEC",
        };
        public JiraProjectConfig WorkFlow => new JiraProjectConfig
        {
            ID = "",
            Name = "GHQ - Workflow",
            Tag = "WOR",
            UserName = "g-ryanchang@gamania.com",
            Password = "ATATT3xFfGF0_r0y41m_G579pvYWODFovphDhTuwS1PIwAmsjmkKHo6Ngg_pu_gPVw1ASFGJ2IS2Uv7PQZw1r73xZHGEQY9XRKt1sueNLrkRsjEWUw168wRTP-AWjrhUvIsZE_IqiduSGcKv6ERQ45EGB9VzSfOkHX0MaE8ILaI7LVq5Y6r2ono=02676CEC",
        };
        public JiraProjectConfig RyanTask => new JiraProjectConfig
        {
            ID = "",
            Name = "Ryan Task",
            Tag = "RYT",
            UserName = "g-ryanchang@gamania.com",
            Password = "ATATT3xFfGF0_r0y41m_G579pvYWODFovphDhTuwS1PIwAmsjmkKHo6Ngg_pu_gPVw1ASFGJ2IS2Uv7PQZw1r73xZHGEQY9XRKt1sueNLrkRsjEWUw168wRTP-AWjrhUvIsZE_IqiduSGcKv6ERQ45EGB9VzSfOkHX0MaE8ILaI7LVq5Y6r2ono=02676CEC",
        };
    }
}
