CREATE table IntegrantesComissaoOrganizacao
(
	Id bigint not null identity(1, 1),
	IdConcurso bigint not null , 
	IdUsuario bigint not null ,
	constraint PKIntegrantesComissaoOrganizacao Primary Key (Id),
	constraint FKIntegrantesComissaoOrganizacaoConcurso Foreign Key (IdConcurso) references Concurso (Id),
	constraint FKIntegrantesComissaoOrganizacaoUsuario Foreign Key (IdUsuario) references Usuario (Id)
);