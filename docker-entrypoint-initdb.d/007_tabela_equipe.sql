CREATE TABLE public."Equipes" (
    "Id" UUID PRIMARY KEY,
    "Codinome" VARCHAR(255) NOT NULL,
    "Funcao" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "Lider" UUID REFERENCES public."Membros"("Id"),
    "MembroId" UUID NOT NULL,
    "ContatoId" UUID NOT NULL,
    CONSTRAINT "FK_Membros" FOREIGN KEY ("MembroId") REFERENCES public."Membros"("Id"),
    CONSTRAINT "FK_Contatos" FOREIGN KEY ("ContatoId") REFERENCES public."Contatos"("Id")
);

INSERT INTO public."Equipes" ("Id", "Codinome", "Funcao", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo", "Lider", "MembroId", "ContatoId")
VALUES
    -- Equipes usadas em Documentos (UUIDs corrigidos)
    ('a96cfdd9-ce1e-41e7-9483-1691e87c8780', 'Equipe Falcão', 'Lançamento de Veículos Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'c7f8d2a4-1e6b-49c3-85d0-3b9a4e6f2c1d', 'c7f8d2a4-1e6b-49c3-85d0-3b9a4e6f2c1d', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d'),
    ('97dbd619-ae50-4a3e-ac97-926b95f251c2', 'Equipe Pioneira', 'Exploração de Marte', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'a3d8f9b1-5c72-4a1e-987d-0b4c6d2e1f7a', 'a3d8f9b1-5c72-4a1e-987d-0b4c6d2e1f7a', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d'),
    ('ac1131b5-ccd1-46ef-9a07-05868e8d46a3', 'Equipe Atlas', 'Pesquisas Científicas Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'd5a9b3e7-2f4c-41d8-93a6-4c8e1f7d0b2a', 'd5a9b3e7-2f4c-41d8-93a6-4c8e1f7d0b2a', '4c6fb5e9-8073-4bfe-8095-49c173108983');