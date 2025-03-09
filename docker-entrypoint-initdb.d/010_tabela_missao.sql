CREATE TABLE public."Missoes" (
    "Id" UUID PRIMARY KEY,
    "Codinome" VARCHAR(255) NOT NULL,
    "Descricao" VARCHAR(225) NOT NULL,
    "TipoMissao" INTEGER NOT NULL,
    "Objetivo" TEXT NOT NULL,
    "StatusMissao" INTEGER NOT NULL,
    "DuracaoEstimada" VARCHAR(225) NOT NULL,
    "CustoEstimado" DECIMAL NOT NULL,
    "DataInicio" DATE NOT NULL,
    "DataTermino" DATE,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "VeiculoId" UUID NOT NULL,
    "PlataformaId" UUID NOT NULL,
    "EquipeId" UUID NOT NULL,
    "LicencasIds" UUID[] NOT NULL,  -- Array de Licenças
    CONSTRAINT "FK_Veiculos" FOREIGN KEY ("VeiculoId") REFERENCES public."Veiculos"("Id"),
    CONSTRAINT "FK_Plataformas" FOREIGN KEY ("PlataformaId") REFERENCES public."Plataformas"("Id"),
    CONSTRAINT "FK_Equipes" FOREIGN KEY ("EquipeId") REFERENCES public."Equipes"("Id")
);

-- Inserir 5 missões espaciais com diferentes dados
INSERT INTO public."Missoes" (
    "Id", "Codinome", "Descricao", "TipoMissao", "Objetivo", "StatusMissao", 
    "DuracaoEstimada", "CustoEstimado", "DataInicio", "DataTermino", 
    "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo", "VeiculoId", 
    "PlataformaId", "EquipeId", "LicencasIds"
) 
VALUES 
    -- Missão 1
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'MissaoSideralis', 
     'Missão de exploração interplanetária para Marte.', 1, 
     'Explorar a viabilidade de colonização em Marte e realizar testes de terraformação.', 
     1, '12 meses', 100000000.00, '2025-06-01', '2026-06-01', 
     CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 
     'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 
     '257c9a52-f4b7-4e29-af5e-7406ff11c6e2',
     '{257c9a52-f4b7-4e29-af5e-7406ff11c6e2, 60cc1b17-6bf7-4058-9c0e-7ce194d3559d}'),
     
    -- Missão 2
    ('b92e9f1e-01f6-44d1-9baf-d5701df58de5', 'MissaoGalaxia', 
     'Exploração do sistema estelar Alpha Centauri.', 2, 
     'Investigar a possibilidade de vida fora do nosso sistema solar.', 
     1, '18 meses', 200000000.00, '2025-09-01', '2027-03-01', 
     CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     'd4a1d29a-6b43-4081-8f7e-9bb9d1b70f94', 
     'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 
     '257c9a52-f4b7-4e29-af5e-7406ff11c6e2',
     '{60cc1b17-6bf7-4058-9c0e-7ce194d3559d, 4a2cb3f2-d724-4a5e-a1a6-0d8b238fc179}'),
     
    -- Missão 3
    ('7a1b17f8-5c56-4c9d-98b3-4a89d587c211', 'MissaoJupiter', 
     'Exploração de luas de Júpiter.', 3, 
     'Realizar uma análise de possíveis habitats em luas de Júpiter.', 
     1, '24 meses', 150000000.00, '2026-01-01', '2027-12-01', 
     CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     '9f8d08ab-9372-4d32-89fb-3a618eb7f1ef', 
     'af33b237-44a2-47f5-a813-e143d3c4551f', 
     '257c9a52-f4b7-4e29-af5e-7406ff11c6e2',
     '{4a2cb3f2-d724-4a5e-a1a6-0d8b238fc179, 5a1c92a7-cae7-4a3b-a87f-8b8bbd19c312}'),
     
    -- Missão 4
    ('3a94117e-06e3-4cc9-9f39-0c372d2b960f', 'MissaoLuar', 
     'Exploração de crateras lunares.', 4, 
     'Estudar as formações geológicas na Lua e avaliar recursos naturais.', 
     1, '6 meses', 50000000.00, '2025-12-01', '2026-06-01', 
     CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     '7a17f8c2-9d0c-4a29-9ab7-9a7bbf1f28b5', 
     'c9a9e8e3-9c75-408d-bb26-33a1bcb725eb', 
     '257c9a52-f4b7-4e29-af5e-7406ff11c6e2',
     '{257c9a52-f4b7-4e29-af5e-7406ff11c6e2}'),

    -- Missão 5
    ('a4b94a62-cf89-4d27-b7b2-9f547f88b428', 'MissaoCometa', 
     'Missão de coleta de amostras de cometas.', 5, 
     'Analisar a composição química de um cometa próximo à Terra.', 
     1, '9 meses', 120000000.00, '2026-02-01', '2026-11-01', 
     CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     '9d0e5d91-3bc9-4c16-9f6f-9b83b848810b', 
     '94bb6c0f-c1da-4b76-8469-ff4b3e5068d6', 
     '257c9a52-f4b7-4e29-af5e-7406ff11c6e2',
     '{60cc1b17-6bf7-4058-9c0e-7ce194d3559d, 4a2cb3f2-d724-4a5e-a1a6-0d8b238fc179}');