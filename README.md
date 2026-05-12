#  Clyvo Petshop API

##  Integrantes

- **Vitor Dias dos Santos** — RM: 565422
- **Enrico Delesporte** — RM: 565760
- **Felipe Modesto** — RM: 561810

---

##  Domínio do Projeto

O domínio escolhido para o projeto foi **Petshop**.

O sistema foi modelado para representar a estrutura de um petshop completo, permitindo o gerenciamento de usuários, pets, produtos, pedidos, assinaturas de planos, prontuários médicos e consultas veterinárias.

---

##  SGBD Utilizado

**Oracle Database** — via provider `Oracle.EntityFrameworkCore`.

A connection string é configurada no `appsettings.json` sob a chave `PetshopOracle`. Credenciais reais **não são commitadas** no repositório; utilize User Secrets ou variáveis de ambiente para fornecer a string de conexão em desenvolvimento.

---

##  Arquitetura

O projeto segue os princípios de **Clean Architecture**, organizado em quatro camadas:

| Camada | Projeto | Responsabilidade |
|---|---|---|
| Domain | `PetshopApi.Domain` | Entidades e regras de negócio |
| Application | `PetshopApi.Application` | DTOs e interfaces de repositório |
| Infrastructure | `PetshopApi.Infrastructure` | DbContext, mapeamentos, migrations e implementações de repositório |
| API | `PetshopApi.API` | Controllers, Program.cs e configuração de DI |

---

##  Entidades Modeladas

- User
- Pet
- Product
- Order
- ItemOrder
- Signature
- PlanData
- MedicalFile
- Query

---

##  Relacionamentos do Sistema

| Entidades | Cardinalidade |
|---|---|
| User → Pet | (1) : (N) |
| User → Order | (1) : (N) |
| User → Signature | (1) : (N) |
| Pet → MedicalFile | (1) : (1) |
| Pet → Query | (1) : (N) |
| Order → ItemOrder | (1) : (N) |
| ItemOrder → Product | (N) : (1) |
| Signature → PlanData | (1) : (N) |

---

##  Persistência com EF Core

### DbContext

O `PetShopContext` está localizado em `PetshopApi.Infrastructure/Persistence/` e expõe os seguintes `DbSet`s:

- `Users`
- `Pets`
- `Products`
- `Orders`
- `ItemOrders`
- `Signatures`
- `PlanDatas`
- `MedicalFiles`
- `Queries`

### Mapeamento — Fluent API

Cada entidade possui sua própria classe de configuração (`IEntityTypeConfiguration<T>`) em `PetshopApi.Infrastructure/Persistence/Configurations/`:

| Arquivo | Entidade |
|---|---|
| `UserConfiguration.cs` | User |
| `PetConfiguration.cs` | Pet |
| `ProductConfiguration.cs` | Product |
| `OrderConfiguration.cs` | Order |
| `ItemOrderConfiguration.cs` | ItemOrder |
| `SignatureConfiguration.cs` | Signature |
| `PlanDataConfiguration.cs` | PlanData |
| `MedicalFileConfiguration.cs` | MedicalFile |
| `QueryConfiguration.cs` | Query |

### Migration

Uma migration inicial foi gerada e cobre o esquema completo:

```
20260512115535_Initial
```

Para aplicar ao banco:

```bash
dotnet ef database update --project PetshopApi.Infrastructure --startup-project PetshopApi.API
```

### Repositórios

**Interfaces** (camada Application — `PetshopApi.Application/Services/`):

- `IUserRepository`
- `IPetRepository`
- `IProductRepository`
- `IOrderRepository`
- `IItemOrderRepository`
- `ISignatureRepository`
- `IPlanDataRepository`
- `IMedicalFileRepository`
- `IQueryRepository`

**Implementações** (camada Infrastructure — `PetshopApi.Infrastructure/`):

- `UserRepository`
- `PetRepository`
- `ProductRepository`
- `OrderRepository`
- `ItemOrderRepository`
- `SignatureRepository`
- `PlanDataRepository`
- `MedicalFileRepository`
- `QueryRepository`

