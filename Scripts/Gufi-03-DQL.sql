-- DQL 

USE Gufi_Manha;

-- Listar todos os usuários cadastrados 

SELECT ID_Usuario,NomeUsuario, Email,Senha, DataCadastro, Genero, TipoUsuario.TituloTipoUsuario FROM Usuario
INNER JOIN TipoUsuario ON Usuario.FK_TipoUsuario = TipoUsuario.ID_TipoUsuario;

-- Listar todas as instituições cadasradas

SELECT CNPJ, NomeFantasia, Endereco FROM Instituicao;

-- Listar todos os tipos de eventos

SELECT TituloTipoEvento FROM TipoEvento;

-- Listar todos os eventos

SELECT NomeEvento, TipoEvento.TituloTipoEvento, DataEvento,Descricao,AcessoLivre, Instituicao.NomeFantasia, Instituicao.CNPJ, Instituicao.Endereco FROM Evento
INNER JOIN Instituicao ON Evento.FK_Instituicao = Instituicao.ID_Instituicao
INNER JOIN TipoEvento ON Evento.FK_TipoEvento = TipoEvento.ID_TipoEvento

-- Listar Apenas eventos que são públicos

SELECT NomeEvento, TipoEvento.TituloTipoEvento, DataEvento,Descricao,AcessoLivre, Instituicao.NomeFantasia, Instituicao.CNPJ, Instituicao.Endereco FROM Evento
INNER JOIN Instituicao ON Evento.FK_Instituicao = Instituicao.ID_Instituicao
INNER JOIN TipoEvento ON Evento.FK_TipoEvento = TipoEvento.ID_TipoEvento
WHERE AcessoLivre = 1

-- Listar todos os eventos que um determinado usuario participa 

--CREATE VIEW vwEventoUsuario 
--SELECT Usuario 






SELECT Situacao, Usuario.NomeUsuario, Usuario.Email, Usuario.Genero, Usuario.DataCadastro, TipoUsuario.TituloTipoUsuario, Evento.NomeEvento, Evento.Descricao, Evento.AcessoLivre, TipoEvento.TituloTipoEvento, Instituicao.NomeFantasia, Instituicao.Endereco, Instituicao.CNPJ, Evento.DataEvento FROM Presenca
INNER JOIN Usuario ON Presenca.FK_Evento = Usuario.ID_Usuario
INNER JOIN Evento ON Presenca.FK_Evento = Evento.ID_Evento
INNER JOIN Instituicao ON Evento.FK_Instituicao = Instituicao.ID_Instituicao
INNER JOIN TipoEvento ON Evento.ID_Evento = TipoEvento.ID_TipoEvento
INNER JOIN TipoUsuario ON Usuario.FK_TipoUsuario = TipoUsuario.ID_TipoUsuario
WHERE ID_Usuario = 2
 