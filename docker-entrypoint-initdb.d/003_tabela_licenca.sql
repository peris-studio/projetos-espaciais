CREATE TABLE public."Licencas" (
    "Id" UUID PRIMARY KEY,
    "TipoLicenca" INTEGER NOT NULL,
    "NumeroLicenca" VARCHAR(255) NOT NULL,
    "OrgaoEmissor" VARCHAR(255) NOT NULL,
    "DataEmissao" DATE NOT NULL,
    "DataValidade" DATE NOT NULL,
    "RequisitoConformidade" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);