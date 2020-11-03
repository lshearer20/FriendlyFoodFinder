postgres(

create table Family(
	familyId integer IDENTITY(1,1),
	familyName varchar,
	primary key(familyId)
);
create table Person (
	personId integer IDENTITY(1,1),
	personName varchar,
	primary key(personId)
);
create table Users (
	userId integer IDENTITY(1,1),
	personId integer,
	userName varchar,
	primary key(userId),
	foreign key(personId, personName) references Person(personId, personName)
);
create table FamilyPersons(
	familyId integer,
	personId integer,
	primary key(familyId, personId),
	foreign key(familyId) references Family(familyId),
	foreign key(personId) references Person(personId)
);
create table userFamiles(
	familyId integer,
	userId integer,
	primary key(familyId, userId),
	foreign key(familyId) references Family(familyId),
	foreign key(userId) references Person(userId)
);

create table Nutrition(
	upc varchar(12),
	ingredients varchar,
	primary key(upc)
);




)
SQL(
DROP TABLE if exists FamilyPersons;
DROP TABLE if exists UserFamiles;
DROP TABLE if exists Users;
DROP TABLE if exists Family;
DROP TABLE if exists Person;
DROP TABLE if exists Nutrition;


create table Family(
	familyId integer IDENTITY(1,1),
	familyName varchar(50) ,
	primary key(familyId)
);
create table Person (
	personId integer IDENTITY(1,1),
	personName varchar(50) ,
	primary key(personId)
);
create table Users (
	userId integer IDENTITY(1,1),
	primary key(userId),
	personId int foreign key references Person(personId),
);
create table FamilyPersons(
	familyId integer,
	personId integer,
	primary key(familyId, personId),
	foreign key(familyId) references Family(familyId),
	foreign key(personId) references Person(personId)
);
create table UserFamiles(
	familyId integer foreign key references Family(familyId),
	userId integer foreign key references Users(userId),
	primary key(familyId, userId)
);

create table Nutrition(
	upc varchar(14),
	ingredients varchar,
	primary key(upc)
);

)

insert into <tableName>(columnName,columnName) values (v1,v2),(v1b, v2b),(v1c,v2c);
delete from <tableName> where <columnName> = 
ConnectionStrings