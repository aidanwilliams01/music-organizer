using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public int ArtistId { get; set; }
    public List<AlbumArtist> JoinEntities { get; }
  }
}