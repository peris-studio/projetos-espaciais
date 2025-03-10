CREATE TABLE public."Localidades" (
    "Id" UUID PRIMARY KEY,
    "Sede" VARCHAR(225) NOT NULL,
    "Cidade" VARCHAR(255) NOT NULL,
    "Estado" VARCHAR(255) NOT NULL,
    "Pais" VARCHAR(255) NOT NULL,
    "EnderecoCompleto" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);

INSERT INTO public."Localidades" ("Id", "Sede", "Cidade", "Estado", "Pais", "EnderecoCompleto", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    -- Localidades usadas nos Testes (UUIDs corrigidos)
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Centro Espacial Kennedy', 'Cabo Canaveral', 'Flórida', 'Estados Unidos', 'Kennedy Space Center, Flórida, EUA', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Base de Lançamento de Vandenberg', 'Lompoc', 'Califórnia', 'Estados Unidos', 'Vandenberg Space Force Base, Califórnia, EUA', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Estação Espacial Internacional', 'Órbita Terrestre', '-', 'Internacional', 'Órbita Terrestre Baixa', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Centro Espacial de Baikonur', 'Baikonur', 'Kyzylorda', 'Cazaquistão', 'Cosmódromo de Baikonur, Cazaquistão', CURRENT_TIMESTAMP, NULL, NULL, TRUE);