CREATE TABLE public."Experiencias"(
    "Id" UUID PRIMARY KEY,
    "Titulo" VARCHAR(255) NOT NULL,
    "Descricao" VARCHAR(225) NOT NULL,
    "Status" INTEGER NOT NULL
    "DataInicio" DATE NOT NULL,
    "DataConclusao" DATE,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP
);