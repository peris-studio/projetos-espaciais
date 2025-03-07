CREATE TABLE public."Plataformas" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(255) NOT NULL,
    "Descricao" TEXT NOT NULL,
    "TipoPlataforma" INTEGER NOT NULL,
    "CoordenadaLatitude" DECIMAL NOT NULL,
    "CoordenadaAltitude" DECIMAL NOT NULL,
    "StatusPlataforma" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);