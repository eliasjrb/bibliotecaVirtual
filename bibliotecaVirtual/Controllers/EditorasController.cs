﻿using bibliotecaVirtual.Data;
using bibliotecaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotecaVirtual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorasController : Controller
    {
        private readonly BibliotecaContexto _context;
        public EditorasController(BibliotecaContexto contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> Get()
        {
            return await _context.Editoras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> Get(int id)
        {
            var editora = await _context.Editoras.FindAsync(id);

            if (editora == null)
                return NotFound();

            return editora;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Editora editora)
        {
            _context.Editoras.Add(editora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = editora.Id }, editora);
        }
    }
}
