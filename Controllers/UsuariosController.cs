using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using jobs_net.Models;
using jobs_net.Servicos;

namespace jobs_net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContexto _context;

        public UsuariosController(DbContexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Usuarios.ToListAsync());
        }

        [HttpPost]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Genero,DataNascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil,PossuiVeiculo,PossuiHabilitacao")] Usuario usuario)
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Rg,Genero,Nascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil")] Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(201, usuario);
        }

        [HttpPut]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,Genero,DataNascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil,PossuiVeiculo,PossuiHabilitacao")] Usuario usuario)
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Rg,Genero,Nascimento,Telefone,Telefone2,Email,Profissao,EstadoCivil")] Usuario usuario)
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

        [HttpDelete, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
