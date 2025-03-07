CREATE TABLE public."Veiculos" (
    "Id" UUID PRIMARY KEY,
    "Nome" VARCHAR(20),
    "Placa" VARCHAR(255) NOT NULL,
    "Marca" INTEGER NOT NULL,
    "Modelo" VARCHAR(255) NOT NULL,
    "Ano" INTEGER NOT NULL,
    "Cor" VARCHAR(255) NOT NULL,
    "TipoVeiculo" INTEGER NOT NULL,
    "TipoCombustivel" INTEGER NOT NULL,
    "TipoTransmissao" INTEGER NOT NULL,
    "Capacidade" VARCHAR(255) NOT NULL,
    "EspecificacaoTecnicaExtra" TEXT,
    "StatusVeiculo" INTEGER NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL
);