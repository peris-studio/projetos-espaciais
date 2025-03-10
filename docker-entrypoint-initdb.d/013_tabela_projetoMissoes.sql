CREATE TABLE public."ProjetoMissoes"(
    "Id" UUID PRIMARY KEY,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "ProjetoId" UUID NOT NULL,
    "MissaoId" UUID NOT NULL,
    CONSTRAINT "FK_Projetos" FOREIGN KEY("ProjetoId") REFERENCES public."Projetos"("Id"),
    CONSTRAINT "FK_Missoes" FOREIGN KEY ("MissaoId") REFERENCES public."Missoes"("Id")
);

-- Inserir um projeto espacial
-- INSERT INTO public."Projetos"("Id", "Nome", "Descricao", "StatusProjeto", "DataInicio", "DataTermino",
--                               "Orcamento", "FaseAtual", "GerenteTorreId", "DataCriacao", 
--                               "DataAtualizacao", "DataDelecao", "Ativo", "MissaoId"
-- )

-- VALUES
--     ('d517c9a9-1b64-4b75-9f9d-740db9b85e3e', 'ProjetoExploracaoMarte',
--      'Projeto de longo prazo para exploração e possível colonização de Marte.',
--      1, '2025-01-01', '2030-12-31', 500000000.00, 1,
--      '8a599c85-23c2-4b8d-ae62-b346059a6e32', CURRENT_TIMESTAMP, NULL, NULL, TRUE,
--      '60cc1b17-6bf7-4058-9c0e-7ce194d3559d');

-- Inserir um projeto espacial
INSERT INTO public."ProjetoMissoes"("Id", "DataCriacao", "Ativo", "ProjetoId", "MissaoId")
VALUES
    ('d517c9a9-1b64-4b75-9f9d-740db9b85e3e', CURRENT_TIMESTAMP, TRUE, '2c3289c5-679d-43c8-ba35-e12d12b4f3be', 'c8a24d9f-8f5f-4f2f-bbe9-f4c28a7b9a26'),
    ('7804ef15-839c-4140-80c5-fe3261b041d7', CURRENT_TIMESTAMP, TRUE, '37aa684f-9c2f-4ec1-a615-366083cdb3d7', 'd8e6f5a1-4a65-4062-9251-70f729309227'),
    ('0f8d306f-99b4-431d-81fb-f9d5f5e7182f', CURRENT_TIMESTAMP, TRUE, 'b1019863-8cd1-4c67-90e2-b65a45b5d506', 'b4f9a5d7-3b85-4f1e-b5f0-158e21e89d60'),
    ('7bbff3c7-96cc-4ca7-b90a-af320c19698f', CURRENT_TIMESTAMP, TRUE, '655bf4cc-bf3d-454c-add0-d1cd56ac520f', 'c8a24d9f-8f5f-4f2f-bbe9-f4c28a7b9a26'),
    ('49870519-2d23-46e7-8f11-43a565b9a611', CURRENT_TIMESTAMP, TRUE, '325524c9-652c-4e41-bb6a-d53afa36a6a9', 'd8e6f5a1-4a65-4062-9251-70f729309227');