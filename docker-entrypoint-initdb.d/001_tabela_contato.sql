CREATE TABLE public."Contatos" (
    "Id" UUID PRIMARY KEY,
    "TipoContato" INTEGER NOT NULL,
    "Contato" VARCHAR(255) NOT NULL,
    "ContatoPrincipal" BOOLEAN NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);