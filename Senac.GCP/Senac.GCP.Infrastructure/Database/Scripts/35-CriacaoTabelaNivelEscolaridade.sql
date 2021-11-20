create table NivelEscolaridade(
Id bigint identity (1, 1) not null,
Sigla varchar(10) not null,
Descricao text,
constraint PkNivelEscolaridade primary key(Id),
constraint UkSigla unique (Sigla),
);