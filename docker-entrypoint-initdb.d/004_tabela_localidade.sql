CREATE TABLE public."Localidades" (
    "Id" UUID PRIMARY KEY,
    "Sede" VARCHAR(225) NOT NULL,
    "Cidade" VARCHAR(255) NOT NULL,
    "Estado" VARCHAR(255) NOT NULL,
    "Pais" VARCHAR(255) NOT NULL,
    "EnderecoCompleto" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
<<<<<<< HEAD
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
=======
    "DataDelecao" TIMESTAMP
>>>>>>> origin/feat/projetos-aeroespaciais-1
);