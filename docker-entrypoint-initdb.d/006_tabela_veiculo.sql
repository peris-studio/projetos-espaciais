CREATE TABLE public."Veiculos" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(255),
    "Placa" VARCHAR(255) NOT NULL,
    "Marca" INTEGER NOT NULL,
    "Modelo" VARCHAR(255) NOT NULL,
    "Ano" INTEGER NOT NULL,
    "Cor" VARCHAR(255) NOT NULL,
    "TipoVeiculo" INTEGER NOT NULL,
    "TipoCombustivel" INTEGER NOT NULL,
    "TipoTransmissao" INTEGER NOT NULL,
    "Capacidade" VARCHAR(255) NOT NULL,
    "EspecificacaoTecnicaExtra" TEXT,
    "StatusVeiculo" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);

INSERT INTO public."Veiculos" ("Id", "Nome", "Placa", "Marca", "Modelo", "Ano", "Cor", "TipoVeiculo", "TipoCombustivel", "TipoTransmissao", "Capacidade", "EspecificacaoTecnicaExtra", "StatusVeiculo", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'SpaceX Falcon 9', 'SPX-001', 1, 'Falcon 9 Block 5', 2023, 'Branco', 1, 2, 1, '22.8 tons de carga', 'Sistema de propulsão Merlin 1D+, capacidade para lançamentos de satélites e carga útil', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'NASA Orion', 'NASA-OR01', 2, 'Orion MPCV', 2024, 'Prata', 2, 1, 2, '4 tripulantes', 'Sistema de propulsão a gás e fusão nuclear para viagens interplanetárias', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Boeing CST-100 Starliner', 'Boeing-ST01', 3, 'CST-100 Starliner', 2025, 'Cinza', 3, 3, 1, '7 tripulantes', 'Plataforma para transporte de tripulação e carga para a ISS e futuras missões', 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Blue Origin New Shepard', 'BO-NS01', 4, 'New Shepard', 2023, 'Azul', 4, 2, 3, '6 passageiros', 'Veículo suborbital para turismo espacial e pesquisas científicas', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Virgin Galactic VSS Unity', 'VG-VSS01', 5, 'VSS Unity', 2023, 'Branco com detalhes vermelhos', 5, 2, 3, '6 passageiros', 'Veículo espacial suborbital para turismo espacial de curta duração', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE);