create table ConcursoFasesLocaisSala (
	Id bigint not null identity(1,1),
	IdConcursosFasesLocais bigint not null,
	Descricao varchar (255) not null,
	QuantidadeDeCarteiras int not null,
	QuantidadeDeCarteirasPCD int not null,

	constraint PkConcursoFasesLocaisSala primary key (Id),
	constraint FkConcursosFasesLocaisSalaIdConcursosFasesLocais 
	foreign key (IdConcursosFasesLocais) references ConcursoFasesLocais(Id),
);