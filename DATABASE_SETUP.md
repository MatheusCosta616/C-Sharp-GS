# 🔧 Guia de Configuração do Banco de Dados

## ⚠️ Se encontrar erro "Table doesn't exist"

Siga estes passos para configurar o banco corretamente:

### Passo 1: Recriar o Banco de Dados

```powershell
docker exec -it gscsharp-mysql mysql -u root -proot123 -e "DROP DATABASE IF EXISTS gscsharp_db; CREATE DATABASE gscsharp_db;"
```

### Passo 2: Executar o Script de Setup

```powershell
Get-Content setup_database.sql | docker exec -i gscsharp-mysql mysql -u gscsharp_user -pgscsharp_pass123 gscsharp_db
```

### Passo 3: Verificar as Tabelas

```powershell
docker exec -it gscsharp-mysql mysql -u gscsharp_user -pgscsharp_pass123 gscsharp_db -e "SHOW TABLES;"
```

Deve mostrar:
```
Competencias
Matriculas
TrilhaCompetencias
Trilhas
Usuarios
```

### Passo 4: Executar a API

```powershell
cd GSCSHARP
dotnet run
```

## 📊 Verificar Dados Iniciais

Para ver os dados pré-cadastrados:

```powershell
# Ver usuários
docker exec -it gscsharp-mysql mysql -u gscsharp_user -pgscsharp_pass123 gscsharp_db -e "SELECT * FROM Usuarios;"

# Ver trilhas
docker exec -it gscsharp-mysql mysql -u gscsharp_user -pgscsharp_pass123 gscsharp_db -e "SELECT * FROM Trilhas;"

# Ver competências
docker exec -it gscsharp-mysql mysql -u gscsharp_user -pgscsharp_pass123 gscsharp_db -e "SELECT * FROM Competencias;"
```

## ✅ Tudo Pronto!

Agora você pode:
1. Acessar http://localhost:5163
2. Testar os endpoints no Swagger
3. Usar a collection do Postman

---

**Nota:** O arquivo `setup_database.sql` contém todo o schema e dados iniciais do banco.
