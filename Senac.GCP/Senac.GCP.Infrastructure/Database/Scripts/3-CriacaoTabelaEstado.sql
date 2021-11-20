create table Estado
(
Id bigint not null identity(1,1),
Nome varchar(255) not null,
SiglaUF varchar(2) not null,
constraint PkEstado primary key (Id),
constraint UkEstado unique (SiglaUF)
);