using EcommerceWebsiteMovie.Data;
using Microsoft.AspNetCore.Mvc;
using EcommerceWebsiteMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebsiteMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext Context)
        {
            _context = Context;
        }
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            return View();
        }
    }
}
