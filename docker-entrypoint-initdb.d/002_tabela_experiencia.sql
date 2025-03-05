CREATE TABLE public."Experiencias"(
    "Id" UUID PRIMARY KEY,
    "Titulo" VARCHAR(255) NOT NULL,
    "Descricao" TEXT NOT NULL,
    "Status" INTEGER NOT NULL
    "DataInicio" TIMESTAMP NOT NULL,
    "DataTermino" TIMESTAMP,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP
);