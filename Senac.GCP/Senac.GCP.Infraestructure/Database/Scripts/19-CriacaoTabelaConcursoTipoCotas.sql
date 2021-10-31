create table ConcursoTipoCotas
(
Id bigint not null identity(1,1),
IdConcurso bigint not null,
IdTipoCota bigint not null,
PercentualVagas int,
constraint PkConcursoTipoCotas primary key(Id),
constraint FkConcursoTipoCotasConcurso foreign key(IdConcurso) references Concurso(Id),
constraint FkConcursoTipoCotasTipoConta foreign key(IdTipoCota) references TipoCota(Id)
);