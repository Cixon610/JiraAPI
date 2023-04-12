using Atlassian.Jira;
using GamaJira.Constant;
using GamaJira;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamaJira.Models;
using System.ComponentModel;
using GamaJira.Projects;

namespace JiraConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var jiraFactory = new JiraProjectFactory(@".\SystemConfigs\JiraProjectConfig.json");
            var jiraProject = jiraFactory.CreateJiraProject(nameof(SA35));

            var model = new GamaJiraWebHookModel(GetJson(), jiraProject.GetIssueType(JiraIssueType.UserStory));

            //var user = jiraProject.SearchUser("g-ryanchang@gamania.com");
            //var userE = jiraProject.SearchUser("ryanchang");
            //var userC = jiraProject.SearchUser("張景翔");
            //var userL = jiraProject.SearchUser("poan");

            var issue = jiraProject.CreateUserStory()
                                   .SetAttachmentsPath(new List<string> {
                                       ".\\Attaches\\Giwawa.jpg"
                                   })
                                   .SetCustomFields(new Dictionary<string, string> {
                                       {"WorkFlowID", "1234"},
                                       {"EstimatedStartTime", "2023-03-29"},
                                       {"EstimatedEndTime", "2023-03-30"},
                                       {"ProjectType", "電子流程"},
                                       {"ProjectPriority", "VIP"},
                                       {"ITMemo", "MemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemoMemo"},
                                   })
                                   //.SetAssignee("634f693bfe5ff3752357f8ab")
                                   .SetDescription("Description")
                                   .SetPriority(JiraIssuePriority.Highest)
                                   .SetSummary("TestSummary")
                                   .Build();

            //jiraProject.SearchUser("");
            //var json = JsonConvert.SerializeObject(issue, Formatting.Indented);
            //Console.WriteLine(json);

            Console.ReadLine();
        }

        static void Test()
        {
            var properties = typeof(Issue).GetProperties();
            var obj = properties.Select(x => new { x.Name, x.PropertyType.FullName });
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(json);
        }

        static string GetJson()
        {
            return @"{
	""self"": ""https://gamania-group.atlassian.net/rest/api/2/issue/34708"",
	""id"": 34708,
	""key"": ""SA35-111"",
	""changelog"": {
		""startAt"": 0,
		""maxResults"": 0,
		""total"": 0,
		""histories"": null
	},
	""fields"": {
		""statuscategorychangedate"": ""2023-03-29T17:10:53.711+08:00"",
		""customfield_10075"": null,
		""fixVersions"": [],
		""resolution"": null,
		""lastViewed"": ""2023-03-30T15:04:33.415+08:00"",
		""customfield_10060"": null,
		""priority"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/priority/1"",
			""id"": 1,
			""name"": ""Highest"",
			""iconUrl"": ""https://gamania-group.atlassian.net/images/icons/priorities/highest.svg"",
			""namedValue"": ""Highest""
		},
		""labels"": [],
		""aggregatetimeoriginalestimate"": null,
		""timeestimate"": null,
		""versions"": [],
		""issuelinks"": [],
		""assignee"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/user?accountId=634f693bfe5ff3752357f8ab"",
			""name"": null,
			""key"": null,
			""accountId"": ""634f693bfe5ff3752357f8ab"",
			""emailAddress"": ""g-ryanchang@gamania.com"",
			""avatarUrls"": {
				""48x48"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/48"",
				""24x24"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/24"",
				""16x16"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/16"",
				""32x32"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/32""
			},
			""displayName"": ""Ryan CHANG(張景翔)"",
			""active"": true,
			""timeZone"": ""Asia/Taipei"",
			""groups"": null,
			""locale"": null,
			""accountType"": ""atlassian""
		},
		""status"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/status/10215"",
			""description"": """",
			""iconUrl"": ""https://gamania-group.atlassian.net/"",
			""name"": ""Backlog"",
			""untranslatedName"": null,
			""id"": 10215,
			""statusCategory"": {
				""self"": ""https://gamania-group.atlassian.net/rest/api/2/statuscategory/2"",
				""id"": 2,
				""key"": ""new"",
				""colorName"": ""blue-gray"",
				""name"": ""待辦事項""
			},
			""untranslatedNameValue"": null
		},
		""components"": [],
		""customfield_10050"": null,
		""customfield_10051"": null,
		""customfield_10052"": null,
		""customfield_10053"": [],
		""customfield_10049"": null,
		""aggregatetimeestimate"": null,
		""creator"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/user?accountId=634f693bfe5ff3752357f8ab"",
			""name"": null,
			""key"": null,
			""accountId"": ""634f693bfe5ff3752357f8ab"",
			""emailAddress"": ""g-ryanchang@gamania.com"",
			""avatarUrls"": {
				""48x48"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/48"",
				""24x24"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/24"",
				""16x16"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/16"",
				""32x32"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/32""
			},
			""displayName"": ""Ryan CHANG(張景翔)"",
			""active"": true,
			""timeZone"": ""Asia/Taipei"",
			""groups"": null,
			""locale"": null,
			""accountType"": ""atlassian""
		},
		""subtasks"": [],
		""customfield_10040"": null,
		""customfield_10041"": [],
		""customfield_10042"": null,
		""customfield_10043"": null,
		""reporter"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/user?accountId=634f693bfe5ff3752357f8ab"",
			""name"": null,
			""key"": null,
			""accountId"": ""634f693bfe5ff3752357f8ab"",
			""emailAddress"": ""g-ryanchang@gamania.com"",
			""avatarUrls"": {
				""48x48"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/48"",
				""24x24"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/24"",
				""16x16"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/16"",
				""32x32"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/32""
			},
			""displayName"": ""Ryan CHANG(張景翔)"",
			""active"": true,
			""timeZone"": ""Asia/Taipei"",
			""groups"": null,
			""locale"": null,
			""accountType"": ""atlassian""
		},
		""customfield_10044"": null,
		""aggregateprogress"": {
			""progress"": 0,
			""total"": 0
		},
		""customfield_10045"": null,
		""customfield_10047"": null,
		""customfield_10048"": null,
		""progress"": {
			""progress"": 0,
			""total"": 0
		},
		""votes"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/issue/SA35-111/votes"",
			""votes"": 0,
			""hasVoted"": false
		},
		""worklog"": {
			""maxResults"": 20,
			""total"": 0,
			""startAt"": 0,
			""worklogs"": [],
			""last"": false
		},
		""issuetype"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/issuetype/10197"",
			""id"": 10197,
			""description"": ""故事會追蹤以使用者目標表示的功能或特色。"",
			""iconUrl"": ""https://gamania-group.atlassian.net/rest/api/2/universal_avatar/view/type/issuetype/avatar/10315?size=medium"",
			""name"": ""故事"",
			""untranslatedName"": null,
			""subtask"": false,
			""fields"": {},
			""statuses"": [],
			""namedValue"": ""故事""
		},
		""timespent"": null,
		""project"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/project/10062"",
			""id"": 10062,
			""key"": ""SA35"",
			""name"": ""soual-artchetype35"",
			""description"": null,
			""avatarUrls"": {
				""48x48"": ""https://gamania-group.atlassian.net/rest/api/2/universal_avatar/view/type/project/avatar/10403"",
				""24x24"": ""https://gamania-group.atlassian.net/rest/api/2/universal_avatar/view/type/project/avatar/10403?size=small"",
				""16x16"": ""https://gamania-group.atlassian.net/rest/api/2/universal_avatar/view/type/project/avatar/10403?size=xsmall"",
				""32x32"": ""https://gamania-group.atlassian.net/rest/api/2/universal_avatar/view/type/project/avatar/10403?size=medium""
			},
			""issuetypes"": null,
			""projectCategory"": null,
			""email"": null,
			""lead"": null,
			""components"": null,
			""versions"": null,
			""projectTypeKey"": ""software"",
			""simplified"": true
		},
		""aggregatetimespent"": null,
		""resolutiondate"": null,
		""workratio"": -1,
		""issuerestriction"": {
			""issuerestrictions"": {},
			""shouldDisplay"": true
		},
		""watches"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/issue/SA35-111/watchers"",
			""watchCount"": 1,
			""isWatching"": false
		},
		""created"": 1680081053210,
		""customfield_10261"": null,
		""customfield_10020"": null,
		""customfield_10021"": null,
		""customfield_10022"": null,
		""customfield_10023"": null,
		""customfield_10024"": null,
		""customfield_10025"": null,
		""customfield_10258"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/customFieldOption/10307"",
			""value"": ""VIP"",
			""id"": ""10307""
		},
		""customfield_10016"": null,
		""customfield_10259"": ""Ryan CHANG(張景翔)n"",
		""customfield_10017"": null,
		""customfield_10018"": {
			""hasEpicLinkFieldDependency"": false,
			""showField"": false,
			""nonEditableReason"": {
				""reason"": ""PLUGIN_LICENSE_ERROR"",
				""message"": ""父連結僅供 Jira Premium 使用者使用。""
			}
		},
		""customfield_10019"": ""0|i03tns:"",
		""updated"": 1680155873087,
		""customfield_10092"": null,
		""customfield_10093"": null,
		""timeoriginalestimate"": null,
		""customfield_10250"": ""2023-03-29"",
		""customfield_10251"": ""2023-03-30"",
		""description"": ""Description"",
		""customfield_10010"": null,
		""customfield_10254"": null,
		""customfield_10255"": null,
		""customfield_10014"": null,
		""customfield_10256"": {
			""self"": ""https://gamania-group.atlassian.net/rest/api/2/customFieldOption/10293"",
			""value"": ""電子流程"",
			""id"": ""10293""
		},
		""timetracking"": {
			""originalEstimate"": null,
			""remainingEstimate"": null,
			""timeSpent"": null,
			""originalEstimateSeconds"": 0,
			""remainingEstimateSeconds"": 0,
			""timeSpentSeconds"": 0
		},
		""customfield_10015"": null,
		""customfield_10257"": null,
		""customfield_10005"": null,
		""customfield_10126"": null,
		""customfield_10247"": null,
		""customfield_10006"": null,
		""customfield_10007"": null,
		""security"": null,
		""customfield_10008"": null,
		""attachment"": [
			{
				""self"": ""https://gamania-group.atlassian.net/rest/api/2/attachment/23071"",
				""id"": 23071,
				""filename"": ""Giwawa.jpg"",
				""author"": {
					""self"": ""https://gamania-group.atlassian.net/rest/api/2/user?accountId=634f693bfe5ff3752357f8ab"",
					""name"": null,
					""key"": null,
					""accountId"": ""634f693bfe5ff3752357f8ab"",
					""emailAddress"": ""g-ryanchang@gamania.com"",
					""avatarUrls"": {
						""48x48"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/48"",
						""24x24"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/24"",
						""16x16"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/16"",
						""32x32"": ""https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/634f693bfe5ff3752357f8ab/695644ee-656c-45e5-ad4c-663654344056/32""
					},
					""displayName"": ""Ryan CHANG(張景翔)"",
					""active"": true,
					""timeZone"": ""Asia/Taipei"",
					""groups"": null,
					""locale"": null,
					""accountType"": ""atlassian""
				},
				""created"": 1680081054658,
				""size"": 71088,
				""mimeType"": ""image/jpeg"",
				""content"": ""https://gamania-group.atlassian.net/rest/api/2/attachment/content/23071""
			}
		],
		""customfield_10009"": null,
		""summary"": ""TestSummary"",
		""customfield_10083"": null,
		""customfield_10085"": null,
		""customfield_10086"": null,
		""customfield_10087"": null,
		""customfield_10000"": ""{}"",
		""customfield_10088"": null,
		""customfield_10001"": null,
		""customfield_10089"": null,
		""customfield_10002"": null,
		""customfield_10003"": null,
		""customfield_10004"": null,
		""customfield_10237"": ""1234"",
		""environment"": null,
		""duedate"": null,
		""comment"": {
			""maxResults"": 0,
			""total"": 0,
			""startAt"": 0,
			""comments"": [],
			""last"": false
		}
	},
	""renderedFields"": null
}";
        }
    }
}
