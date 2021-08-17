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
    public class UsuariosController : ControllerBase
    {
        private readonly DbContexto _context;

        public UsuariosController(DbContexto context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Usuarios")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Usuarios.ToListAsync());
        }

        [HttpPost]
        [Route("/Usuarios")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Genero,Nascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil,PossuiVeiculo,PossuiHabilitacao")] Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(201, usuario);
        }

        [HttpPut]
        [Route("/Usuarios/{id}")
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,Genero,Nascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil,PossuiVeiculo,PossuiHabilitacao")] Usuario usuario)

        {
            if (id != usuario.Id)
            {
                return NotFound();
            }
            try
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, usuario);
        }

        [HttpDelete]
        [Route("/Usuarios/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
