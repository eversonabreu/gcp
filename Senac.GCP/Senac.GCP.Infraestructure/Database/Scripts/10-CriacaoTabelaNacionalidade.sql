CREATE TABLE Nacionalidade(
	Id BIGINT not null IDENTITY (1, 1),
	Nome VARCHAR(255) not null,
	CONSTRAINT PkNacionalidade PRIMARY KEY (Id)
);