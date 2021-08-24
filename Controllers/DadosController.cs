using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_jobs_net.Models;
using projeto_jobs_net.ModelViews;
using projeto_jobs_net.Servicos;

namespace projeto_jobs_net.Controllers
{
    [ApiController]
    
    public class DadosController : ControllerBase
    {
        private readonly DbContexto _context;

        public DadosController(DbContexto context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/Dados")]
        public async Task<IActionResult> Index()
        {
            return StatusCode(200, await _context.Dados.ToListAsync());
        }
        
                // GET: /administradores/5
        [HttpPost]
        [Route("/Dados/Login")]
        public async Task<IActionResult> Login([FromBody] AdmLoginView dado)
        {
          
            var auth = await _context.Dados.Where(a => a.Login == dado.Login && a.Passwd == dado.Passwd).FirstOrDefaultAsync();
            if (auth != null)
            {  
                return StatusCode(200, new {
                    Id = auth.Id,
                    Login = auth.Login,
                    Passwd = auth.Passwd,
                });
            }

            return StatusCode(401, new {
                Mensagem = "Usuário ou Senha não permitido",
            });
        }

        [HttpPost]
        [Route("/Dados")]
        public async Task<IActionResult> Create([Bind("Id,Login,Passwd")] Dado dado)
        {
           
            if(!(LoginExists(dado.Login))){    
            _context.Add(dado);
            await _context.SaveChangesAsync();
            return StatusCode(201, dado);
            }
            return StatusCode(401, new { Mensagem = "O usuário já existe" });

            
        }

        [HttpPut]
        [Route("/Dados/Alterar/")]
         public async Task<IActionResult> Edit([FromBody] AdmLoginView dado)
        {
            var edit = await _context.Dados.Where(a => a.Login == dado.Login).FirstOrDefaultAsync();
            if (edit != null)
            {  
                return StatusCode(200, new {
                    Id = edit.Id,
                    Login = edit.Login,
                    Passwd = dado.Passwd,
                });
            }
             return StatusCode(401, new {Mensagem = "Usuário ou Senha não permitido",});
            
        }

        [HttpDelete]
        [Route("/Dados/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dado = await _context.Dados.FindAsync(id);
            _context.Dados.Remove(dado);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool DadoExists(int id)
        {
            return _context.Dados.Any(e => e.Id == id);
        }
        private bool LoginExists(string Login)
        {
            return _context.Dados.Any(e => e.Login == Login);
        }
       
    }
}
