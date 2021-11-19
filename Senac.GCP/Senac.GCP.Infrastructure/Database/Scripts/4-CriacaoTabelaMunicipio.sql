create table Municipio 
(
	Id bigint not null identity(1, 1),
	Nome Varchar(255) not null,
	CodigoIBGE int not null,
	IdEstado bigint not null,
	constraint PKMunicipio Primary Key (Id),
	constraint UkMunicipio Unique (CodigoIBGE),
	constraint FKMunicipioEstado Foreign Key (IdEstado) references Estado (Id)
);