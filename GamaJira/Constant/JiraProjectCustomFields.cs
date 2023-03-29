using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamaJira.Constant
{
    public class JiraProjectCustomFields
    {
        /// <summary>
        /// 電子流程 ID
        /// </summary>
        public static readonly string WorkflowID = "customfield_10237";
        /// <summary>
        /// 預計開始時間
        /// </summary>
        public static readonly string ExpectStartDate = "customfield_10250";
        /// <summary>
        /// 預計結束時間
        /// </summary>
        public static readonly string ExpectEndDate = "customfield_10251";
        /// <summary>
        /// QA 人員
        /// </summary>
        public static readonly string QA = "customfield_10254";
        /// <summary>
        /// 上版人員
        /// </summary>
        public static readonly string DeployMember = "customfield_10255";
        /// <summary>
        /// 專案分類
        /// </summary>
        public static readonly string ProjectType = "customfield_10256";
        /// <summary>
        /// 專案重要性
        /// </summary>
        public static readonly string ProjectImportance = "customfield_10258";
        /// <summary>
        /// 需求申請者
        /// </summary>
        public static readonly string ApplyMember = "customfield_10257";
        /// <summary>
        /// IT 備註
        /// </summary>
        public static readonly string Memo = "customfield_10259";
    }
}
