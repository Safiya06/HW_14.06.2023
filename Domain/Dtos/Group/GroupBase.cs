namespace Domain.Dtos.Group;

public class GroupBase
{
    public int Id { get; set; }
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public int MinimumNumberOfMembers { get; set; }
    public string TeamSlogan { get; set; }
    public DateTime CreatedAt { get; set; }
}