using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Models
{
    public class GamaIssue
    {
        /// <summary> 
        /// Jira Issue單號
        /// </summary> 
        public ComparableString Key { get; set; }

        /// <summary> 
        ///摘要 
        /// </summary> 
        [Required]
        public string Summary { get; set; }

        /// <summary> 
        ///描述 
        /// </summary> 
        [Required]
        public string Description { get; set; }

        /// <summary> 
        ///負責人 
        /// </summary> 
        public string Assignee { get; set; }

        /// <summary> 
        ///專案 
        /// </summary> 
        public string Project { get; set; }

        /// <summary> 
        ///回報人 
        /// </summary> 
        public string Reporter { get; set; }

        /// <summary> 
        ///議題狀態 
        /// </summary> 
        public IssueStatus Status { get; set; }

        /// <summary> 
        ///議題類型 
        /// </summary> 
        public IssueType Type { get; set; }
    }
    
}
