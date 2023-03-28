using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaJira.Models;
using Newtonsoft.Json;

namespace JiraAPI
{
    public class SysConfig
    {
        private static Lazy<SysConfig> _Instance = new Lazy<SysConfig>(() => new SysConfig());
        public static SysConfig Instance => _Instance.Value;
        public GamaJiraConfig JiraProject =>
            JsonConvert.DeserializeObject<GamaJiraConfig>(
                File.ReadAllText(@".\SystemConfigs\JiraProjectConfig.json", Encoding.UTF8));
    }
}
