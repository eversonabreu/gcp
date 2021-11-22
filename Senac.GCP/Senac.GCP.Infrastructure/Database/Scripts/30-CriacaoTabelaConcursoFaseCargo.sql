CREATE TABLE ConcursoFaseCargo(
Id bigint IDENTITY (1,1) NOT NULL,
IdCargo bigint NOT NULL,
IdConcursoCargo bigint NOT NULL,

CONSTRAINT Pk_ConcursoFaseCargo PRIMARY KEY (Id),
CONSTRAINT Fk_ConcursoFaseCargoIdCargo FOREIGN KEY (IdCargo) REFERENCES Cargo(Id),
CONSTRAINT Fk_ConcursoFaseCargoIdConcursoCargo FOREIGN KEY (IdConcursoCargo) REFERENCES ConcursoCargo(Id),
CONSTRAINT UkConcursoCargo UNIQUE (IdConcursoCargo),
CONSTRAINT UkCargo UNIQUE (IdCargo),
);
