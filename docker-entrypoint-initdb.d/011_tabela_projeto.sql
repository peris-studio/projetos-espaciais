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
    CONSTRAINT "FK_GerenteTorre" FOREIGN KEY ("GerenteTorreId") REFERENCES public."GerentesTorres"("Id"),
    CONSTRAINT "FK_Missao" FOREIGN KEY ("MissaoId") REFERENCES public."Missoes"("Id")
);

-- Tabela de Junção para o relacionamento de muitos para muitos com a Missao
CREATE TABLE public."ProjetoMissao" (
    "ProjetoId" UUID NOT NULL,
    "MissaoId" UUID NOT NULL,
    CONSTRAINT "PK_ProjetoMissao" PRIMARY KEY ("ProjetoId", "MissaoId"),
    CONSTRAINT "FK_Projeto" FOREIGN KEY ("ProjetoId") REFERENCES public."Projetos"("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Missao" FOREIGN KEY ("MissaoId") REFERENCES public."Missoes"("Id") ON DELETE CASCADE
);

-- Inserir um projeto espacial
INSERT INTO public."Projetos" (
    "Id", "Nome", "Descricao", "StatusProjeto", "DataInicio", "DataTermino", 
    "Orcamento", "FaseAtual", "GerenteTorreId", "DataCriacao", "DataAtualizacao", 
    "DataDelecao", "Ativo", "MissaoId"
) 
VALUES 
    ('d517c9a9-1b64-4b75-9f9d-740db9b85e3e', 'ProjetoExploracaoMarte', 
     'Projeto de longo prazo para exploração e possível colonização de Marte.', 
     1, '2025-01-01', '2030-12-31', 500000000.00, 1, 
     '8a599c85-23c2-4b8d-ae62-b346059a6e32', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 
     '60cc1b17-6bf7-4058-9c0e-7ce194d3559d');

-- Relacionar o projeto à missão
INSERT INTO public."ProjetoMissao" ("ProjetoId", "MissaoId")
VALUES 
    ('d517c9a9-1b64-4b75-9f9d-740db9b85e3e', '60cc1b17-6bf7-4058-9c0e-7ce194d3559d');