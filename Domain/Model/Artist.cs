using System.ComponentModel.DataAnnotations;

namespace Domain.Model;

public class Artist
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}

