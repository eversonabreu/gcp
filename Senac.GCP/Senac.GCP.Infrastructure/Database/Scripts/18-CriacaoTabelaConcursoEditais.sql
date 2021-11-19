create table ConcursoEditais(
	id bigint not null identity (1,1),
	DataEdital date not null,
	descricao text not null,
	IdConcurso bigint not null,
	IdArquivo bigint not null,
	constraint PkConcursoEditais primary key (id),
	constraint FkConcursoEditaisArquivo foreign key (IdArquivo) references Arquivo(id),
	constraint FkConcursoEditaisConcurso foreign key (IdConcurso) references Concurso(id),
);