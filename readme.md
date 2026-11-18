# API de Jogos — AP2 atualização

## Sobre o projeto

Este projeto é a evolução da API de Jogos desenvolvida na AP1. O objetivo é utilizar ASP.NET Core, .NET 10, Entity Framework Core e SQLite para cadastrar, consultar, atualizar e excluir jogos, mantendo os dados salvos em um banco de dados.

O projeto também possui uma interface web para interagir com os jogos por meio das rotas da API.

## Tecnologias utilizadas

- C#
- ASP.NET Core
- .NET 10
- Minimal API
- Entity Framework Core
- SQLite
- HTML, CSS e JavaScript
- Bruno para testar as requisições HTTP

## Requisitos

Para executar o projeto, é necessário ter instalado:

- .NET SDK 10
- Git
- Bruno, para executar os testes da API

A ferramenta `dotnet-ef` também é necessária para criar e aplicar migrations.

## Como executar o projeto

### 1. Entrar na pasta do projeto

Abra um terminal na pasta `ApiJogos`.

### 2. Restaurar as dependências

```bash
dotnet restore
```

### 3. Compilar a aplicação

```bash
dotnet build
```

### 4. Preparar o banco de dados

Execute:

```bash
dotnet ef database update
```

Esse comando aplica as migrations e cria ou atualiza o banco SQLite.

Se a ferramenta `dotnet-ef` ainda não estiver instalada, execute:

```bash
dotnet tool install --global dotnet-ef --version "10.*"
```

### 5. Iniciar a API

```bash
dotnet run --urls http://localhost:5050
```

A API estará disponível em:

http://localhost:5050

A interface web está localizada em `wwwroot/index.html` e deve ser acessada pelo mesmo endereço quando estiver funcionando corretamente.

## Endpoints da API

| Método | Endpoint | Descrição | Resposta esperada |
|---|---|---|---|
| GET | `/` | Verificar a aplicação e acessar a interface | 200 |
| GET | `/api/jogos` | Listar os jogos | 200 |
| GET | `/api/jogos/{id}` | Buscar jogo por ID | 200 ou 404 |
| POST | `/api/jogos` | Cadastrar um jogo | 201 |
| PUT | `/api/jogos/{id}` | Atualizar um jogo | 200 ou 404 |
| DELETE | `/api/jogos/{id}` | Excluir um jogo | 204 ou 404 |

## Exemplo de cadastro

**POST `/api/jogos`**

Body em JSON:

```json
{
  "nome": "GTA V",
  "genero": "Ação",
  "ano": 2013
}
```

## Exemplo de atualização

**PUT `/api/jogos/3`**

Body em JSON:

```json
{
  "nome": "GTA V",
  "genero": "Ação e Aventura",
  "ano": 2013
}
```

O ID deve corresponder ao jogo que será atualizado.

## Banco de dados e persistência

Os jogos são armazenados em um banco SQLite por meio do Entity Framework Core.

O `Jogo` representa a entidade de jogos, enquanto o `JogosDbContext` permite consultar, cadastrar, atualizar e excluir registros no banco.

As migrations definem a estrutura do banco e permitem prepará-lo novamente a partir do código versionado.

Os dados que não forem excluídos devem continuar disponíveis após reiniciar a API.

O arquivo local `jogos.db` contém os dados do banco e não deve ser enviado ao GitHub. As migrations devem permanecer no repositório.

## Interface web

A interface está localizada em `wwwroot/index.html`.

Quando executada corretamente, ela permite:

- Listar jogos cadastrados.
- Cadastrar novos jogos.
- Editar jogos existentes.
- Excluir jogos.

As operações devem utilizar os endpoints reais da API, sem depender de dados simulados.

Para acessar a interface, inicie a API e abra:

http://localhost:5050

## Testes com Bruno

A Collection utilizada nos testes está na pasta:

`bruno/Apijogos`

Os testes da API devem incluir:

- GET da coleção.
- GET por ID.
- POST para cadastrar.
- PUT para atualizar.
- DELETE para excluir.
- Consulta do ID excluído para verificar a resposta 404.

## Vídeo de demonstração — AP2

Link público do vídeo:

**COLOQUE_AQUI_O_LINK_PUBLICO_DO_VIDEO_AP2**

O vídeo deve demonstrar o funcionamento do backend, os testes no Bruno, as operações pela interface web e a persistência dos dados após reiniciar a aplicação.

## Autor

Lorenzo da Silveira Webber

link do vídeo:
https://drive.google.com/file/d/1dvHkMqtWAZ8tufyClAfDnqGDnWVArKLl/view?usp=sharing