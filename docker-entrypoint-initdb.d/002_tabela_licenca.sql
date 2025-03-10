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
    ('10a1636a-4f0a-4173-a189-a0ebf2886b5b', 0, 'Licença de Lançamento Espacial', '1234567890', 'Agência Espacial Nacional', '2022-05-01', '2027-05-01', 'Cumprir requisitos técnicos e regulatórios para lançamento de veículos espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('ef3bc37a-d3b6-49df-b4ae-9a1ed4999a05', 1, 'Licença de Operação Espacial', '9876543210', 'Agência Espacial Internacional', '2020-10-10', '2025-10-10', 'Atender às normas de operação de satélites e espaçonaves', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('2d6f1c8b-1752-4e74-a42c-c5c5e7b4891b', 2, 'Licença de Pesquisa e Desenvolvimento Espacial', '1122334455', 'Instituto de Pesquisa Espacial', '2019-03-15', '2024-03-15', 'Cumprir com os requisitos de pesquisa e desenvolvimento tecnológico', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('e250e47c-4062-4ab0-a1cf-ed710d251e46', 3, 'Licença de Exploração Comercial Espacial', '5544332211', 'Agência Reguladora Espacial', '2021-07-22', '2026-07-22', 'Garantir a conformidade com as normas de exploração comercial do espaço', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('58725449-bb4c-40c7-a080-ec0c541489de', 4, 'Licença de Comunicações Espaciais', '6677889900', 'Agência Nacional de Comunicações Espaciais', '2022-02-01', '2027-02-01', 'Atender às regulamentações sobre satélites de comunicação', CURRENT_TIMESTAMP, NULL, NULL, TRUE);