CREATE TABLE Cargo(
Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
Descricao VARCHAR(255) NOT NULL,
IdNivelEscolaridade BIGINT not null,
Codigo INT NOT NULL,

CONSTRAINT FKNivelEscolaridadeCargo FOREIGN KEY(IdNivelEscolaridade) REFERENCES NivelEscolaridade(id),
CONSTRAINT UniqCodigo UNIQUE(Codigo)
);