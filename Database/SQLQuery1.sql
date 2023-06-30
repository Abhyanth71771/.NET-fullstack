create table vehicles
(
    vehicleid int constraint pk_vehicleid primary key,
    brand varchar(30),
    model varchar(30),
    yr int
)



insert into vehicles values(1, 'FORD', 'Figo Aspire', 2018)
insert into vehicles values(2, 'FORD', 'EcoSport', 2020)
insert into vehicles values(3, 'RENAULT', 'Kiger', 2021)
insert into vehicles values(4, 'VOLKS WAGON', 'Taigun', 2020)
select * from vehicles
select @@SERVERNAME