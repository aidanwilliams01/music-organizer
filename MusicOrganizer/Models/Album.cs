using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Album
  {
    public string Title { get; set; }
    public string ArtURL { get; set; }
    public int AlbumId { get; set; }
    public List<AlbumArtist> JoinEntities { get; }
  }
}