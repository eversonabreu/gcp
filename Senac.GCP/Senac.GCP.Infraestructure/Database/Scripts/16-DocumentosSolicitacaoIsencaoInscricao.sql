Create Table DocumentosSolicitacaoIsencaoInscricao
(
Id bigint NOT NULL identity(1,1),
IdSolicitacaoIsencaoInscricao BIGINT NOT NULL,
IdArquivo bigint NOT NULL,
IdTipoSolicitacaoIsencaoInscricao bigint NOT NULL,
constraint PkDocumentosSolicitacaoIsencaoInscricao primary key (Id),
constraint FkDocumentosSolicitacaoIsencaoInscricaoIdSolicitacaoIsencaoInscricao foreign key (Id) references SolicitacaoIsencaoInscricao(Id),
constraint FkDocumentosSolicitacaoIsencaoInscricaoIdArquivo foreign key (Id) references Arquivo(Id),
constraint FkDocumentosSolicitacaoIsencaoInscricaoIdTipoSolicitacaoIsencaoInscricao foreign key (Id) references TipoSolicitacaoIsencaoInscricao(Id)
);