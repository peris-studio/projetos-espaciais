CREATE TABLE public."Experiencias"(
    "Id" UUID PRIMARY KEY,
    "Titulo" VARCHAR(255) NOT NULL,
<<<<<<< HEAD
    "Descricao" VARCHAR(225) NOT NULL,
    "Status" INTEGER NOT NULL
    "DataInicio" DATE NOT NULL,
    "DataTermino" DATE,
=======
    "Descricao" TEXT NOT NULL,
    "Status" INTEGER NOT NULL
    "DataInicio" TIMESTAMP NOT NULL,
    "DataTermino" TIMESTAMP,
>>>>>>> origin/feat/projetos-aeroespaciais-1
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP
);