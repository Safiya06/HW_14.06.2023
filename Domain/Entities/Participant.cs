using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Participant
{
    public Participant()
    {
        CreatedAt = DateTime.Now;
    }
    public int Id { get; set; }
    [MaxLength(50)]
    public string FullName { get; set; }
    [MaxLength(50)]
    public string Email { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [MaxLength(50)]
    public string Password { get; set; }
    public int LocationId { get; set; }
    public virtual Location  Location { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public DateTime CreatedAt { get; set; }
}