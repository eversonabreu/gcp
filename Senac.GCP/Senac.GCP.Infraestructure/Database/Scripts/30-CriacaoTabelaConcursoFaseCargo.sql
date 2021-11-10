CREATE TABLE ConcursoFaseCargo(
Id bigint IDENTITY (1,1) NOT NULL,
IdConcursoCargo bigint NOT NULL,
IdConcursoFases bigint NOT NULL,
CONSTRAINT Pk_ConcursoFaseCargo PRIMARY KEY (Id),
CONSTRAINT Fk_ConcursoCargo FOREIGN KEY (IdConcursoCargo) REFERENCES ConcursoCargo(Id),
CONSTRAINT Fk_ConcursoFases FOREIGN KEY (IdConcursoFases) REFERENCES ConcursoFases(Id),
CONSTRAINT UkConcursoFasesCargo UNIQUE (IdConcursoCargo, IdConcursoFases)
);
