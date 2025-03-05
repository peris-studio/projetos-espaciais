CREATE TABLE public."Contatos" (
    "Id" UUID PRIMARY KEY,
    "TipoContato" INTEGER NOT NULL,
    "Contato" VARCHAR(255) NOT NULL,
<<<<<<< HEAD
    "ContatoPrincipal" BOOLEAN NOT NULL,
=======
    "Principal" BOOLEAN NOT NULL,
>>>>>>> origin/feat/projetos-aeroespaciais-1
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);