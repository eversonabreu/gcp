Create Table SolicitacaoIsencaoInscricao
(
	Id BIGINT NOT NULL IDENTITY(1, 1),
	IdInscricao BIGINT NOT NULL,
	DataSolicitacao DATETIME NOT NULL,
	SituacaoSolicitacao INT NOT NULL,
	IdTipoSolicitacaoIsencaoInscricao bigint NOT NULL,
	DataRespostaSolicitacao datetime,
	MotivoRecusaSolicitacaoIsencaoInscricao text,
	CONSTRAINT PkSolicitacaoIsencaoInscricao PRIMARY KEY (Id),
	CONSTRAINT FkSolicitacaoIsencaoInscricaoIdInscricao FOREIGN KEY (IdInscricao) REFERENCES Inscricao(Id),
	CONSTRAINT UKSolicitacaoIsencaoInscricaoIdInscricao UNIQUE (IdInscricao),
	Constraint FkDocumentosSolicitacaoIsencaoInscricaoIdTipoSolicitacaoIsencaoInscricao foreign key (IdTipoSolicitacaoIsencaoInscricao) references TipoSolicitacaoIsencaoInscricao(Id)
);