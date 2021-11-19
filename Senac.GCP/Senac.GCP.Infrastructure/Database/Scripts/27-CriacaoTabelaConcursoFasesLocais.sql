CREATE TABLE ConcursoFasesLocais(
Id BIGINT NOT NULL IDENTITY (1, 1),
IdConcursoFases BIGINT NOT NULL,
NomeLocal VARCHAR(255) NOT NULL,
EnderecoRua VARCHAR (150) NOT NULL,
EnderecoNumero VARCHAR (20),
EnderecoBairro VARCHAR (150) NOT NULL,
EnderecoComplemento VARCHAR (150),
EnderecoCEP VARCHAR (10) NOT NULL,
IdMunicipioEndereco BIGINT NOT NULL,
Telefone VARCHAR (11),
Email VARCHAR (255),

CONSTRAINT PKConcursoFasesLocais PRIMARY KEY (Id),
CONSTRAINT FKConcursoFasesLocaisIdConcursoFases FOREIGN KEY (IdConcursoFases) REFERENCES ConcursoFases(Id),
CONSTRAINT UKConcursoFasesLocaisIdConcursoFases UNIQUE (IdConcursoFases),
CONSTRAINT FKConcursoFasesLocaisIdMunicipioEndereco FOREIGN KEY (IdMunicipioEndereco) REFERENCES Municipio(Id)
);