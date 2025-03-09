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

    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Equipe Falcão', 'Lançamento de Veículos Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d'),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Equipe Atlas', 'Pesquisas Científicas Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '4c6fb5e9-8073-4bfe-8095-49c173108983', '4c6fb5e9-8073-4bfe-8095-49c173108983'),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Equipe Pioneira', 'Exploração de Marte', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d'),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Equipe Vanguarda', 'Tecnologia Avançada para Missões Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'a999c838-0c75-4d70-8f64-d560cac90965', 'a999c838-0c75-4d70-8f64-d560cac90965', 'a999c838-0c75-4d70-8f64-d560cac90965'),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Equipe Comando Espacial', 'Gestão de Operações Espaciais', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2');