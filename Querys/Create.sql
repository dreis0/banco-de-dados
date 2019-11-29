--CREATE's

--Restaurante
create table Restaurante (
	CNPJ varchar(14) primary key
	,NomeOficial varchar(100) not null
	,NomeFantasia varchar(100) not null
	,SenhaId int not null
)

--TelefonesRestaurante
create table TelefonesRestaurante (
	CNPJRestaurante varchar(14) not null
	Telefone varchar(20)
)

--RestauranteHorario
create table RestauranteHorario (
	CNPJRestaurante varchar(14) not null
	,DiaId int not null
	,Abertura time without time zone not null
	,fechamento time without time zone not null
)

--Dia
create table Dia (
	Id int generated always as identity primary key
	,Dia varchar(50)
)

--Endereços
create table EnderecoRestaurante (
	CNPJRestaurante varchar(14) not null
	,Cep varchar(8) not null
	,Complemento varchar(200)
	,Numero int not null
	,CidadeId int not null
)

--Cidade
create table Cidade (
	Id int primary key generated always as identity
	,Nome varchar(100)
	,EstadoId int not null
)

--Estado
create table Estado (
	Id int primary key generated always as identity
	,Nome varchar(100)
	,PaisId int not null
)

--Pais
create table Pais (
	Id int primary key generated always as identity
	,Nome varchar(100) not null
)

--Atendimento
create table RegiaoAtendimento (
	CNPJRestaurante varchar(14) not null
	,Descricao varchar(200) not null
	,RaioDeAtendimento int not null
)

--CategoriasRestaurante
create table CategoriasRestaurante (
	CNPJRestaurante char(14) not null
	,CategoriaId int not null
)

--Categoria
create table Categoria (
	Id int primary key generated always as identity
	,Nome varchar(50)
)


--Produto
create table Produto (
	Id int primary key generated always as identity
	,CNPJRestaurante varchar(14) not null
	,Nome vachar(30) not null
	,Descricao varchar(100)
	,Preco money not null
	,Disponivel boolean not null
)

--CategoriasProduto
create table CategoriasProduto (
	CategoriaId int not null
	,ProdutoId int not null
)

--FotoProduto
create table FotoProduto (
	ProdutoId int not null
	,Foto bytea not null
)

-- Pedido
create table Pedido (
	Id int primary key generated always as identity
	,Data date without time zone not null
	,CpfCliente varchar(11) not null
	,StatusId int not null
)
 
 -- Status
 create table Status (
 	Id int primary key generated always as identity
	 ,Status varchar(100)
 )
 
 --Entregador 
 create table Entregador(
 	Cpf varchar(11) primary key 
	 ,Nome varchar(100) not null
	 ,Veiculo varchar(50) not null
	 ,PlacaDoVeiculo varchar(8) not null
 )
 
 --Cliente
 create table Cliente (
 	cpf varchar(11) primary key
	 ,Nome varchar(50) not null
	 ,Sobrenome varchar(50) not null
	 ,Rg varchar(10) 
	 ,email varchar(100) not null
	 ,Telefone varchar(20)
	 ,SenhaId int not null
 )
 
 --Cartao
 create table Cartao (
 	Id int primary key generated always as identity
	 ,ClienteId int not null
	 ,NomeDoTitular varchar(100)
	 ,Numero char(20) not null
	 ,Codigo char(3) not null
	 ,BandeiraId int not null
	 ,TipoId int not null
 )
 