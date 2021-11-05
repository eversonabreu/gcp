create table Inscricao
(
	Id bigint not null identity(1,1),
	IdPessoa bigint not null,
	IdConcurso bigint not null,
	DataInscricao date not null,
	NumeroInscricao int not null,
	Situacao int not null,
	ParticiparComoCotista varbinary(max) not null,
	MotivoRecusaInscricao text,
	DataRecusaInscricao date,

	Constraint PkInscricao primary key (Id),
	Constraint FkInscricaoPessoa foreign key(IdPessoa) references Pessoa(Id),
	constraint FKInscricaoConcurso foreign key(IdConcurso) references Concurso(id),
	constraint UkInscricao unique(NumeroInscricao)
);

create unique index IdxInscricao on Inscricao (IdPessoa, IdConcurso);