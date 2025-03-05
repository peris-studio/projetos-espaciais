CREATE TABLE public."Documentos" (
    "Id" UUID PRIMARY KEY,
    "Titulo" VARCHAR(255) NOT NULL,
    "Tipo" INTEGER NOT NULL,
    "Versao" VARCHAR(255) NOT NULL,
    "Arquivo" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL,
    "ClassificacaoSeguranca" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "HistoricoAlteracaoId" UUID [],
    "EquipeId" UUID NOT NULL,
    CONSTRAINT "FK_HistoricoAlteracoes" FOREIGN KEY ("HistoricoAlteracaoId") REFERENCES public."HistoricoAlteracoes"("Id"),
    CONSTRAINT "FK_Equipes" FOREIGN KEY ("EquipeId") REFERENCES public."Equipes"("Id")
)