create table Inscricoes
(
	Id bigint not null identity(1,1),
	IdPessoa bigint not null,
	IdConcurso bigint not null,
	DataInscricao date not null,
	NumeroInscricao varchar(255) not null,
	Situacao int not null,
	ParticiparComoCotista varbinary(max) not null,
	MotivoRecusaInscricao text,
	DataRecusaInscricao date,

	Constraint PkInscricoes primary key (Id),
	Constraint FkInscricoesPessoa foreign key(IdPessoa) references Pessoa(Id),
	constraint FKInscricoesConcurso foreign key(IdConcurso) references Concurso(id),
	constraint UkInscricoes unique(NumeroInscricao)
);