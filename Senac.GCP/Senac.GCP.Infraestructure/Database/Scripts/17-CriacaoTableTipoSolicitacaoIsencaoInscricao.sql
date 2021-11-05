create table TipoSolicitacaoIsencaoInscricao(
	Id bigint not null identity(1,1),
	Codigo varchar(50) not null,
	Descricao varchar (255) not null,
	PercentualIsencaoInscricao decimal not null,
	constraint PkTipoSolicitacaoIsencaoInscricao primary key (id),
	constraint UkTipoSolicitacaoIsencaoInscricao unique (codigo)
);