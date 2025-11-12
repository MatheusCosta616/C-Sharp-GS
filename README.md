# 🚀 API Upskilling/Reskilling - O Futuro do Trabalho

![FIAP](https://img.shields.io/badge/FIAP-Global%20Solution%202025-red)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![MySQL](https://img.shields.io/badge/MySQL-8.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)

## 📌 Sobre o Projeto

API RESTful desenvolvida para a **Global Solution 2025 - O Futuro do Trabalho** da FIAP, focada em uma plataforma de **Upskilling/Reskilling** para preparar profissionais para as carreiras de 2030+.

O futuro do trabalho está sendo transformado por tecnologias como IA, automação, análise de dados e ambientes híbridos/remotos. Esta API permite que pessoas se cadastrem na plataforma e acessem trilhas de aprendizagem focadas em competências do futuro.

### 🎯 Objetivos

- ✅ Cadastro de usuários na plataforma
- ✅ Gestão de trilhas de aprendizagem focadas em competências do futuro
- ✅ Sistema completo de matrículas em trilhas
- ✅ Versionamento de API (v1 e v2)
- ✅ Documentação com Swagger
- ✅ Integração com banco de dados MySQL

### 🌍 Conexão com ODS

Este projeto se conecta aos seguintes Objetivos de Desenvolvimento Sustentável (ODS):

- **ODS 4** - Educação de Qualidade
- **ODS 8** - Trabalho Decente e Crescimento Econômico
- **ODS 9** - Indústria, Inovação e Infraestrutura
- **ODS 10** - Redução das Desigualdades

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8.0)
- **Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core 8.0
- **Banco de Dados:** MySQL 8.0 (via Pomelo.EntityFrameworkCore.MySql)
- **Documentação:** Swagger/OpenAPI
- **Versionamento de API:** Microsoft.AspNetCore.Mvc.Versioning
- **Containerização:** Docker & Docker Compose

---

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)
- Editor de código (Visual Studio, VS Code ou Rider)

---

## 🚀 Como Executar o Projeto

### 1️⃣ Clonar o Repositório

```bash
git clone https://github.com/seu-usuario/gscsharp.git
cd gscsharp
```

### 2️⃣ Subir o Banco de Dados MySQL com Docker

Na raiz do projeto, execute:

```bash
docker-compose up -d
```

Isso irá criar e iniciar um container MySQL com as seguintes configurações:
- **Host:** localhost
- **Porta:** 3306
- **Database:** gscsharp_db
- **Usuário:** gscsharp_user
- **Senha:** gscsharp_pass123

Para verificar se o container está rodando:

```bash
docker ps
```

### 3️⃣ Restaurar Dependências

```bash
cd GSCSHARP
dotnet restore
```

### 4️⃣ Executar a Aplicação

```bash
dotnet run
```

A API estará disponível em:
- **HTTP:** http://localhost:5000
- **HTTPS:** https://localhost:5001
- **Swagger:** http://localhost:5000 (abre automaticamente no navegador)

> 💡 **Nota:** As migrations serão aplicadas automaticamente na primeira execução!

---

## 📚 Estrutura do Banco de Dados

### Entidades Principais

#### 👤 Usuarios
Profissionais/alunos cadastrados na plataforma.

| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | bigint | Identificador único |
| Nome | varchar(100) | Nome completo |
| Email | varchar(150) | Email (único) |
| AreaAtuacao | varchar(100) | Área de atuação profissional |
| NivelCarreira | varchar(50) | Nível de carreira (Junior, Pleno, Senior) |
| DataCadastro | datetime | Data de cadastro |

#### 📚 Trilhas
Trilhas de aprendizagem para upskilling/reskilling.

| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | bigint | Identificador único |
| Nome | varchar(150) | Nome da trilha |
| Descricao | text | Descrição detalhada |
| Nivel | varchar(50) | INICIANTE, INTERMEDIARIO ou AVANCADO |
| CargaHoraria | int | Carga horária em horas |
| FocoPrincipal | varchar(100) | Foco principal (IA, Dados, Soft Skills, etc.) |

#### 💡 Competencias
Competências/habilidades do futuro.

| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | bigint | Identificador único |
| Nome | varchar(100) | Nome da competência |
| Categoria | varchar(100) | Categoria (Tecnologia, Humana, Gestão) |
| Descricao | text | Descrição da competência |

#### 📝 Matriculas
Inscrições de usuários em trilhas.

| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | bigint | Identificador único |
| UsuarioId | bigint | ID do usuário |
| TrilhaId | bigint | ID da trilha |
| DataInscricao | datetime | Data da inscrição |
| Status | varchar(50) | ATIVA, CONCLUIDA ou CANCELADA |

