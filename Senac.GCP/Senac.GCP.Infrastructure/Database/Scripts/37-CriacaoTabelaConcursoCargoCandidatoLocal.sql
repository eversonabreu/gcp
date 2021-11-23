create table ConcursoCargoCandidatoLocal
(
Id bigint not null identity (1,1),
IdInscricao bigint not null,
IdConcursoFasesLocais bigint not null,
constraint PKConcursoCargoCandidatoLocal primary key (Id),
constraint FKConcursoCargoCandidatoLocalInscricao foreign key(IdInscricao) references Inscricao (Id),
constraint FKConcursoCargoCandidatoLocalConcursoFasesLocais foreign key(IdConcursoFasesLocais) references ConcursoFasesLocais (Id)
);
