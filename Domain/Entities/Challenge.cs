using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace;

public class Challenge
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Title { get; set; }
    public string Description { get; set; }
    public virtual List<Group> Groups { get; set; }
}

