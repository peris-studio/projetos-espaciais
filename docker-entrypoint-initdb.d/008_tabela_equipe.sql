CREATE TABLE public."Equipes" (
    "Id" UUID PRIMARY KEY,
    "Codinome" VARCHAR(255) NOT NULL,
    "Funcao" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "Lider" UUID REFERENCES public."Membros"("Id"),
    "MembroId" UUID NOT NULL,
    "ContatoId" UUID NOT NULL,
    CONSTRAINT "FK_Membros" FOREIGN KEY ("MembroId") REFERENCES public."Membros"("Id"),
    CONSTRAINT "FK_Contatos" FOREIGN KEY ("ContatoId") REFERENCES public."Contatos"("Id")
);