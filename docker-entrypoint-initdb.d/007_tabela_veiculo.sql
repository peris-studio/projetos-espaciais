CREATE TABLE public."Veiculos" (
    "Id" UUID PRIMARY KEY,
    "Placa" VARCHAR(255) NOT NULL,
    "Marca" INTEGER NOT NULL,
    "Modelo" VARCHAR(255) NOT NULL,
    "Ano" INTEGER NOT NULL,
    "Cor" VARCHAR(255) NOT NULL,
    "TipoVeiculo" INTEGER NOT NULL,
    "TipoCombustivel" INTEGER NOT NULL,
    "TipoTransmissao" INTEGER NOT NULL,
    "EspecificacaoTecnicaExtra" TEXT,
    "Status" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);