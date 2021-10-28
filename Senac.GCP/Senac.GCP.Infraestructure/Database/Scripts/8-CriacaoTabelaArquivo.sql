CREATE TABLE Arquivo(
	Id BIGINT NOT NULL IDENTITY (1,1),
	Nome varchar (255) not null,
	Extensao varchar (30) not null,
	Conteudo varbinary (max) not null,
	DataUpload datetime not null,
	CONSTRAINT PkArquivo PRIMARY KEY (Id)
);
