CREATE TABLE public."Licencas" (
    "Id" UUID PRIMARY KEY,
<<<<<<< HEAD
    "Tipo" INTEGER NOT NULL,
    "Nome" VARCHAR(225) NOT NULL,
=======
    "TipoLicenca" INTEGER NOT NULL,
>>>>>>> origin/feat/projetos-aeroespaciais-1
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