using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }
  }
}