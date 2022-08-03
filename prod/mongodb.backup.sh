#!/usr/bin/env bash

# Levantando o docker
echo "Iniciando backups..."
date_stamp=$(date +%F-%H-%M-%S)

echo "Criando backup - VacinaAltoParaiso"
sudo docker exec -it mongodbvacina mongodump --db VacinaAltoParaiso --out /data/backup/$date_stamp-vacinaAltoParaiso

echo "Criando backup - VacinaMonteNegro"
sudo docker exec -it mongodbvacina mongodump --db VacinaMonteNegro --out /data/backup/$date_stamp-vacinaMonteNegro

echo "Finalizado backups"