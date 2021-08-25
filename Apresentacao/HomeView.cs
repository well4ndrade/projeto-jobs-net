using System.Collections.Generic;

namespace projeto_jobs_net.Apresentacao
{
    public class HomeView
    {
        public string Mensagem
        {
            get{ return "Bem Vindo ao Jobs Net";}
        }

        public List<string> Endpoints
        {
            get{ return new List<string>()
            {
                "/Enderecos",
                "/Usuarios",
                "/Vagas",
                "/swagger",
                "http://localhost:3000/portal/cadastro/"
            };
            }
        }
    }
}
