# Supero_Teste
Aplicação como parte de teste prático.

Na parte do backend, foram utilizadas as tecnologias ASP.NET Core 2.1, Swagger, EntityFramework Core, Migrations e Fluent Validator. Também foi utilizado o pattern de repositório genérico, por onde o repositório específico de cada entidade vai variar com o tipo passado pelo generics. Também foi utilizado o pattern de UnitOfWork para coordenar as transações. Foi utilizado também o pattern de segregação por interfaces, respeitando um dos princípios SOLID. Além deste, também o princípio da responsabilidade única com a componentização dos métodos. Outro pattern utilizado foi o de QuerySpecification para blindar as consultas nas listas de retorno e ajudar na manutenção dessas consultas com lambda e LINQ, evitando duplicidades ao longo do código.

A arquitetura está definida como Controller -> Serviço -> Repository, tendo também uma camada de exceções, uma de injeção de dependência e outra de validações. Na parte das controllers, todos os métodos que fazem algum tipo de persistência, com exceção da exclusão, foram implementados com base no verbo PUT. De acordo com a RFC 7231, o verbo PUT deve ser utilizado sempre que conhecemos o recurso que vai persistir os dados. Como estou passando as url's diretamente pelo front, foi utilizado o PUT. Se for necessário, é só implementar uma camada de autorização com base no JWT para blindar esse acesso ao servidor.

No frontend, que está em WebClient, foi utilizado o Angular 4 com bootstrap. 
