CREATE TABLE ClassificacaoDoenca(
	Id bigint not null IDENTITY(1,1),
	CID varchar (3) not null,
	Descricao varchar(255) not null,
	constraint PKClassificacaoDoenca primary key (Id),
	constraint UKClassificacaoDoenca unique (CID)
); 