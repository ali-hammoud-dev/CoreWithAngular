using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model;

public class Music
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int ArtistId { get; set; }

    [ForeignKey(nameof(ArtistId))]
    public virtual Artist Artist { get; set; }

}