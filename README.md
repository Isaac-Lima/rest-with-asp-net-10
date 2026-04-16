# 📚 API de Autores e Livros


API REST desenvolvida com ASP.NET Core (.NET 10) para gerenciamento de autores e livros.  
O projeto implementa operações CRUD completas, seguindo boas práticas de desenvolvimento como Clean Architecture, SOLID e boas práticas de APIs RESTful.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core (.NET 10)
- C#
- Entity Framework Core
- SQL Server
- JSON e XML (Content Negotiation)
- Moq
- Fluent Assertions
- System.Text.Json (Custom Serialization)
- Serilog (Logging estruturado)
- Evolve (Migrations de banco de dados)
- Swagger + Scalar (Documentação da API)

### 🧪 Testes

- xUnit
- Testcontainers (Testes de integração)

### 🐳 Infraestrutura

- Docker
---

## 📌 Funcionalidades

### 👤 Autores
- Cadastro de autor
- Listagem de todos os autores
- Busca de autor por ID
- Atualização de autor
- Exclusão de autor

### 📖 Livros
- Cadastro de livro
- Listagem de todos os livros
- Busca de livro por ID
- Atualização de livro
- Exclusão de livro

---

## 🔗 Endpoints

### 👤 Autores

#### 📌 V1

| Método | Endpoint              | Descrição                    |
|--------|----------------------|------------------------------|
| POST   | /api/person/v1       | Cadastrar novo autor         |
| GET    | /api/person/v1       | Listar todos os autores      |
| GET    | /api/person/v1/{id}  | Buscar autor por ID          |
| PUT    | /api/person/v1       | Atualizar autor              |
| DELETE | /api/person/v1/{id}  | Excluir autor                |

#### 📌 V2

| Método | Endpoint        | Descrição                          |
|--------|----------------|------------------------------------|
| POST   | /api/person/v2 | Cadastrar autor (versão evoluída)  |

---

### 📖 Livros

| Método | Endpoint           | Descrição                |
|--------|------------------|--------------------------|
| POST   | /api/book        | Cadastrar novo livro     |
| GET    | /api/book        | Listar todos os livros   |
| GET    | /api/book/{id}   | Buscar livro por ID      |
| PUT    | /api/book        | Atualizar livro          |
| DELETE | /api/book/{id}   | Excluir livro            |

---

### 🧪 Test Logs

| Método | Endpoint             | Descrição              |
|--------|---------------------|------------------------|
| GET    | /api/testlogs/v1    | Listar logs de teste   |

---

## ⚙️ Como Executar o Projeto

1. Clone o repositório:
```bash
git clone https://github.com/Isaac-Lima/rest-with-asp-net-10.git
```

2. Acessar a pasta do projeto:
```bash
cd rest-with-asp-net-10
```

3. Configurar o banco de dados

Abra o arquivo appsettings.json e configure a connection string:

```bash
"MSSQLServerConnection": {
  "MSSQLServerConnectionString": "Server=localhost;Database=SuaBase;User Id=sa;Password=SuaSenha;TrustServerCertificate=True"
}
```
4. Executar migrations (Evolve)

- Certifique-se que o SQL Server está rodando
- As migrations serão aplicadas automaticamente ao iniciar a aplicação (caso configurado)

5. Executar a aplicação

```bash
dotnet run
```

6. Acessar a API

- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000
---
## 📚 Documentação da API

- Swagger: https://localhost:5001/swagger-ui/index.html
- Scalar: https://localhost:5001/scalar
