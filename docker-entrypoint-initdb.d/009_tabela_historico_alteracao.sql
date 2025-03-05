CREATE TABLE public."HistoricoAlteracoes" (
    "Id" UUID PRIMARY KEY,
    "TipoAlteracao" INTEGER NOT NULL,
    "Descricao" VARCHAR(255) NOT NULL,
    "Motivacao" TEXT NOT NULL,
    "NivelImpacto" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "EquipeResponsavel" VARCHAR(255) REFERENCES public."Equipes"("Codinome")
);