using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Group
{
    public Group()
    {
        CreatedAt = DateTime.Now;
    }
    public int Id { get; set; }
    [MaxLength(50)]
    public string GroupNick { get; set; }
    public int ChallengeId { get; set; }
    public virtual Challenge Challenge { get; set; }
    public int MinimumNumberOfMembers { get; set; }
    public string TeamSlogan { get; set; }
    public virtual  List<Participant> Participants { get; set; }
    public DateTime CreatedAt { get; set; }

}

