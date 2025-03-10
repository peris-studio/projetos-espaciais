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
    CONSTRAINT "FK_Veiculos" FOREIGN KEY ("VeiculoId") REFERENCES public."Veiculos"("Id"),
    CONSTRAINT "FK_Plataformas" FOREIGN KEY ("PlataformaId") REFERENCES public."Plataformas"("Id"),
    CONSTRAINT "FK_Equipes" FOREIGN KEY ("EquipeId") REFERENCES public."Equipes"("Id")
);

INSERT INTO public."Missoes" ("Id", "Codinome", "Descricao", "TipoMissao", "Objetivo", 
                              "StatusMissao", "DuracaoEstimada", "CustoEstimado", "DataInicio", 
                              "DataTermino", "DataCriacao", "DataAtualizacao", "DataDelecao", 
                              "Ativo", "VeiculoId", "PlataformaId", "EquipeId") 
VALUES
    ('c8a24d9f-8f5f-4f2f-bbe9-f4c28a7b9a26', 'M1', 'Missão para enviar uma nave até a órbita de Marte', 1, 
     'Explorar a superfície de Marte e coletar dados científicos.', 1, '12 meses', 500000000, '2025-06-01', 
     '2026-06-01', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '7b3c948d-09ef-4639-adfc-86476c30467a', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'a96cfdd9-ce1e-41e7-9483-1691e87c8780'),

    ('d8e6f5a1-4a65-4062-9251-70f729309227', 'M2', 'Missão de teste para enviar veículo ao espaço profundo', 2, 
     'Testar a viabilidade de viagens interplanetárias e estabelecer comunicação constante.', 2, '24 meses', 100000000, '2025-07-15', 
     '2027-07-15', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '104af408-deb3-4cc4-b06d-90a21dc82db3', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'ac1131b5-ccd1-46ef-9a07-05868e8d46a3'),

    ('b4f9a5d7-3b85-4f1e-b5f0-158e21e89d60', 'M3', 'Missão de exploração de satélite natural de Saturno', 3, 
     'Estudar as condições de atmosfera e geologia de Titã, uma das luas de Saturno.', 3, '36 meses', 75000000, '2025-08-01', 
     '2028-08-01', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '65a7e587-e47c-45bb-a824-30573f99b334', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '97dbd619-ae50-4a3e-ac97-926b95f251c2'),

    ('4ea65a78-cd3f-4a4c-88c1-114fe88922fe', 'M4', 'Missão de reparo e manutenção de satélites de comunicação', 4, 
     'Manter e melhorar a rede de satélites de comunicação em órbita.', 4, '6 meses', 200000000, '2025-09-01', 
     '2026-03-01', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'e018efb6-491e-4222-b263-a1aba374d46d', 'a999c838-0c75-4d70-8f64-d560cac90965', 'a96cfdd9-ce1e-41e7-9483-1691e87c8780');