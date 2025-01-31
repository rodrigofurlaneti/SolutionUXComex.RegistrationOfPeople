# Design Patterns Utilizados no Projeto

## 1. Repository Pattern
- **Arquivos:**
  - `PersonRepository.cs`
  - `RepositoryBase.cs`
- **Descrição:**
  - O projeto segue o **Repository Pattern** para encapsular a lógica de acesso a dados, abstraindo a interação com o banco de dados e fornecendo métodos genéricos (`GetByIdAsync`, `GetAllAsync`, etc.).
- **Benefícios:**
  - Facilita a substituição do **Entity Framework** por **Dapper** sem afetar outras camadas da aplicação.
  - Promove a separação de responsabilidades.

## 2. Unit of Work (Possível)
- **Arquivo:**
  - `UXComexAppDbContext.cs` (antes da migração para Dapper)
- **Descrição:**
  - O `DbContext` do Entity Framework geralmente implementa um **Unit of Work**, pois gerencia múltiplas operações de banco de dados dentro de uma única transação.
- **Após a migração para Dapper:**
  - Como Dapper não tem `DbContext`, se desejar manter o **Unit of Work**, pode implementar manualmente transações (`IDbTransaction`).

## 3. Dependency Injection (DI)
- **Arquivos:**
  - `Startup.cs`
  - `DependencyInjection.cs`
- **Descrição:**
  - O projeto usa **Injeção de Dependência** para registrar serviços e repositórios, facilitando a substituição de implementações (exemplo: trocar Entity Framework por Dapper sem modificar os controladores).
- **Benefícios:**
  - Reduz acoplamento.
  - Facilita testes unitários (mocks dos repositórios).

## 4. Factory Pattern
- **Arquivo:**
  - `AuthenticationDbContextFactory.cs`
- **Descrição:**
  - Esse arquivo sugere o uso do **Factory Pattern** para instanciar `DbContext` em cenários como **migrations** no Entity Framework.
- **Após a migração para Dapper:**
  - Essa factory pode ser removida, pois o Dapper não utiliza `DbContext`.
  - Se precisar de uma factory para gerenciar `IDbConnection`, pode criar algo como:
    ```csharp
    public class DbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
    ```

## 5. Controller Pattern (MVC)
- **Arquivo:**
  - `PersonController.cs`
- **Descrição:**
  - O projeto segue o **Controller Pattern** da arquitetura **ASP.NET Core MVC**. Os controladores lidam com requisições HTTP e chamam os serviços e repositórios.

## 6. Layered Architecture (DDD)
- **Pastas:**
  - `Domain` (Entidades e Interfaces)
  - `Application` (Serviços e Casos de Uso)
  - `Infra` (Acesso a Dados)
  - `API` (Camada de apresentação)
- **Descrição:**
  - Segue a arquitetura em camadas do **Domain-Driven Design (DDD)**, onde:
    - **Domain** contém regras de negócio e contratos (`IPersonRepository`).
    - **Infra** implementa o acesso a dados (`PersonRepository`).
    - **Application** pode conter serviços de aplicação (não identificados ainda).
    - **API** contém os controladores que expõem endpoints.

## Conclusão
Os principais padrões utilizados no projeto são:
✅ **Repository Pattern** (Repositórios de acesso a dados)  
✅ **Unit of Work** (Usado com Entity Framework)  
✅ **Dependency Injection** (Injeção de dependência com `Startup.cs`)  
✅ **Factory Pattern** (Factory para `DbContext`, que será removida)  
✅ **Controller Pattern (MVC)** (Controladores na API)  
✅ **Layered Architecture / DDD** (Divisão em camadas)
