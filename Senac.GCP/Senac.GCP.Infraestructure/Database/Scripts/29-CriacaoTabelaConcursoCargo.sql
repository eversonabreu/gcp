CREATE TABLE ConcursoCargo(
Id BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
IdCargo BIGINT NOT NULL FOREIGN KEY REFERENCES Cargo(Id),
IdConcurso BIGINT NOT NULL FOREIGN KEY REFERENCES Concurso(Id),
QuantidadeVagas INT NOT NULL,
QuantidadeVagasPCD INT NOT NULL
);