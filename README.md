# Vacina

Aplicativo para criar o vacinômetro, baseado nos arquivos exportados do [eSUS Notifica](https://notifica.saude.gov.br/) em formato *.csv, atendendo assim a transparência da divulgação das pessoas vacinadas no município.


## Começando

Veja se você tem [instalado](https://docs.docker.com/docker-for-windows/install/) docker. Após isto, você pode rodar o seguinte comando na pasta **/src/** para iniciar com o aplicativo `Vacina` imediatamente.

```powershell
docker build . -t vacina
docker run -d -p 8080:80 vacina
```

*Pronto! Agora basta acessar o endereço em seu navegador http://localhost:8080/*

## Container Docker
Esta disponível uma [imagem docker](https://hub.docker.com/r/cleytonferrari/appvacina) do projeto no Docker Hub, se você tem [instalado](https://docs.docker.com/docker-for-windows/install/) docker. Execute o comando asseguir no consolole do seu docker.

```powershell
docker run -d -p 8080:80 cleytonferrari/appvacina
```

*Pronto! Agora basta acessar o endereço em seu navegador http://localhost:8080/*


> ### DISCLAIMER
>
> **IMPORTANTE:** O estado atual deste aplicativo é **BETA**. Portanto, algumas áreas podem ser melhoradas e alteradas significativamente ao refatorar o código atual e implementar novos recursos. Feedback com melhorias e solicitações de pull da comunidade serão muito apreciados e aceitos.

## Feedback e Pull Requests

Se você gostaria de ver qualquer cenário específico implementado ou melhorado acesse a [Sessão de ISSUES](https://github.com/cleytonferrari/vacina/issues). Além disso, fique à vontade para discutir qualquer assunto atual.
