# Challenge M Write

API que simula o cadastramento do Censo Demográfico de uma região.

# Tecnologias Usadas

- ASP.NET Core 3.1
- AutoFac
- Serilog
- MongoDB
- Docker
- XUnit
- AutoFixture
- NSubstitute
- FluentAssertions
- REST

# Principais pontos

- O desafio foi fragmentado em 2 APIs (escrita e leitura) para reduzir a complexidade, simplificar a manutebilidade, permitir maior escala e tolerar falhas
- Code Coverage em 86%
- HealthCheck para conexão com a base de dados
- Autenticação por X-API-KEY
- Log dos requests e responses
- Tratamento para exceções inesperadas
- "Dockerizada"

# Executando a aplicação localmente

- baixe e instale o SDK 3.1.402 do .NET Core: `https://dotnet.microsoft.com/download/dotnet-core/3.1`
- clone o repositório: `https://github.com/dmarins/challenge-m-write.git`
- avance para o diretório: `challenge-m-write`
- avance para o diretório: `src`
- execute o comando de compilação em seu terminal: `dotnet build`
- execute o comando de execução de todos os testes: `dotnet test`
- execute o comando de execução da aplicação: `dotnet run --project "M.Challenge.Write.Api"`
- use a collection do postman para verificar o healthcheck e cadastrar dados: `https://www.getpostman.com/collections/640b07051ea77540fb72`
- os logs registrados poderão ser visualizados em seu terminal
- pare a execução atráves do comando CTRL + C

# Executando a aplicação em container na sua máquina windows

- baixe e instale o Docker Desktop para Windows
- execute ele
- clone o repositório: `https://github.com/dmarins/challenge-m-write.git`
- avance para o diretório: `challenge-m-write`
- avance para o diretório: `src`
- execute o comando de geração de imagem em seu terminal: `docker build -t challenge-m-write:latest .`
- execute o comando de execução do docker em seu terminal: `docker run -p 5000:80 challenge-m-write:latest`
- use a collection do postman para verificar o healthcheck e cadastrar dados: `https://www.getpostman.com/collections/640b07051ea77540fb72`
- os logs registrados poderão ser visualizados em seu terminal
- saia da execução do container atráves do comando CTRL + C
- para saber o id do container em execução da imagem "challenge-m-write:latest" execute o comando: `docker ps -a`
- copie seu id
- para parar o container execute o comando: `docker stop {id do container}`
