CREATE TABLE public."MissaoLicencas" (
    "Id" UUID PRIMARY KEY,
    "DataCriacao" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "Ativo" BOOLEAN NOT NULL,
    "MissaoId" UUID NOT NULL,
    "LicencaId" UUID NOT NULL,
    CONSTRAINT "FK_Missoes" FOREIGN KEY ("MissaoId") REFERENCES public."Missoes"("Id"),
    CONSTRAINT "FK_Licencas" FOREIGN KEY ("LicencaId") REFERENCES public."Licencas"("Id")
);

INSERT INTO public."MissaoLicencas" ("Id", "DataCriacao", "Ativo", "MissaoId", "LicencaId")
VALUES
    ('3357c875-5fc3-4303-ad2a-765df2a3f1ac', CURRENT_TIMESTAMP, TRUE, 'c8a24d9f-8f5f-4f2f-bbe9-f4c28a7b9a26', '10a1636a-4f0a-4173-a189-a0ebf2886b5b'),
    ('448ed826-297f-453a-b949-c695962e78e1', CURRENT_TIMESTAMP, TRUE, 'd8e6f5a1-4a65-4062-9251-70f729309227', 'ef3bc37a-d3b6-49df-b4ae-9a1ed4999a05'),
    ('4bed6c9d-9c8c-44e9-a24b-cf4edabc7872', CURRENT_TIMESTAMP, TRUE, 'b4f9a5d7-3b85-4f1e-b5f0-158e21e89d60', '2d6f1c8b-1752-4e74-a42c-c5c5e7b4891b'),
    ('6588c110-c1a7-45e6-9ca1-45160c6c5816', CURRENT_TIMESTAMP, TRUE, 'c8a24d9f-8f5f-4f2f-bbe9-f4c28a7b9a26', 'e250e47c-4062-4ab0-a1cf-ed710d251e46'),
    ('2a06e17c-bbd7-40ea-95f1-af68325a66f2', CURRENT_TIMESTAMP, TRUE, '4ea65a78-cd3f-4a4c-88c1-114fe88922fe', '58725449-bb4c-40c7-a080-ec0c541489de');