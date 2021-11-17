create table Inscricao
(
	Id bigint not null identity(1,1),
	IdPessoa bigint not null,
	IdConcursoCargo bigint NOT NULL,
	DataInscricao datetime2 not null,
	NumeroInscricao varchar(20) not null,
	Situacao int not null,
	ParticiparComoCotista bit not null,
	MotivoRecusaInscricao text,
	DataRecusaInscricao datetime2,
    ValorPago decimal(18,2) null,
    DataPagamento datetime2 null,
    TipoPagamento INT null

	Constraint PkInscricao primary key (Id),
	Constraint FkInscricaoPessoa foreign key(IdPessoa) references Pessoa(Id),
	Constraint FKConcursoCargoInscricao foreign key(IdConcursoCargo)  references ConcursoCargo(id),
	constraint UkInscricao unique(NumeroInscricao)
);