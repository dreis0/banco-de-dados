create table Restaurante (
	CNPJ 			char(14) 		primary key
	,NomeOficial 	varchar(100) 	not null
	,NomeFantasia 	varchar(100) 	not null
	,Cep 			varchar(8) 		not null
	,Rua 			varchar(100) 	not null
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

ALTER DOMAIN public.dia
    ADD CONSTRAINT dia_check CHECK (VALUE > 0 AND VALUE < 8)

--RestauranteHorario
CREATE TABLE restaurante_horarionormal
(
    cnpjrestaurante 	character(14) 			NOT NULL,
    dia 				dia	 					NOT NULL,
    abertura 			time without time zone 	NOT NULL,
    fechamento 			time without time zone 	NOT NULL,
    PRIMARY KEY (cnpjrestaurante, dia),
    FOREIGN KEY (cnpjrestaurante) references Restaurante(Cnpj)
)

CREATE TABLE restaurante_horarioespecial
(
	cnpjrestaurante 	character(14) 			NOT NULL,
    diaespecial 		date 					NOT NULL,
    abertura 			time without time zone 	NOT NULL,
    fechamento time without time zone	 		NOT NULL,
    PRIMARY KEY (cnpjrestaurante, diaespecial),
    FOREIGN KEY (cnpjrestaurante) references Restaurante(cnpj)
)

--Cidade
create table Cidade (
	Id 			int 			primary key generated always as identity
	,Nome 		varchar(100) 	not null
	,EstadoId 	int 			not null
	,foreign key (EstadoId) references Estado (Id)
);

--Estado
create table Estado (
	Id 		int 			primary key generated always as identity
	,Nome 	varchar(100) 	not null
	,PaisId int 			not null
	,foreign key(PaisId) references Pais(Id)
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
	,foreign key (CNPJRestaurante) references Restaurante(CNPJ) 
);

--CategoriasProduto
create table CategoriasProduto (
	CategoriaId int not null
	,ProdutoId 	int not null
	,primary key (CategoriaId, ProdutoId)
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
 create table StatusPedido (
 	Id int primary key generated always as identity
	 ,Status varchar(100) not null
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
	,foreign key (ProdutoId)	references Produto(Id)
	,foreign key (PedidoId)		references Pedido(Id)
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

create table EnderecoCliente (
	Id int primary key generated always as identity
	,CpfCliente 	char(11) 		not null
	,CidadeId 		int 			not null
	,Rua 			varchar(100) 	not null
	,Cep 			char(8) 		not null
	,Complemento 	varchar(200) 	
	,Numero 		int 			not null
	,foreign key (CidadeId) references Cidade(Id)
);

create table Avaliacao (
	CpfCliente 			char(11) 		not null
	,CnpjRestaurante 	char(14) 		not null
	,Nota 				int 			not null
	,Comentario			varchar(1000) 	not null
	,primary key(CpfCliente, CnpjRestaurante)
	,foreign key (CnpjRestaurante) references Restaurante(Cnpj)
	,foreign key (CpfCliente) references Cliente(Cpf)
);