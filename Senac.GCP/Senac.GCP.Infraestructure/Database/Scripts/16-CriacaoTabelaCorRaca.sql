create table CorRaca (
	id bigint not null identity(1,1),
	codigo varchar(50) not null,
	descricao varchar (255) not null,
	constraint PkCorRaca primary key (id),
	constraint UkCorRaca unique (codigo)
);