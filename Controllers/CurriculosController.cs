using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_jobs_net.Models;
using projeto_jobs_net.Servicos;

namespace projeto_jobs_net.Controllers
{
    [ApiController]
    public class CurriculosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CurriculosController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Curriculos")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Curriculos.ToListAsync());
        }

        [HttpPost]

        [Route("/Curriculos")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cargo,Sobre,Escolaridade")] Curriculo curriculo)
        {
            _context.Add(curriculo);
            await _context.SaveChangesAsync();
            return StatusCode(201, curriculo);
        }

        [HttpPut]
        [Route("/Curriculos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cargo,Sobre,Escolaridade")] Curriculo curriculo)
        {
            if (id != curriculo.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(curriculo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculoExists(curriculo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, curriculo);
        }

        [HttpDelete]
        [Route("/Curriculos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var curriculo = await _context.Curriculos.FindAsync(id);
            _context.Curriculos.Remove(curriculo);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool CurriculoExists(int id)
        {
            return _context.Curriculos.Any(e => e.Id == id);
        }
    }
}
