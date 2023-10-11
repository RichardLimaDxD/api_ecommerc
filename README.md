# api_ecommerc

Para acessar o repositório do frontEnd, <a href="https://github.com/RichardLimaDxD/ecommerce_frontend" target="_blank">clique aqui</a>.

## Instalação e Execução

É necessário ter instalado em sua máquina o `.NET` e o banco de dados `SQLServer`. Essa aplicação utiliza o Redis,
caso não tenha ele em sua máquina baixe por <a href="https://redis.io/docs/getting-started/installation/" target="_blank">aqui</a>
ou por esse repositorio do <a href="https://github.com/microsoftarchive/redis/releases" target="_blank" >GitHub</a>
Para executar a aplicação localmente, siga estas etapas:
 
1. Clone este repositório.
2. Abra o repositório no vs. Abra um terminal para as instalações.
3. Configure as credenciais de acesso num novo arquivo `appsettings.json`, seguindo o exemplo em appsettings.Development.json Em /Data Source, substituia por /[nome do banco].
4. Lembre de colocar uma senha forte na KEY do Token.
5. Baixe os pacotes nuget que estão em API, Ecom.Core, Ecom.Infrastructure:
   
API
```
   AutoMapper.Extensions.Microsoft.DependencyInjection Version="12.0.1"
   Microsoft.AspNetCore.Authentication.JwtBearer Version="7.0.11" 
   Microsoft.AspNetCore.OpenApi Version="7.0.11" 
   Microsoft.EntityFrameworkCore Version="7.0.11" 
   Microsoft.EntityFrameworkCore.Design Version="7.0.11"
   Microsoft.EntityFrameworkCore.SqlServer Version="7.0.11" 
   Microsoft.EntityFrameworkCore.Tools Version="7.0.11"
   StackExchange.Redis Version="2.6.122" 
   Swashbuckle.AspNetCore Version="6.5.0" 
```
Ecom.Core
```
AutoMapper.Extensions.Microsoft.DependencyInjection Version="12.0.1" 
Microsoft.AspNetCore.Http.Features Version="5.0.17" 
Microsoft.EntityFrameworkCore Version="7.0.11" 
Microsoft.EntityFrameworkCore.Design Version="7.0.11"
Microsoft.EntityFrameworkCore.SqlServer Version="7.0.11" 
Microsoft.EntityFrameworkCore.Tools Version="7.0.11"
Microsoft.Extensions.Identity.Stores Version="7.0.3" 
 
```
Ecom.Infrastructure
```
AutoMapper.Extensions.Microsoft.DependencyInjection Version="12.0.1" 
Microsoft.AspNetCore.Authentication.JwtBearer Version="7.0.11" 
Microsoft.AspNetCore.Hosting.Abstractions Version="2.1.1" 
Microsoft.AspNetCore.Identity.EntityFrameworkCore Version="7.0.3" 
Microsoft.EntityFrameworkCore Version="7.0.11"
Microsoft.EntityFrameworkCore.Design Version="7.0.11"
Microsoft.EntityFrameworkCore.SqlServer Version="7.0.11" 
Microsoft.EntityFrameworkCore.Tools Version="7.0.11"
Microsoft.Extensions.FileProviders.Abstractions Version="7.0.0"
Microsoft.IdentityModel.Tokens Version="7.0.2" 
StackExchange.Redis Version="2.6.96" 
Stripe.net Version="42.8.0"
System.IdentityModel.Tokens.Jwt Version="7.0.2"
 
```
6.Rode as migrações do projeto com `add-migration InitialMigration -o "Data/Migrations"`, `update-database`

7.rode o comando `dotnet watch run`

8.Você pode testar todas as rotas através do <a href="http://localhost:5250/swagger/index.html" target="_blank">Swagger</a> 


