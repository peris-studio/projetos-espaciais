CREATE TABLE public."Veiculos" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(255),
    "Placa" VARCHAR(255) NOT NULL,
    "Marca" VARCHAR(225) NOT NULL,
    "Modelo" VARCHAR(255) NOT NULL,
    "Ano" INTEGER NOT NULL,
    "Cor" VARCHAR(255) NOT NULL,
    "TipoVeiculo" INTEGER NOT NULL,
    "TipoCombustivel" INTEGER NOT NULL,
    "TipoTransmissao" INTEGER NOT NULL,
    "StatusVeiculo" INTEGER NOT NULL,
    "Capacidade" VARCHAR(255) NOT NULL,
    "EspecificacaoTecnicaExtra" TEXT,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);

INSERT INTO public."Veiculos" ("Id", "Nome", "Placa", "Marca", "Modelo", "Ano", "Cor", "TipoVeiculo", "TipoCombustivel", "TipoTransmissao", "StatusVeiculo", "Capacidade", "EspecificacaoTecnicaExtra", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('7b3c948d-09ef-4639-adfc-86476c30467a', 'SpaceX Falcon 9', 'SPX-001', 'SpaceX', 'Falcon 9 Block 5', 2023, 'Branco', 1, 2, 1, 0, '22.8 tons de carga', 'Sistema de propulsão Merlin 1D+, capacidade para lançamentos de satélites e carga útil. Propulsão química com combustível líquido (RP1 e oxigênio líquido)', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('104af408-deb3-4cc4-b06d-90a21dc82db3', 'NASA Orion', 'NASA-OR01', 'Nasa', 'Orion MPCV', 2024, 'Prata', 2, 1, 2, 5, '4 tripulantes', 'Sistema de propulsão a gás e fusão nuclear para viagens interplanetárias, com capacidades de reentrada e pouso', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('65a7e587-e47c-45bb-a824-30573f99b334', 'Boeing CST-100 Starliner', 'Boeing-ST01', 'Boeing', 'CST-100 Starliner', 2025, 'Cinza', 3, 3, 1, 2, '7 tripulantes', 'Plataforma para transporte de tripulação e carga para a ISS e futuras missões. Propulsão química com oxigênio e hidrogênio líquidos', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('e018efb6-491e-4222-b263-a1aba374d46d', 'Blue Origin New Shepard', 'BO-NS01', 'Starlink', 'New Shepard', 2023, 'Azul', 4, 2, 3, 3, '6 passageiros', 'Veículo suborbital para turismo espacial e pesquisas científicas. Propulsão química com combustível sólido', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('94cdd0d2-729f-4956-893f-ec4f189ee9e0', 'Virgin Galactic VSS Unity', 'VG-VSS01', 'ITA', 'VSS Unity', 2023, 'Branco com detalhes vermelhos', 5, 2, 3, 4, '6 passageiros', 'Veículo espacial suborbital para turismo espacial de curta duração. Propulsão híbrida utilizando combustível sólido e líquido', CURRENT_TIMESTAMP, NULL, NULL, TRUE);