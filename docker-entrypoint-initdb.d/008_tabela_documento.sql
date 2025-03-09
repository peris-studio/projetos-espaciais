CREATE TABLE public."Documentos" (
    "Id" UUID PRIMARY KEY,
    "Titulo" VARCHAR(255) NOT NULL,
    "TipoDocumento" INTEGER NOT NULL,
    "Versao" VARCHAR(255) NOT NULL,
    "ClassificacaoSegurancaDocumento" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "EquipeId" UUID NOT NULL,
    CONSTRAINT "FK_Equipes" FOREIGN KEY ("EquipeId") REFERENCES public."Equipes"("Id")
)

INSERT INTO public."Documentos" ("Id", "Titulo", "TipoDocumento", "Versao", "ClassificacaoSegurancaDocumento", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo", "EquipeId")
VALUES
    ('60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'Relatório de Lançamento do Falcon 9', 1, 'v1.0', 3, CURRENT_TIMESTAMP, NULL, NULL, TRUE, '60cc1b17-6bf7-4058-9c0e-7ce194d3559d'),
    ('4c6fb5e9-8073-4bfe-8095-49c173108983', 'Estudo de Viabilidade para Missão em Marte', 2, 'v2.1', 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE, '4c6fb5e9-8073-4bfe-8095-49c173108983'),
    ('f2dd29b7-8592-4166-9f09-fb57dd1cb83d', 'Plano de Pesquisa Científica para Exploração Lunar', 3, 'v1.2', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d'),
    ('a999c838-0c75-4d70-8f64-d560cac90965', 'Documento de Aprovação de Tecnologia Avançada para Missões', 4, 'v3.0', 4, CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'a999c838-0c75-4d70-8f64-d560cac90965'),
    ('257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'Licença Ambiental para Testes de Propulsão Espacial', 5, 'v1.0', 5, CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2');