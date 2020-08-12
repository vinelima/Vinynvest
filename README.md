# Vinynvest

Teste para desenvolvedor back-end na Easynvest

Esta solução consiste em uma API para retornar os investimentos de um cliente específico, vindo de 3 canais diversos (tesouro direto, renda fixa e fundos), retornando o valor total dos investimentos, e uma lista com todos eles, tendo o cálculo de imposto de renda, e do valor do resgate no momento atual em cada um dos investimentos listados.

## Decisões do projeto

Resolvi adotar todos os requisitos que foram pedidos no desafio, desta maneira procurei estruturar meu projeto em algumas camadas, utilizei injeção de dependência, procurei seguir algumas regras do clean code, e princípios do solid, tais como boas práticas de desenvolvimento, para garantir uma alta coesão. 
Falando de testes utilizei a biblioteca Xunit, pois é de fácil entendimento, e consegui garantir a validação das regras de negócio de maneira sucinta.
Em relação à monitoria utilizei os logs, que posso acompanhar nas configurações do meu App Service no Azure Cloud.
Utilizei o cache em memória com a interface IMemoryCache do .net, tive a opção de criar o cache distribuído com Redis, mas não o achei necessário, então optei por fazer de maneira mais simples, por ser um projeto bem pequeno.
E por fim publiquei no Azure Cloud, pois é bem prático e eficiente de configurar e fazer a publicação, e também por suas vantagens falando principalmente de se tratar de tecnologias Microsoft e possibilitar um fácil gerenciamento. Além disso é uma plataforma que possui uma variedade grande de serviços.
.

## Passos para executar o projeto

1. Faça o _fork_ do projeto (<https://github.com/vinelima/vinynvest/fork>)
2. Entre na pasta Vinynvest (api) (`cd Vinynvest`)
3. Rode o projeto (`dotnet run`) - Ou debugue o mesmo (F5)

## Instruções para compilar os testes

Para validar os testes no projeto Vinynvest.Test, basta seguir as instruções abaixo:

1. Faça o _fork_ do projeto (<https://github.com/vinelima/vinynvest/fork>)
2. Entre na pasta Vinynvest.Test (`cd Vinynvest.Test`)
3. Inicie os teste (`dotnet test`)
4. Verifique os resultados, e se os testes foram concluídos com êxito.

## Autor

Vinícius Silva Lima – [@_vinelima](https://www.linkedin.com/in/vin%C3%ADcius-lima-854659a3/) – lima-vinicius@outlook.com

~fictício - Distribuído sob a licença de Arcanine. Adquira um Growlithe e uma pedra do fogo para mais informações.

[https://github.com/vinelima](https://github.com/vinelima/)

## EndPoint

https://vinynvest.azurewebsites.net/api/investment