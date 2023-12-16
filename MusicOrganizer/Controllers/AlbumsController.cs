using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace Registrar.Controllers
{
  public class AlbumsController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public AlbumsController(MusicOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Album> model = _db.Albums
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Album album)
    {
      if (!ModelState.IsValid)
      {
        return View(album);
      }
      _db.Albums.Add(album);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Album thisAlbum = _db.Albums
                          .Include(album => album.JoinEntities)
                          .ThenInclude(join => join.Artist)
                          .FirstOrDefault(album => album.AlbumId == id);
      return View(thisAlbum);
    }
  }
}