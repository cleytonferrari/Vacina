# Vacina

Aplicativo para criar o vacinômetro, baseado nos arquivos exportados do [eSUS Notifica](https://notifica.saude.gov.br/) em formato *.csv, atendendo assim a transparência da divulgação das pessoas vacinadas no município.


## Começando

Veja se você tem [instalado](https://docs.docker.com/docker-for-windows/install/) docker. Após isto, você pode rodar o seguinte comando na pasta **/src/** para iniciar com o aplicativo `Vacina` imediatamente.

```powershell
docker build . -t vacina
docker run -d -p 8080:80 vacina
```

*Pronto! Agora basta acessar o endereço em seu navegador http://localhost:8080/*

*Nota 1: Você deve ter o MongoDb instalado no seu sistema e configurar as variáveis de ambiente no [appsettings.json](https://github.com/cleytonferrari/Vacina/blob/main/src/Web/WebMVC/appsettings.json)*
```json
"CONN_STRING":"mongodb://localhost:27017",
"CONN_DATABASE":"Vacina"
```

## Container Docker
Esta disponível uma [imagem docker](https://hub.docker.com/r/cleytonferrari/appvacina) do projeto no Docker Hub, se você tem [instalado](https://docs.docker.com/docker-for-windows/install/) docker. Execute o comando asseguir no console do seu docker.

```powershell
docker run -d -p 8080:80 cleytonferrari/appvacina
```

*Pronto! Agora basta acessar o endereço em seu navegador http://localhost:8080/*

## Docker Compose - Ambiente de Produção - Linux
Para disponibilizar o sistema de vacina em uma ambiente de produção `BETA`, siga os passoa abaixo:

1. Você deve ter um servidor rodando alguma versão do Linux, recomendado o [Ubuntu Server](https://ubuntu.com/download/server), com a [versão mais recente do docker](https://docs.docker.com/engine/install/ubuntu/).
2. Preparar a estrutura de pastas para a instação. Criar uma pasta raiz para o sistema `vacinometro` e uma pasta `database` para o volume do docker *(local onde ficara o banco de dados)*.

**Criando a pasta raiz da instalação**
```powershell
mkdir vacinometro
```
```powershell
cd vacinometro
```
**Dentro da pasta raiz, criado uma pasta para amarzenar o banco de dados**
```powershell
mkdir -pv database
```
3. Dentro da pasta `vacinometro`, baixe o arquivo [docker-compose.yaml](https://raw.githubusercontent.com/cleytonferrari/Vacina/main/src/docker-compose.yaml)
```
wget https://raw.githubusercontent.com/cleytonferrari/Vacina/main/src/docker-compose.yaml
```
5. Agora baixe o arquivo de configuração do [Caddy](https://caddyserver.com/) (Proxy reverso para adicionar https ao servidor)
```
wget https://raw.githubusercontent.com/cleytonferrari/Vacina/main/src/Caddyfile
```
*Observação: Você deve editar o arquivo baixado, adicionando o dominio onde ficara hospedado o serviço do aplicativo vacina e seu email.*

6. Agora basta rodar o comando do docker abaixo, para inicializar o aplicativo **Vacina**.

```powershell
docker-compose up -d
```

*Pronto! Agora basta acessar o endereço local no seu servidor https://localhost ou o dominio configurado no arquivo do [CaddyFile](https://github.com/cleytonferrari/Vacina/blob/main/src/Caddyfile).*

**Isto ira criar 3 containers do docker:**
* mondodbvacina (servidor do MondoDb)
* appvacina (aplicativo Vacina)
* caddy (proxy reverso para adicionar https ao servidor)

> ### DISCLAIMER
>
> **IMPORTANTE:** O estado atual deste aplicativo é **BETA**. Portanto, algumas áreas podem ser melhoradas e alteradas significativamente ao refatorar o código atual e implementar novos recursos. Feedback com melhorias e solicitações de pull da comunidade serão muito apreciados e aceitos.

## Em Produção

Você pode acessar os sites mencionados abaixo para ver o sistema em produção:

* Prefeitura de Alto Paraíso/RO - https://vacinometro.altoparaiso.ro.gov.br
* Prefeitura de Monte Negro/RO - https://vacinometro.montenegro.ro.gov.br

****
## Feedback e Pull Requests

Se você gostaria de ver qualquer cenário específico implementado ou melhorado acesse a [Sessão de ISSUES](https://github.com/cleytonferrari/vacina/issues). Além disso, fique à vontade para discutir qualquer assunto atual.
