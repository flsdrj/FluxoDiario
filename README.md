# FluxoDiario

Serviço de Aplicação Web escrita em .Net 6.0.
Utilizando contenerização Docker.
Com uma instância do SQl Server acoplada no container.

O Propósito da aplicação é possiblitar uma aplicação frotnt-end a ter acesso a serviços através de endpoints para controle diário de fluxo de caixa registrando seus Creditos e Débitos com a possibilidade de visualizar o relatório diário de saldo.

Para testá-la localmente, através do swagger:
1 - Necessita ter o Docker Desktop instalado, caso necessitar baixar, segue o link: "https://www.docker.com/products/docker-desktop";
2 - Efetuar o clone do projeto;
3 - Abrir o Terminal dentro da pasta onde o projeto foi clonado;
4 - Digitar o comando "docker compose up -d";
5 - Aguardar a aplicação subir, e em seguida acesse através do link "https:localhost\10000\swagger.index.html";
6 - Para parar de rodar a aplicação, no Terminal aberto na pasta do projeto, digitar o comando "docker compose down";
