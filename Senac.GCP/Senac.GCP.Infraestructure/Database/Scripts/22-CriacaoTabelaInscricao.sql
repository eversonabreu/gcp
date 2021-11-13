create table Inscricao
(
	Id bigint not null identity(1,1),
	IdPessoa bigint not null,
	IdConcursoCargo bigint NOT NULL,
	DataInscricao date not null,
	NumeroInscricao varchar(50) not null,
	Situacao int not null,
	ParticiparComoCotista bit not null,
	MotivoRecusaInscricao text,
	DataRecusaInscricao date,
    ValorPago Decimal(18,2) null,
    DataPagamento Datetime null,
    TipoPagamento INT null

	Constraint PkInscricao primary key (Id),
	Constraint FkInscricaoPessoa foreign key(IdPessoa) references Pessoa(Id),
	Constraint FKConcursoCargoInscricao foreign key(IdConcursoCargo)  references ConcursoCargo (id),
	constraint UkInscricao unique(NumeroInscricao)
);