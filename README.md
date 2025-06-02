## Intruções...

1) Clone o projeto na Branch master
2) O projeto esta divido em duas pastas diferentes
   Front --> react-modulo
   Back --> Squader
3) Acesse a pasta Squader(back end) nela estara presente o yml (compose) do projeto
4) Acesse o terminal a partir desta pasta que contem o yml e digite o comando
   ### docker comopse up --build -d

5) O front-end estara acessivel na porta localhost:3000 do navegador e o Swagger na porta localhost:5000 coforme especificado dentro do yml


![image](https://github.com/user-attachments/assets/03d27332-7593-446f-ba07-4ea6cee216b1)

## Nota: Aguarde alguns segundos antes de acessar o app ou mesmo fazer alguma request.

## Necessário algum tempo para que todas as dependencias sejam devidamente baixadas , intaladas e mesmo injetadas na app.
## Foi criado um Data Seeder para que o SQL server quando subir a app fosse injetado 5 registros para o DB
## Foram feitas tratativas de restart do container caso a app tente injetar estes registros se o container SQL ainda nao estiver preparado devidamente
## Por conta disso uma pequena latencia foi notada

