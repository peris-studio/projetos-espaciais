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
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Centro Espacial Nacional', 'Brasília', 'Distrito Federal', 'Brasil', 'Avenida das Nações, 1000, Centro, Brasília, DF, Brasil', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Centro de Lançamento Espacial', 'Cabo Frio', 'Rio de Janeiro', 'Brasil', 'Rodovia dos Espaciais, 500, Cabo Frio, RJ, Brasil', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Estação Espacial Internacional', 'Baikonur', 'Kyzylorda', 'Cazaquistão', 'Avenida Cosmonautas, Baikonur, Kyzylorda, Cazaquistão', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Centro de Pesquisa e Desenvolvimento Espacial', 'Houston', 'Texas', 'Estados Unidos', 'NASA Parkway, 2100, Houston, TX, USA', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Agência Espacial Europeia', 'Paris', 'Île-de-France', 'França', 'Rue des Spatiaux, 200, Paris, Île-de-France, França', CURRENT_TIMESTAMP, NULL, NULL, TRUE);