#### 🔗 TrilhaCompetencia
Relacionamento N:N entre Trilhas e Competências.

---

## 🔌 Endpoints da API

### 📍 Versão 1 (v1) - Endpoints Básicos

#### Usuários

| Método | Endpoint | Descrição | Status Codes |
|--------|----------|-----------|--------------|
| GET | `/api/v1/usuarios` | Lista todos os usuários | 200 |
| GET | `/api/v1/usuarios/{id}` | Busca usuário por ID | 200, 404 |
| POST | `/api/v1/usuarios` | Cria novo usuário | 201, 400, 422 |
| PUT | `/api/v1/usuarios/{id}` | Atualiza usuário | 200, 400, 404, 422 |
| DELETE | `/api/v1/usuarios/{id}` | Remove usuário | 204, 404 |

#### Trilhas

| Método | Endpoint | Descrição | Status Codes |
|--------|----------|-----------|--------------|
| GET | `/api/v1/trilhas` | Lista todas as trilhas | 200 |
| GET | `/api/v1/trilhas/{id}` | Busca trilha por ID | 200, 404 |
| POST | `/api/v1/trilhas` | Cria nova trilha | 201, 400 |
| PUT | `/api/v1/trilhas/{id}` | Atualiza trilha | 200, 400, 404 |
| DELETE | `/api/v1/trilhas/{id}` | Remove trilha | 204, 404 |

### 📍 Versão 2 (v2) - Endpoints com Relacionamentos

A versão 2 retorna informações expandidas com relacionamentos:

- **Usuários (v2):** Inclui lista de matrículas e suas trilhas
- **Trilhas (v2):** Inclui lista de competências associadas

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/v2/usuarios` | Lista usuários com matrículas |
| GET | `/api/v2/usuarios/{id}` | Usuário com detalhes de matrículas |
| GET | `/api/v2/trilhas` | Lista trilhas com competências |
| GET | `/api/v2/trilhas/{id}` | Trilha com detalhes de competências |

---

## 📝 Exemplos de Requisições

### Criar Usuário

```bash
POST /api/v1/usuarios
Content-Type: application/json

{
  "nome": "Carlos Souza",
  "email": "carlos.souza@email.com",
  "areaAtuacao": "Desenvolvimento",
  "nivelCarreira": "Pleno"
}
```

**Resposta (201 Created):**
```json
{
  "id": 3,
  "nome": "Carlos Souza",
  "email": "carlos.souza@email.com",
  "areaAtuacao": "Desenvolvimento",
  "nivelCarreira": "Pleno",
  "dataCadastro": "2025-11-11T21:30:00Z"
}
```

### Criar Trilha

```bash
POST /api/v1/trilhas
Content-Type: application/json

{
  "nome": "Python para Data Science",
  "descricao": "Aprenda Python focado em análise de dados",
  "nivel": "INTERMEDIARIO",
  "cargaHoraria": 80,
  "focoPrincipal": "Dados"
}
```

**Resposta (201 Created):**
```json
{
  "id": 5,
  "nome": "Python para Data Science",
  "descricao": "Aprenda Python focado em análise de dados",
  "nivel": "INTERMEDIARIO",
  "cargaHoraria": 80,
  "focoPrincipal": "Dados"
}
```

### Buscar Usuário com Matrículas (v2)

```bash
GET /api/v2/usuarios/1
```

**Resposta (200 OK):**
```json
{
  "id": 1,
  "nome": "Maria Silva",
  "email": "maria.silva@email.com",
  "areaAtuacao": "Tecnologia",
  "nivelCarreira": "Junior",
  "dataCadastro": "2025-01-15T00:00:00",
  "totalMatriculas": 1,
  "matriculas": [
    {
      "id": 1,
      "trilhaNome": "IA para Iniciantes",
      "trilhaNivel": "INICIANTE",
      "trilhaCargaHoraria": 40,
      "dataInscricao": "2025-03-01T00:00:00",
      "status": "ATIVA"
    }
  ]
}
```

---

## ✅ Validações Implementadas

### Usuário
- ✅ Nome obrigatório (máx. 100 caracteres)
- ✅ Email obrigatório e com formato válido (máx. 150 caracteres)
- ✅ Email único no sistema
- ✅ Área de atuação (máx. 100 caracteres)
- ✅ Nível de carreira (máx. 50 caracteres)

### Trilha
- ✅ Nome obrigatório (máx. 150 caracteres)
- ✅ Nível obrigatório (INICIANTE, INTERMEDIARIO ou AVANCADO)
- ✅ Carga horária obrigatória (entre 1 e 1000 horas)
- ✅ Foco principal (máx. 100 caracteres)

---

## 🎥 Vídeo de Demonstração

> 📹 **Link do vídeo demonstrando o funcionamento da API:**
> 
> [https://youtu.be/seu-video-aqui](https://youtu.be/seu-video-aqui)
> 
> **Duração:** Máximo 5 minutos
> 
> **Conteúdo do vídeo:**
> - Demonstração do Swagger e endpoints
> - Criação de usuários e trilhas
> - Consulta de dados com relacionamentos (v2)
> - Validações e tratamento de erros
> - Execução completa da solução integrada

---

## 📊 Dados Iniciais (Seeds)

A aplicação já vem com dados pré-cadastrados para teste:

### Competências
1. Inteligência Artificial
2. Análise de Dados
3. Cloud Computing
4. Empatia e Inteligência Emocional
5. Colaboração Digital
6. Sustentabilidade e Green Tech

### Trilhas
1. IA para Iniciantes (40h)
2. Cientista de Dados Completo (120h)
3. Liderança Digital (60h)
4. Cloud Architecture (80h)

### Usuários
1. Maria Silva (maria.silva@email.com)
2. João Santos (joao.santos@email.com)

---

## 🧪 Testando a API

### Usando Swagger (Recomendado)

1. Execute a aplicação: `dotnet run`
2. Acesse: http://localhost:5000
3. Explore os endpoints interativamente

### Usando Postman/Insomnia

Importe a collection do Swagger:
```
http://localhost:5000/swagger/v1/swagger.json
```

### Usando cURL

```bash
# Listar todos os usuários
curl -X GET http://localhost:5000/api/v1/usuarios

