# Project Name (Base API)

Este é um projeto base para uma API padrão em .NET, seguindo os princípios da **Clean Architecture** e utilizando tecnologias modernas para garantir escalabilidade, manutenibilidade e testabilidade.

## 🚀 Tecnologias Utilizadas

- **.NET 10**: Plataforma de desenvolvimento.
- **ASP.NET Core API**: Framework para construção de APIs.
- **Entity Framework Core**: ORM para persistência de dados.
- **PostgreSQL**: Banco de dados relacional.
- **MediatR**: Implementação dos padrões Mediator e CQRS.
- **FluentValidation**: Validação de dados de entrada de forma fluida.
- **Swagger/OpenAPI**: Documentação interativa da API.
- **Docker & Docker Compose**: Containerização da aplicação e dependências.

## 🏛️ Arquitetura

O projeto é estruturado em camadas seguindo a Clean Architecture:

1.  **Domain**: Contém as entidades de negócio, interfaces de repositórios e contratos fundamentais. Não possui dependências externas.
2.  **Application**: Contém a lógica de negócio, casos de uso (Commands/Queries), DTOs, validadores e interfaces de serviços.
3.  **Infrastructure**: Implementa a persistência de dados (Contexto do EF Core, Repositórios, Unit of Work) e integrações externas.
4.  **API**: Ponto de entrada da aplicação. Contém os Controllers, Middlewares e a configuração da Injeção de Dependência.

## 🛠️ Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) e [Docker Compose](https://docs.docker.com/compose/)

### Via Docker (Recomendado)

A forma mais rápida de subir o ambiente (incluindo o banco de dados e pgAdmin) é via Docker Compose:

```bash
docker-compose up -d
```

- **API**: http://localhost:5000 (ou porta configurada)
- **Swagger UI**: http://localhost:5000/swagger
- **pgAdmin**: http://localhost:5050 (User: `admin@admin.com`, Password: `admin`)

### Execução Local (Desenvolvimento)

1.  Certifique-se de que o PostgreSQL está rodando (você pode subir apenas o banco via docker: `docker-compose up -d postgres`).
2.  Atualize a string de conexão no `appsettings.json` da camada **API**, se necessário.
3.  Execute as migrações do banco de dados:
    ```bash
    dotnet ef database update --project Infrastructure --startup-project API
    ```
4.  Inicie a aplicação:
    ```bash
    dotnet run --project API
    ```

## 📁 Estrutura de Pastas

```text
├── API/                # Camada de Apresentação (Web API)
├── Application/        # Camada de Lógica de Negócio (Casos de Uso)
├── Domain/             # Camada de Domínio (Entidades e Contratos)
├── Infrastructure/     # Camada de Infraestrutura (Persistência e Dados)
├── docker/             # Arquivos de configuração Docker
└── docker-compose.yml  # Orquestração de containers
```

## ✨ Funcionalidades Inclusas

- **Padrão Repository & Unit of Work**: Para abstração da camada de dados.
- **Tratamento Global de Erros**: Middleware customizado para capturar e formatar exceções.
- **Validação Automática**: Integração do FluentValidation com o pipeline do MediatR/ASP.NET.
- **CQRS**: Separação de responsabilidades entre leitura e escrita usando MediatR.
- **Injeção de Dependência**: Configuração modularizada por camada.

---
Desenvolvido como um template base para novos projetos.
