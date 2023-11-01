create database db_Medexp
go
use db_Medexp
go
create table users(user_login varchar(30) primary key,password varchar(30),user_role varchar(30),CONSTRAINT check_role CHECK (user_role IN ('admin','demandeur')))
go
insert into users values('Moncef','123','admin'),('Salah','123','demandeur')
go
select * from users
create table fourniseur( nom_fournisseur varchar(30) PRIMARY KEY,categorie varchar(60))
go

create table article (article varchar(50) primary key,prix float, id_four varchar(30) foreign key references fourniseur(nom_fournisseur))
go

create table demande(reference varchar(30) PRIMARY KEY,article varchar(50) foreign key references article(article),quantity int,etat varchar(30) DEFAULT 'NON confirmer')
go

insert into fourniseur values('test','pilule')
go

insert into article values('dolipran',2000,'Moncef')
go

alter table users add CONSTRAINT check_role check (user_role IN ('admin','demandeur','Receptionist'))
go
insert into users values('Mehdi',123,'Receptionist')
go
