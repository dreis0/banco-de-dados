create table Restaurante (
	CNPJ 			char(14) 		primary key
	,NomeOficial 	varchar(100) 	not null
	,NomeFantasia 	varchar(100) 	not null
	,Cep 			varchar(8) 		not null
	,Complemento 	varchar(200)
	,Numero 		int 			not null
	,CidadeId 		int 			not null
);

--TelefonesRestaurante
create table TelefonesRestaurante (
	CNPJRestaurante char(14) not null
	,Telefone 		varchar(20)
	,foreign key (CNPJRestaurante) references Restaurante(CNPJ) 
);

--RestauranteHorario
create table RestauranteHorario (
	CNPJRestaurante char(14) 				not null
	,DiaId 			int 					not null 
	,Abertura 		time without time zone 	not null
	,fechamento 	time without time zone 	not null
	,Primary key(CNPJRestaurante,DiaId) 
	,foreign key (CNPJRestaurante) references Restaurante(CNPJ) 
);

--Dia 
create table Dia (
	Id 		int generated always as identity primary key
	,Dia 	varchar(50)
);

--Cidade
create table Cidade (
	Id 			int 			primary key generated always as identity
	,Nome 		varchar(100) 	not null
	,EstadoId 	int 			not null
);

--Estado
create table Estado (
	Id 		int 			primary key generated always as identity
	,Nome 	varchar(100) 	not null
	,PaisId int 			not null
);

--Pais
create table Pais (
	Id 		int primary key generated always as identity
	,Nome 	varchar(100) not null
);

--Atendimento
create table RegiaoAtendimento (
	CNPJRestaurante 	char(14) 		not null
	,Descricao 			varchar(200)	not null
	,RaioDeAtendimento 	int			 	not null
	,foreign key (CNPJRestaurante) references Restaurante(CNPJ)
);

--Categoria
create table Categoria (
	Id 		int 		primary key generated always as identity
	,Nome 	varchar(50) not null 
);

--CategoriasRestaurante
create table CategoriasRestaurante (
	CNPJRestaurante char(14) 	not null
	,CategoriaId 	int 		not null
	,Primary key(CNPJRestaurante, CategoriaId) 
	,foreign key (CNPJRestaurante) 	references Restaurante(CNPJ) 
	,foreign key (CategoriaId) 		references Categoria(Id) 
);

--Produto
create table Produto (
	Id int primary key generated always as identity 
	,CNPJRestaurante char(14) 	not null
	,Nome 			varchar(30) not null
	,Descricao 		varchar(100)
	,Preco 			money 		not null
	,Disponivel 	boolean 	not null
	,primary key(CNPJRestaurante,ProdutoId)  
	,foreign key (CNPJRestaurante) references Restaurante(CNPJ) 
);

--CategoriasProduto
create table CategoriasProduto (
	CategoriaId int not null
	,ProdutoId 	int not null
	,foreign key (CategoriaId) references Categoria(Id)
);

--FotoProduto
create table FotoProduto (
	ProdutoId 		int 		not null
	,Foto 			bytea 		not null
	,foreign key (ProdutoId) 	references Produto(Id) 
);

 --Entregador 
 create table Entregador(
 	Cpf varchar(11) 			primary key 
	 ,Nome varchar(100) 		not null
	 ,Veiculo varchar(50) 		not null
	 ,PlacaDoVeiculo varchar(8) not null
 );
 
 --Cliente
 create table Cliente (
 	Cpf char(11) 		primary key
	 ,Nome varchar(50) 		not null
	 ,Sobrenome varchar(50) not null
	 ,Rg varchar(10) 
	 ,email varchar(100) 	not null
	 ,Telefone varchar(20)
 );
 
 
-- Status 
 create table Status (
 	Id int primary key generated always as identity
	 ,Status varchar(100)
 );
 
 
-- Pedido
create table Pedido (
	Id 				int 		primary key generated always as identity
	,Data 			date 		not null
	,CpfCliente 	varchar(11) not null
	,CpfEntregador  varchar(11) not null
	,StatusId 		int 		not null
	,foreign key (CpfCliente) 		references Cliente(Cpf)
	,foreign key (CpfEntregador) 	references Entregador(Cpf) 
	,foreign key (StatusId) 		references Status(id)
);
 
 create table ProdutosPedido(
	ProdutoId int not null
	,PedidoId int not null
	,Quantidade int not null
	,foreign key (ProdutoId)		references Produto(Id)
	,foreign key ()		references Pedido(Id)
 );
 
  --Bandeira Cartao
 create table CartaoBandeira (
 	BandeiraId	 	int 		primary key
	,bandeira 		varchar(50) not null
 );
 --Tipo Cartao
 create table CartaoTipo (
 	TipoId 		int 		primary key
	,tipo 	 	varchar(50) not null
 );

 --Cartao
 create table Cartao (
 	Id int primary key generated always as identity
	 ,CpfCliente 	varchar(11) not null
	 ,NomeDoTitular varchar(100) not null
	 ,Numero 		char(20) 	not null
	 ,Codigo 		char(3) 	not null
	 ,BandeiraId 	int			not null
	 ,TipoId 		int 		not null
	 ,foreign key (CpfCliente) 	references  Cliente (Cpf)
	 ,foreign key (BandeiraId) 	references  CartaoBandeira (BandeiraId)
	 ,foreign key (TipoId) 		references  CartaoTipo (TipoId)
 );
