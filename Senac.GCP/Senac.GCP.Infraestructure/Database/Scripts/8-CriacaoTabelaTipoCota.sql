create table TipoCota(
Id bigint not null identity(1,1),
Codigo varchar(50) not null,
Descricao varchar(255) not null,
constraint PkTipoCota primary key(Id),
constraint UkCodigo unique(Codigo)
);