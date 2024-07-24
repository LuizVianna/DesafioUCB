# Desafio Técnico: Criação de uma WebAPI com .NET 8 com Autenticação
Este projeto tem o objetivo de atender o desafio da empresa UBC - União Brasileira dos Compositores
# Estrutura do projeto
  1. Camada UBC.Domain (Core da solution)
     1.1. Entities
     1.2. Interfaces de repositorios
     1.3. Validations
  2. Camada UBC.Infra.Data (camada de acesso a dados)
     2.1. Context -- No contexto foi colocado no método sobreescrito a capacidade de inserir a dados iniciais, tanto na tabela de User, e alguns registros na tabela de students.
     2.2. Migrations (Inicialmente foi solicitado que deveria ser realizada a persistencia de dados em menória, mas não consegui fazer em tempo hábil então, procurei fazer da forma que conheço e investir tempo no frontend que também não sabia fazer
     2.3. Repository 
3. Camada UBC.Application
   3.1. DTOs
   3.2. Interfaces de services
   3.3. Mappings
   3.4. Services
4. Camada UBC.Infra.IoC (camada criada para injetar dependências em uma classe 'DependencyInjection'), responsavel pela string de conexão, pela configuração do token de acesso jwt e as injeções de dependencias de serviços e de repositórios;
5. Camada UBC.Api camada de apresentação
