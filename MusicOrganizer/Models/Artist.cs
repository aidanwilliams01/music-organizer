using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public int ArtistId { get; }
    public List<AlbumArtist> JoinEntities { get; }
  }
}