# Projeto de Aplicação de listagem de CNAEs com consumo de API publica

## Descrição do Projeto

Projeto de testes de um aplicativo que consome a api publica de CNAEs (). Também é possível editar e excluir CNAEs do banco de dados.

## Tecnologias

- .NetCore C#
- Blazor
- Sqlite
- Entity Framework
## Rodar o projeto

Clone ou baixe o repositório

No "Package Manager", e rode uma nova migration:


```c
> add-migration Inicial
```

E em seguida aplique essas alterações ao banco de dados

```c
> update-database
```

Será criado um banco de dados SQLite, com dois registros de CNAEs.

- Estrutura do banco:		
	- Tabela CNAE

- Coluna
	- ID
	- CNAEID
	- Atividade
	- Descrição

## Utilização do Aplicativo

A navegação é feita através do menu lateral.

A aplicação possui 4 telas, sendo Home, AdicionaApi, ListaCNAES, EdicaodeCNAES.

### Tela Home

Mostra informações iniciais da aplicação.

![Tela home!](/Shared/Home.png "Tela Home")

### Tela de Listagem de Cnaes

Mostra uma listagem de todos os CNAEs presentes no banco de dados, e tem botão de edição para cada CNAE.


### Tela Edição de CNAEs

Possuí 3 inputs de dados para edição das informações do CNAE, me dois botões para edição ou exclusão do CNAE.

### Tele da busca pela API

> :warning: **Warning:** Fazer consulta utilizando apenas números.

Possui um input para informação no CNAE pesquisado e um botão para buscar através da API.




