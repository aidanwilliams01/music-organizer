using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class HomeController : Controller
  {
    private readonly MusicOrganizerContext _db;

    public HomeController(MusicOrganizerContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Artist[] arts = _db.Artists.ToArray();
      Album[] albs = _db.Albums.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("artists", arts);
      model.Add("albums", albs);
      return View(model);
    }
  }
}