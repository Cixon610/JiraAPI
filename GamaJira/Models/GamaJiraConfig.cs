using System.Collections.Generic;

namespace GamaJira.Models
{
    /// <summary>
    /// Gama Jira Config
    /// </summary>
    public class GamaJiraConfig
    {
        public string Url { get; set; }
        public GJProject[] Projects { get; set; }
    }

    /// <summary>
    /// Gama Jira Project
    /// </summary>
    public class GJProject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string ClassName { get; set; }
        public GJAuth Auth { get; set; }
        public List<GJIssueType> IssueTypes { get; set; }
    }

    /// <summary>
    /// Gama Jira Auth
    /// </summary>
    public class GJAuth
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Gama Jira Project Detail
    /// </summary>
    public class GJIssueType
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
    }
}
