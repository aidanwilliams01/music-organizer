using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class AlbumTests
  {

    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album();
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }
  }
}