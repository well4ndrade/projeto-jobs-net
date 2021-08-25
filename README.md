<h1>Back-End Jobsnet🚀</h1>

<h2>🚀 Equipe The First Of Us🚀</h2>


<h2>📌Comandos para rodar localmente 💻</h2>
<ul>
<li>Clonar - git clone https://github.com/well4ndrade/projeto-jobs-net</li>
<li>Para Rodar(porta 5001) - dotnet run</li>
<li>Testes - dotnet build</li>
</ul>

<h2>📌Comandos iniciais:  💻</h2>
<ul>
<li>mkdir jobs-net</li>
<li>cd jobs-net</li>
<li>dotnet new webapi</li>
</ul>


<h2>📌Comandos git: 💻</h2>
<ul>
<li>git init</li>
<li>git add .</li>
<li>git commit -m "Iniciando projeto"</li>
<li>code .gitignore # geramos o conteúdo para ignorar como (Windows, Linux, Mac, DotnetCore, VisualStudioCore) no link: https://www.toptal.com/developers/gitignore</li>
<li>Criei o repositório e rodei os comandos</li>
<li>git remote add origin git@github.com:well4ndrade/projeto-jobs-net.git </li>
<li>git branch -M main</li>
<li>git push -u origin main</li>
</ul>

<h2>📌Componentes Instalados: 💻</h2>
<ul>
<li>dotnet add package Microsoft.EntityFrameworkCore --version 5.0.2</li>
<li>dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.2</li>
<li>dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.2</li>
<li>dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 5.0.2</li>
</ul>

<h2>📌Comandos para migração: 💻</h2>
<ul>
<li>dotnet tool install --global dotnet-ef</li>
<li>dotnet ef migrations add jobsAdd</li>
<li>dotnet ef database update</li>
</ul>

<h2>📌Instalação para Code Generetor: 💻</h2>
<ul>
dotnet tool install -g dotnet-aspnet-codegenerator</li>
</ul>

<h2>📌Gerando o scaffold de Usuarios, Enderços e Vagas (o processo foi repetido para todos os controllers): 💻</h2>
<ul>
<li>dotnet aspnet-codegenerator controller -name UsuariosController -m Usuario -dc DbContexto --relativeFolderPath Controllers </li>

<li>dotnet aspnet-codegenerator controller -name EnderecosController -m Endereco -dc DbContexto --relativeFolderPath Controllers </li>

<li>dotnet aspnet-codegenerator controller -name VagasController -m Vaga -dc DbContexto --relativeFolderPath Controllers </li>
</ul>

<h2>📌Tecnologias Utilizadas 💻</h2>	
<ul>
<li>.NET Entity Framework</li>
<li> Swagger</li>
<li> C#</li>
</ul>