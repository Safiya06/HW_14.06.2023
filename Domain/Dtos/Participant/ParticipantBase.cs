namespace Domain.Dtos.Participant;

public class ParticipantBase
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public int LocationId { get; set; }
    public int GroupId { get; set; }
    public DateTime CreatedAt { get; set; }
}