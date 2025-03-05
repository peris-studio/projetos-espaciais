CREATE TABLE public."Missoes" (
    "Id" UUID PRIMARY KEY,
    "Codinome" VARCHAR(255) NOT NULL,
    "Descricao" VARCHAR(225) NOT NULL,
    "TipoMissao" INTEGER NOT NULL,
    "Objetivo" TEXT NOT NULL,
    "Status" INTEGER NOT NULL,
    "DuracaoEstimada" INTEGER NOT NULL,
    "CustoEstimado" DECIMAL NOT NULL,
    "DataInicio" DATE NOT NULL,
    "DataTermino" DATE,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP
    "Ativo" BOOLEAN NOT NULL
    "ProjetoId" UUID NOT NULL,
    "VeiculoId" UUID NOT NULL,
    "PlataformaId" UUID NOT NULL,
    "TesteId" UUID[] NOT NULL,
    CONSTRAINT "FK_Projetos" FOREIGN KEY ("ProjetoId") REFERENCES public."Projetos"("Id"),
    CONSTRAINT "FK_Veiculos" FOREIGN KEY ("VeiculoId") REFERENCES public."Veiculos"("Id"),
    CONSTRAINT "FK_Plataformas" FOREIGN KEY ("PlataformaId") REFERENCES public."Plataformas"("Id")
);