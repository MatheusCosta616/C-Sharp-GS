# 🚀 Início Rápido

## Passo 1: Iniciar o MySQL

```powershell
# Na raiz do projeto (onde está o docker-compose.yml)
docker-compose up -d
```

## Passo 2: Executar a API

```powershell
# Entre na pasta do projeto
cd GSCSHARP

# Execute a aplicação
dotnet run
```

## Passo 3: Acessar o Swagger

Quando a aplicação iniciar, você verá uma mensagem:
```
Now listening on: http://localhost:XXXX
```

Abra seu navegador na URL indicada (geralmente **http://localhost:5163** ou **http://localhost:5000**)

O Swagger abrirá automaticamente mostrando todos os endpoints!

---

## 🔥 Testar Rapidamente

**Nota:** Substitua `localhost:XXXX` pela porta que apareceu no console (ex: 5163 ou 5000)

### Listar todos os usuários (v1)
```
GET http://localhost:5163/api/v1/usuarios
```

### Listar usuários com matrículas (v2)
```
GET http://localhost:5163/api/v2/usuarios
```

### Criar novo usuário
```
POST http://localhost:5163/api/v1/usuarios
Content-Type: application/json

{
  "nome": "Seu Nome",
  "email": "seu.email@exemplo.com",
  "areaAtuacao": "Tecnologia",
  "nivelCarreira": "Pleno"
}
```

### Listar todas as trilhas
```
GET http://localhost:5163/api/v1/trilhas
```

### Listar trilhas com competências (v2)
```
GET http://localhost:5163/api/v2/trilhas
```

---

## 📊 Dados Pré-cadastrados

A API já vem com dados de exemplo:

- ✅ 6 Competências (IA, Dados, Cloud, etc.)
- ✅ 4 Trilhas de aprendizagem
- ✅ 2 Usuários de exemplo
- ✅ 2 Matrículas ativas

Explore pelo Swagger!

---

## 🛑 Parar tudo

```powershell
# Parar a API: Ctrl+C no terminal

# Parar o MySQL:
docker-compose down
```

---

## 💡 Dicas

- Use **Swagger** para testar interativamente
- A **v2** retorna dados mais completos (com relacionamentos)
- As **migrations** aplicam automaticamente ao iniciar
- Consulte o **README.md** para documentação completa
