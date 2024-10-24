<h1 align="center" style="font-weight: bold;">Projeto Aliquota - Desafio Técnico 💻</h1>

<p align="center">
  <a href="#challenge">Desafio</a> •
 <a href="#tech">Tecnologias</a> • 
 <a href="#started">Começando</a> 
</p>

<p align="center">
    <b>Este projeto é a implementação de um desafio técnico que simula um produto financeiro onde o Imposto de Renda (IR) é calculado apenas no momento do resgate do investimento, de acordo com as regras especificadas. Foi implementado usando ASP.NET Core MVC com .NET 8, seguindo princípios de boas práticas de desenvolvimento, como DDD (Domain-Driven Design), POCO, SOLID e Testes Unitários.</b>
</p>

<h2 id="challenge">💻 Desafio</h2>

Problema a ser Resolvido:
 O cálculo do Imposto de Renda ocorre no momento do resgate de um investimento. As regras de cálculo são:

- Até 1 ano de aplicação: 22,5% sobre o lucro.
- De 1 a 2 anos de aplicação: 18,5% sobre o lucro.
- Acima de 2 anos de aplicação: 15% sobre o lucro.
  
<h3>Validações importantes</h3>

- A aplicação não pode ser igual ou menor que zero.
- A data de resgate não pode ser menor que a data de aplicação.

<h2 id="technologies">💻 Tecnologias</h2>

- ASP.NET Core MVC - Framework para construção do front-end e back-end.
- .NET 8 - Versão mais recente do .NET.
- Entity Framework Core - ORM para persistência de dados.
- SQL Server - Banco de dados usado no projeto.
- XUnit - Para testes unitários.

<h2 id="started">🚀 Começando</h2>

<h3>Requisitos</h3>

- .NET 8 SDK
- SQL Server

<h3>Clonando</h3>

Como clonar o projeto:

```bash
git clone https://github.com/luizolivas/csharp-aliquota-calculation.git
```

<h3>Configuração do `appsettings.json`</h3>

As configurações de ambiente estão armazenadas no arquivo appsettings.json. Edite este arquivo para ajustar as configurações de acordo com o seu ambiente:

```yaml
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AliquotaDb;User Id=sa;Password=senha;"
  }
}

```
<h3>Começando</h3>

- Backend (.NET 8):
No diretório do projeto backend, rode o seguinte comando:
```yaml
dotnet run
```
- Rodando as Migrações:
Crie o banco de dados e aplique as migrações para criar as tabelas necessárias:
```yaml
dotnet ef database update
```
