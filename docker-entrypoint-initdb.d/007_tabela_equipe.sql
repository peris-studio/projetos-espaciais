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
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Equipe Falcão', 'Lançamento de Veículos Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'bda25244-669e-4f38-9fd8-8041bcffad79', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', '84bae1d3-6463-4e05-958b-3e531038eea3'),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Equipe Atlas', 'Pesquisas Científicas Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '4c6fb5e9-8073-4bfe-8095-49c173108983', '78dd2ca2-10e1-4185-8d43-0a964fdee0af'),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Equipe Pioneira', 'Exploração de Marte', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '936800104-4b7a-4f84-b702-bdceae10bd61'),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Equipe Vanguarda', 'Tecnologia Avançada para Missões Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'a999c838-0c75-4d70-8f64-d560cac90965', 'a999c838-0c75-4d70-8f64-d560cac90965', '936694527-3a5b-4d56-b1f1-d0806fe8eaf2'),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Equipe Comando Espacial', 'Gestão de Operações Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '992569835-d99b-4e74-a40b-23f8d0c9a6a9');