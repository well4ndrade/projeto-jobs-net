using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobs_net.Apresentacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace jobs_net.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [Route("/")]
        public HomeView Get()
        {
           return new HomeView(); 
        }
    }
}
