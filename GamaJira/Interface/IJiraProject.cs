namespace GamaJira.Interface
{
    public interface IJiraProject
    {
        void GetIssues(string issueId);
        void CreateIssue(string summary, string description);
    }
}
