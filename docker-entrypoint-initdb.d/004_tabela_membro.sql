CREATE TABLE public."Membros"(
    "Id" UUID PRIMARY KEY,
    "NomeCompleto" VARCHAR(255) NOT NULL,
    "Funcao" VARCHAR(225) NOT NULL,
    "Especialidade" VARCHAR(225) NOT NULL,
    "Identificador" VARCHAR(4) NOT NULL,
    "Senha" VARCHAR(20) NOT NULL,
    "Genero" INTEGER NOT NULL,
    "DataNascimento" DATE NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);

INSERT INTO public."Membros" ("Id", "NomeCompleto", "Funcao", "Especialidade", "Identificador", "Senha", "Genero", "DataNascimento", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('a3d8f9b1-5c72-4a1e-987d-0b4c6d2e1f7a', 'Elon Musk', 'CEO', 'Engenharia Espacial', 'E001', 'SpaceX2024', 0, '1971-06-28', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('b2e4c6a8-9d3f-4a7b-85c1-1f8e5d3b0a9c', 'Gwynne Shotwell', 'COO', 'Gestão de Operações', 'G002', 'FalconHeavy', 1, '1963-11-23', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('c7f8d2a4-1e6b-49c3-85d0-3b9a4e6f2c1d', 'Jeff Bezos', 'Fundador', 'Exploração Lunar', 'J003', 'BlueOrigin', 0, '1964-01-12', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('d5a9b3e7-2f4c-41d8-93a6-4c8e1f7d0b2a', 'Bill Nelson', 'Administrador', 'Política Espacial', 'B004', 'NASA2024', 0, '1942-09-29', CURRENT_TIMESTAMP, NULL, NULL, TRUE);