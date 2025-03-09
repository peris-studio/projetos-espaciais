CREATE TABLE public."Licencas" (
    "Id" UUID PRIMARY KEY,
    "TipoLicenca" INTEGER NOT NULL,
    "Nome" VARCHAR(225) NOT NULL,
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

INSERT INTO public."Licencas" ("Id", "TipoLicenca", "Nome", "NumeroLicenca", "OrgaoEmissor", "DataEmissao", "DataValidade", "RequisitoConformidade", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 0, 'Licença de Lançamento Espacial', '1234567890', 'Agência Espacial Nacional', '2022-05-01', '2027-05-01', 'Cumprir requisitos técnicos e regulatórios para lançamento de veículos espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 1, 'Licença de Operação Espacial', '9876543210', 'Agência Espacial Internacional', '2020-10-10', '2025-10-10', 'Atender às normas de operação de satélites e espaçonaves', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 2, 'Licença de Pesquisa e Desenvolvimento Espacial', '1122334455', 'Instituto de Pesquisa Espacial', '2019-03-15', '2024-03-15', 'Cumprir com os requisitos de pesquisa e desenvolvimento tecnológico', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 3, 'Licença de Exploração Comercial Espacial', '5544332211', 'Agência Reguladora Espacial', '2021-07-22', '2026-07-22', 'Garantir a conformidade com as normas de exploração comercial do espaço', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 4, 'Licença de Comunicações Espaciais', '6677889900', 'Agência Nacional de Comunicações Espaciais', '2022-02-01', '2027-02-01', 'Atender às regulamentações sobre satélites de comunicação', CURRENT_TIMESTAMP, NULL, NULL, TRUE);