-- Definindo o banco de dados a ser utilizado

USE Gufi_Manha;

-- Populando as tabelas 


INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES		('Administrador'),
			('Comum');

SELECT * FROM TipoUsuario;


INSERT INTO TipoEvento(TituloTipoEvento)
VALUES		('C#'),
			('React'),
			('SQL');

SELECT * FROM TipoEvento;


INSERT INTO Instituicao(CNPJ,NomeFantasia,Endereco)
VALUES		('03774819008189','Escola SENAI de Informática', 'Alameda Barão de Limeira 539');


SELECT * FROM Instituicao;


INSERT INTO Usuario(NomeUsuario,Email,Senha,DataCadastro,Genero,FK_TipoUsuario)
VALUES		('Administrador','adm@adm.com','adm123','2020-02-06','Não informado', 1),
			('Carla Dias','carla@gmail.com', 'carla123', '2020-02-06', 'Feminino', 2),
			('Saulo','saulo@gmail.com','saulo123','2020-02-06','Masculino', 2);


SELECT * FROM Usuario;

			
INSERT INTO Evento(NomeEvento,AcessoLivre,DataEvento,Descricao,FK_TipoEvento, FK_Instituicao)
VALUES		('Orientação a objetos','1','2020-02-07','Conceitos sobre os pilares da programação orientatda a objetos', 1, 1),
			('Ciclo de vida','0','2020-02-07','Como utilizar os ciclos de vida  com a biblioteca ReactJS', 2, 1),
			('Introdução a SQL', '1', '2020-02-07','Comandos básicos utilizando SQL Server', 3, 1 );


SELECT * FROM Evento;


INSERT INTO Presenca(Situacao,FK_Usuario,FK_Evento)
VALUES		('Confirmada', 2, 2),
			('Não confirmada', 2, 3),
			('Confirmada', 3, 1);


SELECT * FROM Presenca;


		