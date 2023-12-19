using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicOrganizer.Models
{
  public class Album
  {
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    public string ArtURL { get; set; }
    public int AlbumId { get; set; }
    public List<AlbumArtist> JoinEntities { get; }
  }
}