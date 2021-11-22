CREATE TABLE Pessoa (
	Id BIGINT NOT NULL IDENTITY(1, 1),
	IdNivelEscolaridade BIGINT NOT NULL,
	IdArquivoFoto BIGINT NOT NULL,
	IdNacionalidade BIGINT NOT NULL,
	IdClassificacaoDoenca BIGINT,
	IdCorRaca BIGINT NOT NULL,
	IdMunicipioNaturalidade BIGINT,
	IdMunicipioEndereco BIGINT NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	DataNascimento DATE NOT NULL,
	CPF VARCHAR(11) NOT NULL,
	RG VARCHAR(10) NOT NULL,
	DataEmissaoRG DATE NOT NULL,
	OrgaoEmissorRG VARCHAR(255) NOT NULL,
	Genero VARCHAR(1) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Telefone VARCHAR(11) NOT NULL,
	PCD BIT NOT NULL,
	EnderecoRua VARCHAR (150) NOT NULL,
	EnderecoNumero VARCHAR (20) NOT NULL,
	EnderecoBairro VARCHAR (150) NOT NULL,
	EnderecoComplemento VARCHAR (150),
	EnderecoCEP VARCHAR (10) NOT NULL,
	Bloqueado BIT NOT NULL,
	MotivoBloqueio TEXT,
	DataBloqueio DATETIME2,
	ChaveAcesso TEXT NOT NULL,
 
	CONSTRAINT PKPessoa PRIMARY KEY (Id),
	CONSTRAINT UKPessoaCPF UNIQUE (CPF),
	CONSTRAINT UKPessoaEmail UNIQUE (Email),
	CONSTRAINT FKPessoaIdNacionalidade FOREIGN KEY (IdNacionalidade) REFERENCES Nacionalidade(Id),
	CONSTRAINT FKPessoaIdClassificacaoDoenca FOREIGN KEY (IdClassificacaoDoenca) REFERENCES ClassificacaoDoenca(Id),
	CONSTRAINT FKPessoaIdCorRaca FOREIGN KEY (IdCorRaca) REFERENCES CorRaca(Id),
	CONSTRAINT FKPessoaIdMunicipioEndereco FOREIGN KEY (IdMunicipioEndereco) REFERENCES Municipio(Id),
	CONSTRAINT FKPessoaIdArquivoFoto FOREIGN KEY (IdArquivoFoto) REFERENCES Arquivo(Id),
	CONSTRAINT FKPessoaIdMunicipioNaturalidade FOREIGN KEY (IdMunicipioNaturalidade) REFERENCES Municipio(Id)
);

ALTER TABLE Pessoa
ADD CONSTRAINT FkPessoaIdNivelEscolaridade FOREIGN KEY (IdNivelEscolaridade) REFERENCES NivelEscolaridade(id);

