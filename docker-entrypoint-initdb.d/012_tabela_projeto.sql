CREATE TABLE public."Projetos" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(255) NOT NULL,
    "Descricao" TEXT NOT NULL,
    "StatusProjeto" INTEGER NOT NULL,
    "DataInicio" DATE NOT NULL,
    "DataTermino" DATE,
    "Orcamento" DECIMAL NOT NULL,
    "FaseAtual" INTEGER NOT NULL,
    "GerenteTorreId" UUID NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    CONSTRAINT "FK_GerenteTorre" FOREIGN KEY ("GerenteTorreId") REFERENCES public."Membros"("Id")
);

INSERT INTO public."Projetos" ("Id", "Nome", "Descricao", "StatusProjeto", "DataInicio", "DataTermino", "Orcamento", "FaseAtual", "GerenteTorreId", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
VALUES
    ('2c3289c5-679d-43c8-ba35-e12d12b4f3be', 'Exploração Lunar 2025', 'Projeto para preparar uma missão tripulada à Lua com foco em pesquisa científica e tecnologia de propulsão.', 2, '2025-01-01', '2025-12-31', 500000000.00, 1, 'a3d8f9b1-5c72-4a1e-987d-0b4c6d2e1f7a', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('37aa684f-9c2f-4ec1-a615-366083cdb3d7', 'Missão Marte 2026', 'Projeto de exploração e colonização de Marte com foco em estabelecer infraestrutura permanente.', 1, '2025-04-01', '2026-11-30', 1000000000.00, 2, 'a3d8f9b1-5c72-4a1e-987d-0b4c6d2e1f7a', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('b1019863-8cd1-4c67-90e2-b65a45b5d506', 'Sistema de Propulsão Avançada', 'Desenvolvimento de uma nova tecnologia de propulsão para missões interplanetárias.', 3, '2025-06-01', '2027-06-30', 750000000.00, 1, 'b2e4c6a8-9d3f-4a7b-85c1-1f8e5d3b0a9c', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('655bf4cc-bf3d-454c-add0-d1cd56ac520f', 'Projeto Estação Espacial 2030', 'Desenvolvimento de uma estação espacial modular para longas missões no espaço profundo.', 4, '2026-01-01', '2030-12-31', 1500000000.00, 3, 'c7f8d2a4-1e6b-49c3-85d0-3b9a4e6f2c1d', CURRENT_TIMESTAMP, NULL, NULL, TRUE),
    ('325524c9-652c-4e41-bb6a-d53afa36a6a9', 'Exploração do Asteroide 2027', 'Missão para enviar uma sonda ao cinturão de asteroides para coleta de dados e amostras.', 5, '2025-10-01', '2027-02-28', 300000000.00, 2, 'd5a9b3e7-2f4c-41d8-93a6-4c8e1f7d0b2a', CURRENT_TIMESTAMP, NULL, NULL, TRUE);
-- INSERT INTO public."Projetos" ("Id", "Nome", "Descricao", "StatusProjeto", "DataInicio", "DataTermino", "Orcamento", "FaseAtual", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo")
-- VALUES
--     ('2c3289c5-679d-43c8-ba35-e12d12b4f3be', 'Exploração Lunar 2025', 'Projeto para preparar uma missão tripulada à Lua com foco em pesquisa científica e tecnologia de propulsão.', 2, '2025-01-01', '2025-12-31', 500000000.00, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
--     ('37aa684f-9c2f-4ec1-a615-366083cdb3d7', 'Missão Marte 2026', 'Projeto de exploração e colonização de Marte com foco em estabelecer infraestrutura permanente.', 1, '2025-04-01', '2026-11-30', 1000000000.00, 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
--     ('b1019863-8cd1-4c67-90e2-b65a45b5d506', 'Sistema de Propulsão Avançada', 'Desenvolvimento de uma nova tecnologia de propulsão para missões interplanetárias.', 3, '2025-06-01', '2027-06-30', 750000000.00, 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
--     ('655bf4cc-bf3d-454c-add0-d1cd56ac520f', 'Projeto Estação Espacial 2030', 'Desenvolvimento de uma estação espacial modular para longas missões no espaço profundo.', 4, '2026-01-01', '2030-12-31', 1500000000.00, 3, CURRENT_TIMESTAMP, NULL, NULL, TRUE),
--     ('325524c9-652c-4e41-bb6a-d53afa36a6a9', 'Exploração do Asteroide 2027', 'Missão para enviar uma sonda ao cinturão de asteroides para coleta de dados e amostras.', 5, '2025-10-01', '2027-02-28', 300000000.00, 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE);