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

INSERT INTO public."Plataformas" ("Id", "Nome", "Descricao", "TipoPlataforma", "CoordenadaLatitude", "CoordenadaAltitude", "StatusPlataforma", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    -- Adicione os UUIDs usados em Testes
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Plataforma Falcon 9', 'Lançador orbital reutilizável da SpaceX', 1, 28.5721, 0.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Plataforma Atlas V', 'Foguete para missões interplanetárias', 1, 34.6328, 0.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Plataforma Dragon', 'Cápsula para transporte de carga e tripulação', 2, 28.5721, 0.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE);