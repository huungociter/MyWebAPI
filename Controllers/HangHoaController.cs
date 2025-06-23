using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Data;
using MyWebAPI.Models;
using System;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create()
        {
            var user = new User
            {
                Name = "Ngoc",
                Id = 123
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var products = _context.Users.ToList();
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Id}: {p.Name}");
            }

            return Ok(products); 
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Users.ToList();

            return Ok(products);
        }
    }
}
