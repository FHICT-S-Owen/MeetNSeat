using System.Collections.Generic;
using MeetNSeat.Dal.Factories;
using MeetNSeat.Dal.Interfaces;
using MeetNSeat.Logic.Interfaces;

namespace MeetNSeat.Logic
{
  public class IssueCollection : IManageIssue
  {
    private readonly List<Issue> _issues = new();
    private readonly IIssueDal _dal;

    public IssueCollection()
    {
      _dal = IssueFactory.CreateIssueDal();
    }
    
    public IReadOnlyCollection<Issue> GetAllIssues() 
    {
      _issues.Clear();

      _dal.GetAllIssues().ForEach(
        dto => _issues.Add(new Issue(dto)));
			
      return _issues.AsReadOnly();
    }
    
    public void AddIssue(string description, int roomId, string userId)
    {
      var issue = new Issue(description, roomId, userId);
      _issues.Add(issue);
      _dal.AddIssue(issue.ConvertToDto());
    }

    public void DeleteIssue(int id)
    {
      _issues.Remove(_issues.Find(issue => issue.Id == id));
      _dal.DeleteIssueById(id);
    }
    
    public void UpdateIssue(int id, string description, int roomId, string userId, bool isResolved)
    {
      _issues.Find(issue => issue.Id == id)?
        .Update(description, roomId, userId, isResolved);
    }
  }
}
