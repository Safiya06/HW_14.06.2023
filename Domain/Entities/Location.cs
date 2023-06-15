using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Location
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Participant>  Participants{ get; set; }
    
}