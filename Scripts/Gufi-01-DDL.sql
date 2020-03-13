-- Criando base de dados

CREATE DATABASE Gufi_Manha;

-- Definindo o banco de dados a ser utilizado

USE Gufi_Manha;

-- Criação das tabelas

CREATE TABLE TipoUsuario(
	ID_TipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE TipoEvento(
	ID_TipoEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Instituicao(
	ID_Instituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(255) NOT NULL UNIQUE,
	Endereco VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Usuario(
	ID_Usuario INT PRIMARY KEY IDENTITY,
	NomeUsuario VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL UNIQUE,
	Senha VARCHAR(255) NOT NULL,
	DataCadastro DATETIME2 NOT NULL,
	Genero VARCHAR (255),
	FK_TipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(ID_TipoUsuario)
);

CREATE TABLE Evento (
	ID_Evento INT PRIMARY KEY IDENTITY,
	NomeEvento VARCHAR (255) NOT NULL,
	DataEvento DATETIME2 NOT NULL,
	Descricao VARCHAR (255) NOT NULL,
	AcessoLivre BIT DEFAULT (1) NOT NULL,
	FK_Instituicao INT FOREIGN KEY REFERENCES Instituicao (ID_Instituicao),
	FK_TipoEvento INT FOREIGN KEY REFERENCES TipoEvento (ID_TipoEvento)
);


CREATE TABLE Presenca (
	ID_Presenca INT PRIMARY KEY IDENTITY,
	Situacao VARCHAR (255) NOT NULL,
	FK_Usuario INT FOREIGN KEY REFERENCES Usuario (ID_Usuario),
	FK_Evento INT FOREIGN KEY REFERENCES Evento (ID_Evento)
);
