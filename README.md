# AspNetUnitOfWork: Uma Implementação Simples de Unit of Work com Entity Framework Core

Este repositório demonstra a implementação do conceito de Unit of Work (Unidade de Trabalho) usando o Entity Framework Core para simplificar a manipulação de transações e operações de banco de dados em aplicativos ASP.NET.

## Descrição

O repositório tem como objetivo proporcionar uma implementação simples e rápida do conceito de Unit of Work (Unidade de Trabalho) utilizando o Entity Framework Core em aplicativos ASP.NET. 
O foco aqui é fornecer uma demonstração prática do conceito, com ênfase na funcionalidade em vez focar nos princípios de Clean Architecture e Clean Code.

## Tecnologias Utilizadas

- Entity Framework Core
- Banco de Dados In-Memory

## Configuração

A configuração do projeto é muito simples. Optei por usar um banco de dados In-Memory, que não requer configurações complexas. 

Registrei o banco de dados como um serviço Singleton no Container de Injeção de Dependência (DI). Essa escolha foi feita para evitar a criação de um novo banco a cada requisição, o que limparia os dados da memória. 
No entanto, é importante observar que essa decisão resultou na necessidade de alteração do método `RollBack()` na implementação do `UnityOfWorkRepository`.

Quando registramos o banco como Singleton, o `ChangeTracker` do contexto de dados permanece o mesmo durante todo o ciclo de vida da aplicação. Isso significa que entidades de requisições anteriores que não foram persistidas no banco 
podem ser salvas ao chamar o método `SaveChanges()`. 

É importante mencionar que este foi um cenário específico do teste realizado neste repositório e não reflete a realidade do mundo real.

## Uso

O projeto está pronto para rodar, sendo necessário apenas usar o comando `dotnet run`.
