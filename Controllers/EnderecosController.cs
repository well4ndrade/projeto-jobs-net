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
    public class EnderecosController : ControllerBase
    {
        private readonly DbContexto _context;

        public EnderecosController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/Enderecos")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Enderecos.ToListAsync());
        }

        [HttpPost]
        [Route("/Enderecos")]
        public async Task<IActionResult> Create([Bind("Id,Cep,Logradouro,Numero,Bairro,Cidade,Pais")] Endereco endereco)
        {
            _context.Add(endereco);
            await _context.SaveChangesAsync();
            return StatusCode(201, endereco);
        }

        [HttpPut]
        [Route("/Enderecos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cep,Logradouro,Numero,Bairro,Cidade,Pais")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(endereco);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(endereco.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, endereco);
        }

        [HttpDelete]
        [Route("/enderecos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
