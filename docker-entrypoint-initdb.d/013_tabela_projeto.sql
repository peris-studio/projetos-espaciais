CREATE TABLE public."Projetos" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(255) NOT NULL,
    "Descricao" TEXT NOT NULL,
    "Status" INTEGER NOT NULL,
    "DataInicio" TIMESTAMP NOT NULL,
    "DataTermino" TIMESTAMP,
    "Orcamento" DECIMAL NOT NULL,
    "FaseAtual" INTEGER NOT NULL,
    "GerenteTorre" VARCHAR(255) REFERENCES public."Membros"("NomeCompleto"),
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "MissaoId" UUID NOT NULL,
    CONSTRAINT "FK_Missoes" FOREIGN KEY ("MissaoId") REFERENCES public."Missoes"("Id")
);