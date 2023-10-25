using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Album
  {
    private static List<Album> _instances = new List<Album> {};
    public string Title { get; set; }
    public int Id { get; }

    public Album(string title)
    {
      Title = title;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Album> GetAll()
    {
      return _instances;
    }

    public static Album Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}