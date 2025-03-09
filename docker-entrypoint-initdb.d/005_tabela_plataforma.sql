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
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Estação Espacial Internacional', 'A estação espacial de pesquisa e desenvolvimento em órbita terrestre', 1, 28.5721, 408.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Satélite de Comunicações Espaciais', 'Satélite de comunicação em órbita geoestacionária', 2, -0.0, 35786.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Plataforma de Lançamento Lunar', 'Plataforma para lançamento de missões à Lua', 3, 0.0, 0.0, 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Base de Pesquisa em Marte', 'Base de pesquisa científica em Marte para exploração e colonização', 4, 18.4, 0.0, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Plataforma de Testes de Propulsão Espacial', 'Plataforma dedicada a testes de novos sistemas de propulsão espacial', 5, 34.5, 0.0, 3, CURRENT_TIMESTAMP, NULL, NULL, TRUE);