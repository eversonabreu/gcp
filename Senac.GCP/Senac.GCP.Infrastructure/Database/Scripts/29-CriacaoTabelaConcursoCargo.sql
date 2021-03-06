CREATE TABLE ConcursoCargo(
Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
IdCargo BIGINT NOT NULL,
IdConcurso BIGINT NOT NULL,
QuantidadeVagas INT NOT NULL,
QuantidadeVagasPCD INT NOT NULL,

CONSTRAINT FkIdCargo FOREIGN KEY(IdCargo) REFERENCES Cargo(Id),
CONSTRAINT FkIdConcurso FOREIGN KEY(IdConcurso) REFERENCES Concurso(Id)

);

create unique index IdxConcursoCargo on ConcursoCargo (IdCargo, IdConcurso);