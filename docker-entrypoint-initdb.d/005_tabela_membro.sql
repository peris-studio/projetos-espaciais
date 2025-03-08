CREATE TABLE public."Membros"(
    "Id" UUID PRIMARY KEY,
    "NomeCompleto" VARCHAR(255) NOT NULL,
    "Funcao" VARCHAR(225) NOT NULL,
    "Especialidade" VARCHAR(225) NOT NULL,
    "Identificador" VARCHAR(4) NOT NULL,
    "Senha" VARCHAR(20) NOT NULL,
    "Genero" INTEGER NOT NULL,
    "DataNascimento" DATE NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);