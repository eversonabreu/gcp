create table TipoSolicitacaoIsencaoInscricao(
	id bigint not null identity(1,1),
	codigo varchar(50) not null,
	descricao varchar (255) not null,
	constraint PkTipoSolicitacaoIsencaoInscricao primary key (id),
	constraint UkTipoSolicitacaoIsencaoInscricao unique (codigo)
);