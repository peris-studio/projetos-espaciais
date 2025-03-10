CREATE TABLE public."Contatos" (
    "Id" UUID PRIMARY KEY,
    "TipoContato" INTEGER NOT NULL,
    "EnderecoContato" VARCHAR(255) NOT NULL,
    "Principal" BOOLEAN NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);

INSERT INTO public."Contatos" ("Id", "TipoContato", "EnderecoContato", "Principal", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 0, 'john.smith@nasa.gov', TRUE, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 1, '123-456-7890', TRUE, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 0, 'maria.gonzalez@nasa.gov', TRUE, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 0, 'sarah.williams@nasa.gov', TRUE, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 1, '098-765-4321', TRUE, CURRENT_TIMESTAMP, NULL, NULL, TRUE);