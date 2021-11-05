Create Table DocumentosSolicitacaoIsencaoInscricao
(
	Id bigint NOT NULL identity(1,1),
	IdSolicitacaoIsencaoInscricao BIGINT NOT NULL,
	IdArquivo bigint NOT NULL,
	IdTipoSolicitacaoIsencaoInscricao bigint NOT NULL,
	Constraint PkDocumentosSolicitacaoIsencaoInscricao primary key (Id),
	Constraint FkDocumentosSolicitacaoIsencaoInscricaoIdSolicitacaoIsencaoInscricao foreign key (IdSolicitacaoIsencaoInscricao) references SolicitacaoIsencaoInscricao(Id),
	Constraint FkDocumentosSolicitacaoIsencaoInscricaoIdArquivo foreign key (IdArquivo) references Arquivo(Id),
	Constraint FkDocumentosSolicitacaoIsencaoInscricaoIdTipoSolicitacaoIsencaoInscricao foreign key (IdTipoSolicitacaoIsencaoInscricao) references TipoSolicitacaoIsencaoInscricao(Id)
);