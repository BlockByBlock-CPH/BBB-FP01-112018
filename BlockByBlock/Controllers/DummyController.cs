using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockByBlock.Models;

namespace BlockByBlock.Controllers
{
    public class DummyController : Controller
    {

        ApplicationDbContext _data = new ApplicationDbContext();

        // GET: Dummy
        public ActionResult Index()
        {
            
            var result = _data.Products.ToList();

            return View(result);
        }
    }
}