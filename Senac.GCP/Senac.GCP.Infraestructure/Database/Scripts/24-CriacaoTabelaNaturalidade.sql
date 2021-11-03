Create Table Naturalidade
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	IdMunicipio BIGINT NOT NULL,
	Nome VARCHAR(255) NOT NULL,

	CONSTRAINT PkNaturalidade PRIMARY KEY (Id),
	CONSTRAINT FkNaturalidade FOREIGN KEY (IdMunicipio) REFERENCES Municipio(Id),
);

