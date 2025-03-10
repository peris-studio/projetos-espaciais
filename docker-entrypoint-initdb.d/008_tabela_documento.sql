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
); -- Ponto e vírgula adicionado aqui

INSERT INTO public."Documentos" ("Id", "Titulo", "TipoDocumento", "Versao", "ClassificacaoSegurancaDocumento", "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo", "EquipeId")
VALUES
    ('dd7a20dd-75a3-4b6f-999e-bbf8b91ef3c7', 'Relatório de Lançamento do Falcon 9', 1, 'v1.0', 3, CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'a96cfdd9-ce1e-41e7-9483-1691e87c8780'),
    ('9b51684b-ff3d-44fe-94e2-df82a318e903', 'Estudo de Viabilidade para Missão em Marte', 2, 'v2.1', 2, CURRENT_TIMESTAMP, NULL, NULL, TRUE, '97dbd619-ae50-4a3e-ac97-926b95f251c2'),
    ('bc426fea-045f-48af-9995-c7cb14dd9aa5', 'Plano de Pesquisa Científica para Exploração Lunar', 3, 'v1.2', 1, CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'ac1131b5-ccd1-46ef-9a07-05868e8d46a3'),
    ('f4ccce28-b3be-45e6-959e-62d8797d38bc', 'Licença Ambiental para Testes de Propulsão Espacial', 5, 'v1.0', 3, CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'ac1131b5-ccd1-46ef-9a07-05868e8d46a3');