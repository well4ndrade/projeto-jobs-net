using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_jobs_net.Models;
using projeto_jobs_net.Servicos;

namespace projeto_jobs_net.Controllers
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
        public async Task<IActionResult> Create([Bind("Id,Nome,descricao,Local,Salario")] Vaga vaga)
        {   
            if(!(VagaJaCadastrada(vaga.Nome))){
            _context.Add(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(201, vaga);
            }
            return StatusCode(401, new { Mensagem = "Essa vaga já esta cadastrada no banco" });
        }

        [HttpPut]
        [Route("/Vagas/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,descricao,Local,Salario")] Vaga vaga)
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

        [HttpDelete]
        [Route("/vagas/{id}")]
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

        private bool VagaJaCadastrada(string Nome)
        {
            return _context.Vagas.Any(e => e.Nome == Nome);
        }
    }
}
