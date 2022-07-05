using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using IBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using ORM;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private static ILivreBLL _context;

        private void GetContext()
        {
            if (_context == null)
                _context = new LivreBLL();
        }

        // GET: api/Livres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livre>>> GetLivres()
        {
            GetContext();
            return await _context.GetLivres().ToListAsync();
        }
      



        // POST: api/Livres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livre>> PostLivre(Livre livre)
        {
            GetContext();
            _context.PostLivre(livre);
            return Ok();
        }
    }
}
