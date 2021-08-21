using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_jobs_net.Models;
using projeto_jobs_net.Servicos;

namespace jobs_net.Controllers
{
    public class LoginsController : Controller
    {
        private readonly DbContexto _context;

        public LoginsController(DbContexto context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Logins")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Login.ToListAsync());
        }
        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/Logins")]
        public async Task<IActionResult> Create([Bind("Id,usuario,senha")] Login login)
        {
            {
            _context.Add(login);
            await _context.SaveChangesAsync();
            return StatusCode(201, login);
            }
         
        }   

        [HttpPut]
        [Route("/Logins/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,usuario,senha")] Login login)
        {
            if (id != login.Id)
            {
                return NotFound();
            }


                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, login);
            
            }

        // GET: Logins/Delete/5
        [HttpDelete, ActionName("Delete")]
        [Route("/Logins/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var login = await _context.Login.FindAsync(id);
             _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }


        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
