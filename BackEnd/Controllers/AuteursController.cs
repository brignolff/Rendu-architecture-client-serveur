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
    public class AuteursController : ControllerBase
    {
        private static IAuteurBLL? _context;

        private void GetContext()
				{
            if (_context == null)
                _context = new AuthorBLL();
				}

        // GET: api/Auteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auteur>>> GetAuteurs()
        {
            GetContext();
            return await _context.GetAuteurs().ToListAsync();
        }

        // POST: api/Auteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auteur>> PostAuteur(Auteur auteur)
        {
            GetContext();
            _context.PostAuteur(auteur);
            return Ok();
        }
    }
}
