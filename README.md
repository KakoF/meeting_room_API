# Web Service de Agendamento
Web Service criado com Visual Studio na plataforma .Net core Web Api 1.0(NECESSÁRIO A DEPENDENCIA DO PACOTE 1.0)

# Banco de dados e pendência:
### Usei mysql, e estou enviando o script simples da base neste projeto... Retirei apenas o usuário e senha da string de conexão:

# Rodar o projeto:
### Com Visual Studio ou no diretório da aplicação rodar o comando:

##### dotnet build
##### dotnet run

Atentar que obtive saida diferente de portas executando o projeto com visual studio e pelo terminal, mesmo setando a porta default como 5001 o visual studio apontava para outra

- command line: http://localhost:5001/api/values
- Visual Studio https://localhost:44328/api/values


# Documentação
### Documentação das APIS foram feitas com Swagger que seguem nas rotas:

- command line: http://localhost:5001/swagger/index.html
- Visual Studio https://localhost:44328/swagger/index.html


