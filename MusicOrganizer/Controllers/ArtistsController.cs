using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public ArtistsController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Artist> model = _db.Artists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist artist)
    {
      if (!ModelState.IsValid)
      {
        return View(artist);
      }
      _db.Artists.Add(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Artist thisArtist = _db.Artists
                                  .Include(artist => artist.JoinEntities)
                                  .ThenInclude(join => join.Album)
                                  .FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult AddAlbum(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artists => artists.ArtistId == id);
      ViewBag.AlbumId = new SelectList(_db.Albums, "AlbumId", "Name");
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult AddAlbum(Artist artist, int albumId)
    {
      #nullable enable
      AlbumArtist? joinEntity = _db.AlbumArtists.FirstOrDefault(join => (join.AlbumId == albumId && join.ArtistId == artist.ArtistId));
      #nullable disable
      if (joinEntity == null && albumId != 0)
      {
        _db.AlbumArtists.Add(new AlbumArtist() { AlbumId = albumId, ArtistId = artist.ArtistId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = artist.ArtistId });
    }

    public ActionResult Edit(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist artist)
    {
      _db.Artists.Update(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}