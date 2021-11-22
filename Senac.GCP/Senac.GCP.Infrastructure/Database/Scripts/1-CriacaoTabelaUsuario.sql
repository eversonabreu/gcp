create table Usuario
(
  Id bigint not null identity (1, 1),
  Nome varchar(255) not null,
  Email varchar(255) not null,
  CPF varchar(11) not null,
  Senha text not null,
  DataCadastramento datetime not null,
  Administrador bit not null,
  Ativo bit not null,
  constraint PkUsuario primary key (Id),
  constraint UkUsuarioEmail unique (Email),
  constraint UkUsuarioCPF unique (CPF)
);