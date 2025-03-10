CREATE TABLE public."Testes" (
    "Id" UUID PRIMARY KEY,
    "TipoTeste" INTEGER NOT NULL,
    "Objetivo" VARCHAR(255) NOT NULL,
    "DataRealizacao" DATE NOT NULL,
    "Resultado" TEXT NOT NULL,
    "EquipamentoUtilizado" TEXT NOT NULL,
    "ConclusaoRecomendacao" TEXT NOT NULL,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DataAtualizacao" TIMESTAMP,
    "DataDelecao" TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "LocalidadeId" UUID NOT NULL,
    "EquipeId" UUID NOT NULL,
    "PlataformaId" UUID NOT NULL,
    CONSTRAINT "FK_Localidades" FOREIGN KEY ("LocalidadeId") REFERENCES public."Localidades"("Id"),
    CONSTRAINT "FK_Equipes" FOREIGN KEY ("EquipeId") REFERENCES public."Equipes"("Id"),
    CONSTRAINT "FK_Plataformas" FOREIGN KEY ("PlataformaId") REFERENCES public."Plataformas"("Id")
);

INSERT INTO public."Testes" (
    "Id", "TipoTeste", "Objetivo", "DataRealizacao", "Resultado", 
    "EquipamentoUtilizado", "ConclusaoRecomendacao", 
    "DataCriacao", "DataAtualizacao", "DataDelecao", "Ativo", 
    "LocalidadeId", "EquipeId", "PlataformaId"
)
VALUES
    ('1a19caf6-a340-4f87-b185-38d9fa011826', 9, 'Teste de Lançamento de Veículo Espacial', '2025-04-12', 'Sucesso. A nave atingiu a órbita esperada.', 'Sistema de Propulsão Falcon 9, Sensores de Navegação', 'Recomenda-se aprimorar os sensores de comunicação para maior confiabilidade.', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '60cc1b17-6bf7-4058-9c0e-7ce194d3559d', 'a96cfdd9-ce1e-41e7-9483-1691e87c8780', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d'),
    ('65655f2f-e520-4a6b-9319-90f8ad8f679a', 10, 'Teste de Resistência Térmica para Reentrada Atmosférica', '2025-05-03', 'Falha parcial. A estrutura manteve-se íntegra, mas o sistema de resfriamento falhou.', 'Placa de Revestimento Térmico, Sistema de Resfriamento', 'Recomenda-se revisar o projeto do sistema de resfriamento para melhorar a eficiência térmica.', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '4c6fb5e9-8073-4bfe-8095-49c173108983', 'a96cfdd9-ce1e-41e7-9483-1691e87c8780', 'a999c838-0c75-4d70-8f64-d560cac90965'),
    ('1127a66b-6c87-4897-9dfb-d85bfc7d1806', 11, 'Teste de Comunicação entre Satélites', '2025-06-15', 'Sucesso. Comunicação estabelecida entre os satélites em órbita.', 'Antenas de Comunicação, Sistema de Transmissão de Dados', 'Recomenda-se aumentar a redundância do sistema para garantir maior confiabilidade nas transmissões.', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', '97dbd619-ae50-4a3e-ac97-926b95f251c2', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d'),
    ('0e546209-cc14-4fe6-ad61-5329825048a5', 7, 'Teste de Propulsão Iônica para Viagens Interplanetárias', '2025-07-22', 'Sucesso. O sistema de propulsão manteve a aceleração planejada.', 'Motor Iônico, Sensores de Monitoramento de Velocidade', 'Recomenda-se aumentar a capacidade de combustível do sistema para maior alcance.', CURRENT_TIMESTAMP, NULL, NULL, TRUE, 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d', '97dbd619-ae50-4a3e-ac97-926b95f251c2', '257c9a52-f4b7-4e29-af5e-7406ff11c6e2'),
    ('8f454a99-8ee6-4362-bddb-49cbc691ab6f', 10, 'Teste de Estrutura para Despressurização Espacial', '2025-08-10', 'Sucesso. A estrutura resistiu à despressurização sem falhas significativas.', 'Estrutura de Cabine, Equipamento de Despressurização', 'Nenhuma recomendação, o sistema foi considerado robusto o suficiente.', CURRENT_TIMESTAMP, NULL, NULL, TRUE, '257c9a52-f4b7-4e29-af5e-7406ff11c6e2', 'ac1131b5-ccd1-46ef-9a07-05868e8d46a3', 'f2dd29b7-8592-4166-9f09-fb57dd1cb83d');