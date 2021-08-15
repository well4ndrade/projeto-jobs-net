# Comandos iniciais:
``` bash
  mkdir jobs-net
  cd jobs-net
  dotnet new webapi
```

# Comandos git:
``` bash
  git init
  git add .
  git commit -m "Iniciando projeto"
  code .gitignore # gerei o conteúdo para ignorar como (Windows, Linux, Mac, DotnetCore, VisualStudioCore) no link: https://www.toptal.com/developers/gitignore
  Criei o repositório e rodei os comandos
  git remote add origin git@github.com:well4ndrade/projeto-jobs-net.git
  git branch -M main
  git push -u origin main
```

# Componentes instalados:
``` bash
  dotnet add package Microsoft.EntityFrameworkCore --version 5.0.2
  dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.2
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.2
  dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 5.0.2
```

# Comandos para migração:
``` bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add jobsAdd
dotnet ef database update
```

# Instalação do code generator
``` bash
dotnet tool install -g dotnet-aspnet-codegenerator
```

# Gerando o scaffold de Usuarios
``` bash
dotnet aspnet-codegenerator controller -name UsuariosController -m Usuario -dc DbContexto --relativeFolderPath Controllers 

dotnet aspnet-codegenerator controller -name EnderecosController -m Endereco -dc DbContexto --relativeFolderPath Controllers 

dotnet aspnet-codegenerator controller -name VagasController -m Vaga -dc DbContexto --relativeFolderPath Controllers 

```

