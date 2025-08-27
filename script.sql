-- 	CRIANDO O BANCO DE DADOS
CREATE DATABASE BDPizzaria1;

-- USANDO BANCO DE DADOS
USE BDPizzaria;
-- CRIANDO AS TABELAS DO BANCO DE DADOS
CREATE TABLE tbPedido(
	codPedido int primary key auto_increment,
    tipoPizza varchar(50),
    valorPizza varchar(50),
    valorOpcao varchar(50),
    valorTotal varchar(50)
);

-- CONSULTANDO BANCO DE DADOS

SELECT * FROM tbPedido;