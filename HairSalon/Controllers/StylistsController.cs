using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }
    public ActionResult Search(string name)
    {
      List<Stylist> model = _db.Stylists.Where(stylist => stylist.Name == name).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(Guid id)
    {
      Stylist thisStylist = _db.Stylists
        .FirstOrDefault(stylist => stylist.StylistId == id);
      List<Client> stylistClients = _db.Clients.Where(client => client.StylistId == id).ToList();
      thisStylist.Clients = stylistClients;
      return View(thisStylist);
    }
    public ActionResult Delete(Guid id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(Stylist => Stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(Guid id)
    {
      var thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}