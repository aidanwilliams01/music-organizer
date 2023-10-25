using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class AlbumTests : IDisposable
  {

    public void Dispose()
    {
      Album.ClearAll();
    }

    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("test");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsAllAlbumObjects_AlbumList()
    {
      string title01 = "test";
      string title02 = "test2";
      Album newAlbum1 = new Album(title01);
      Album newAlbum2 = new Album(title02);
      List<Album> newList = new List<Album> { newAlbum1, newAlbum2 };
      List<Album> result = Album.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "test";
      Album newAlbum = new Album(title);
      int result = newAlbum.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectAlbum_Album()
    {
      string album01 = "test";
      string album02 = "test2";
      Album newAlbum1 = new Album(album01);
      Album newAlbum2 = new Album(album02);
      Album result = Album.Find(2);
      Assert.AreEqual(newAlbum2, result);
    }
  }
}