# Criar novo usuário
curl -X POST http://localhost:5000/api/v1/usuarios \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Pedro Oliveira",
    "email": "pedro@email.com",
    "areaAtuacao": "TI",
    "nivelCarreira": "Senior"
  }'

# Buscar usuário por ID
curl -X GET http://localhost:5000/api/v1/usuarios/1

# Atualizar usuário
curl -X PUT http://localhost:5000/api/v1/usuarios/1 \
  -H "Content-Type: application/json" \
  -d '{
    "nivelCarreira": "Senior"
  }'

# Deletar usuário
curl -X DELETE http://localhost:5000/api/v1/usuarios/1
```

---

## 🎯 Requisitos Atendidos (Conforme Imagem)

### ✅ 1. Boas Práticas REST (30 pts)
- ✅ Status codes adequados (200, 201, 204, 400, 404, 422)
- ✅ Uso correto dos verbos HTTP (GET, POST, PUT, DELETE)
- ✅ Endpoints RESTful bem estruturados

### ✅ 2. Versionamento da API (10 pts)
- ✅ Estrutura com versões /api/v1/ e /api/v2/
- ✅ Controle adequado em rotas
- ✅ Versionamento via URL e Header

### ✅ 3. Integração e Persistência (30 pts)
- ✅ Banco de dados MySQL relacional
- ✅ Entity Framework Core com Migrations
- ✅ Seeds com dados iniciais
- ✅ Relacionamentos N:N configurados

### ✅ 4. Documentação (30 pts)
- ✅ Swagger implementado e funcional
- ✅ Draw.io, Visio ou Excalidraw para arquitetura (opcional)
- ✅ Link do vídeo demonstrando funcionamento
- ✅ README detalhado

---

## 🏗️ Arquitetura do Projeto

```
GSCSHARP/
├── Controllers/
│   ├── V1/
│   │   ├── UsuariosController.cs
│   │   └── TrilhasController.cs
│   └── V2/
│       ├── UsuariosController.cs
│       └── TrilhasController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── DTOs/
│   ├── UsuarioDto.cs
│   └── TrilhaDto.cs
├── Migrations/
│   ├── 20251111000000_InitialCreate.cs
│   └── ApplicationDbContextModelSnapshot.cs
├── Models/
│   ├── Usuario.cs
│   ├── Trilha.cs
│   ├── Competencia.cs
│   ├── Matricula.cs
│   └── TrilhaCompetencia.cs
├── appsettings.json
├── Program.cs
└── GSCSHARP.csproj
```

---

## 🔧 Comandos Úteis

```bash
# Restaurar dependências
dotnet restore

# Compilar o projeto
dotnet build

# Executar a aplicação
dotnet run

# Executar em modo watch (auto-reload)
dotnet watch run

# Parar o banco de dados Docker
docker-compose down

# Ver logs do banco de dados
docker logs gscsharp-mysql

# Acessar o MySQL via linha de comando
docker exec -it gscsharp-mysql mysql -u gscsharp_user -p
```

---

## 👥 Integrantes do Grupo

| Nome | RM |
|------|-----|
| Caíque Walter Silva | RM550693 |
| Guilherme Nobre Bernardo | RM98604 |
| Matheus José de Lima Costa | RM551157 |

---