### Injeção de Dependência

Registros realizados em `Program.cs`:

```csharp
builder.Services.AddDbContext<PetShopContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("PetshopOracle")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
// ... demais repositórios
```

---

##  Endpoints da API

Todos os controllers estão em `PetshopApi.API/Controllers/` e seguem o padrão `api/[controller]`. Cada entidade expõe:

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `api/{entidade}` | Lista todos os registros |
| `GET` | `api/{entidade}/{id:guid}` | Busca por ID |
| `POST` | `api/{entidade}` | Cria novo registro |
| `PUT` | `api/{entidade}/{id:guid}` | Atualiza registro |
| `DELETE` | `api/{entidade}/{id:guid}` | Remove registro |

### Rotas adicionais por entidade

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `api/pet/user/{userId}` | Pets de um usuário |
| `GET` | `api/order/user/{userId}` | Pedidos de um usuário |
| `GET` | `api/order/status/{status}` | Pedidos por status |
| `GET` | `api/product/category/{category}` | Produtos por categoria |
| `GET` | `api/product/species/{species}` | Produtos por espécie |
| `GET` | `api/itemorder/order/{orderId}` | Itens de um pedido |
| `GET` | `api/signature/user/{userId}` | Assinaturas de um usuário |
| `GET` | `api/plandata/signature/{signatureId}` | Planos de uma assinatura |
| `GET` | `api/plandata/active` | Planos ativos |
| `GET` | `api/medicalfile/pet/{petId}` | Prontuário de um pet |
| `GET` | `api/query/pet/{petId}` | Consultas de um pet |
| `GET` | `api/query/status/{status}` | Consultas por status |

A documentação interativa está disponível via **Swagger UI** em `/swagger` quando rodando em ambiente de desenvolvimento.

---

##  Como Executar

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
cd clyvo-petshop-dotnet
```

### 2. Configure a connection string via User Secrets

O projeto utiliza **User Secrets** para manter credenciais fora do repositório.

Navegue até o projeto da API e inicialize os secrets:

```bash
cd PetshopApi.API
dotnet user-secrets init
```

Em seguida, defina a connection string com seus dados do Oracle:

```bash
dotnet user-secrets set "ConnectionStrings:PetshopOracle" "User Id=<usuario>;Password=<senha>;Data Source=oracle.fiap.com.br:1521/orcl;"
```

Para verificar se o secret foi salvo corretamente:

```bash
dotnet user-secrets list
```

>  Os User Secrets ficam armazenados localmente na máquina do desenvolvedor e **nunca são commitados** no repositório. O arquivo `appsettings.json` contém apenas um placeholder e pode ser commitado normalmente.

### 3. Aplique as migrations

De volta à raiz da solução:

```bash
dotnet ef database update --project PetshopApi.Infrastructure --startup-project PetshopApi.API
```

### 4. Execute a API

```bash
dotnet run --project PetshopApi.API
```

### 5. Acesse o Swagger

Abra no navegador: `https://localhost:{porta}/swagger`

---

##  Estrutura de Pastas

```
clyvo-petshop-dotnet/
├── PetshopApi.Domain/
│   ├── Common/BaseEntity.cs
│   └── Entities/          # User, Pet, Product, Order, ItemOrder,
│                          # Signature, PlanData, MedicalFile, Query
├── PetshopApi.Application/
│   ├── DTOs/              # Request e Response por entidade
│   └── Services/          # Interfaces de repositório
├── PetshopApi.Infrastructure/
│   ├── Persistence/
│   │   ├── PetShopContext.cs
│   │   └── Configurations/ # IEntityTypeConfiguration<T> por entidade
│   ├── Migrations/         # 20260512115535_Initial
│   └── *Repository.cs      # Implementações dos repositórios
└── PetshopApi.API/
    ├── Controllers/        # Um controller por entidade
    ├── Program.cs          # DI e configuração
    └── appsettings.json
```
