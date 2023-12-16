namespace MusicOrganizer.Models
{
  public class AlbumArtist
  {
    public int AlbumArtistId { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
  }
}