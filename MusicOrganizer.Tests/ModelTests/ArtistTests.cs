using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }

    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      string name01 = "test";
      string name02 = "test2";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> { newArtist1, newArtist2 };
      List<Artist> result = Artist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_AlbumsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "test";
      Artist newArtist = new Artist(title);
      int result = newArtist.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectArtist_Artist()
    {
      string artist01 = "test";
      string artist02 = "test2";
      Artist newArtist1 = new Artist(artist01);
      Artist newArtist2 = new Artist(artist02);
      Artist result = Artist.Find(2);
      Assert.AreEqual(newArtist2, result);
    }

    [TestMethod]
    public void AddAlbum_AssociatesAlbumWithArtist_AlbumList()
    {
      string album = "test";
      Album newAlbum = new Album(album, "test");
      List<Album> newList = new List<Album> { newAlbum };
      string name = "test";
      Artist newArtist = new Artist(name);
      newArtist.AddAlbum(newAlbum);
      List<Album> result = newArtist.Albums;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}