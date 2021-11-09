create table ConcursoFases
(
Id bigint identity(1,1) not null,
IdConcurso bigint not null,
DataInicio date not null,
DataTermino date not null,
NumeroFase int not null,
constraint PkConcursoFases primary key(Id),
constraint FkConcursoFasesConcurso foreign key(IdConcurso) references Concurso(Id),
constraint UkConcursoFases unique(NumeroFase)
);