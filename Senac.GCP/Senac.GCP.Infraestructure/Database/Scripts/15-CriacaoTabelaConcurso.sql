CREATE TABLE Concurso(
	Id BIGINT NOT NULL IDENTITY (1,1),
	Codigo INT NOT NULL,
	Descricao VARCHAR(255) NOT NULL,
	DataInicioInscricao DATE NOT NULL,
	DataFinalInscicao DATE NOT NULL,
	IdInstituicaoSolicitante BIGINT NOT NULL,
	IdInstituicaoOrganizadora BIGINT NOT NULL,
	PrazoFinalIsencaoValorInscricao DATE NOT NULL,
	ValorInscricao DECIMAL NOT NULL,
	QuantidadeVagas INT NOT NULL,
	PercentualQuantidadeVagasAmplaConcorrencia INT NOT NULL,
	Ativo BIT NOT NULL,
	Observacoes TEXT,
	CONSTRAINT PkConcurso PRIMARY KEY (Id),
	CONSTRAINT UkConcurso UNIQUE (Codigo),
	CONSTRAINT FkInstituicaoSolicitante FOREIGN KEY (IdInstituicaoSolicitante) REFERENCES Instituicao (Id),
	CONSTRAINT FkInstituicaoOrganizadora FOREIGN KEY (IdInstituicaoSolicitante) REFERENCES Instituicao (Id)
);