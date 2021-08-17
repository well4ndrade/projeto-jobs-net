using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jobs_net.Models;
using jobs_net.Servicos;

namespace jobs_net.Controllers
{
    [ApiController]
    
    public class VagasController : ControllerBase
    {
        private readonly DbContexto _context;

        public VagasController(DbContexto context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Vagas")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Vagas.ToListAsync());
        }

        [HttpPost]
        [Route("/Vagas")]
        public async Task<IActionResult> Create([Bind("Id,Nome,descricao")] Vaga vaga)
        {
            _context.Add(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(201, vaga);
        }

        [HttpPut]
        [Route("/Vagas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,descricao")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(vaga);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(vaga.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(200, vaga);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("/Vagas/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}
