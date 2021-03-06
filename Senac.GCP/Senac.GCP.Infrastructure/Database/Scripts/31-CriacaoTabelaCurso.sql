
create table Curso
(
Id bigint not null identity(1,1),
IdNivelEscolaridade bigint not null,
Codigo int not null,
Descricao text not null,
constraint PKCurso primary key (Id)
);
alter table Curso
add constraint FkCursoNivelEscolaridade foreign key (IdNivelEscolaridade) references NivelEscolaridade(id);
create unique index UkCursoNivelEscolaridade on Curso (Codigo);