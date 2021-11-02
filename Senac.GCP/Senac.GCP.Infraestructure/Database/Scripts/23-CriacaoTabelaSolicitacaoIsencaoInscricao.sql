Create Table SolicitacaoIsencaoInscricao
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	IdInscricoes BIGINT NOT NULL,
	DataSolicitacao DATETIME NOT NULL,
	SituacaoSolicitacao INT NOT NULL,

	CONSTRAINT PkSolicitacaoIsencaoInscricao PRIMARY KEY (Id),
	CONSTRAINT FkSolicitacaoIsencaoInscricaoIdInscricao FOREIGN KEY (IdInscricoes) REFERENCES Inscricoes(Id),
	CONSTRAINT UKSolicitacaoIsencaoInscricaoIdInscricao UNIQUE (IdInscricoes)
);

