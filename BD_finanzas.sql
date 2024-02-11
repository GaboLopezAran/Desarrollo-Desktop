Create database Administracion_Financiera
Use Administracion_Financiera

Create table usuario(
id_usuario int identity not null primary key,
usuario varchar (30),
contrasena varchar (30)
);

Create table ingreso(
id_ingreso int identity not null primary key,
id_usuarios int not null,
monto int,
fecha date,
descricpcion varchar (50)
foreign key (id_usuarios) references usuario(id_usuario)
);

Create table egreso(
id_egreso int identity not null primary key,
id_usuarios int not null,
monto int,
fecha date,
descricpcion varchar (50)
foreign key (id_usuarios) references usuario(id_usuario)
);

Create table cuenta(
id_cuenta int identity not null primary key,
id_usuarios int not null,
id_ingresos int not null,
id_egresos int not null,
monto int
foreign key (id_usuarios) references usuario(id_usuario),
foreign key (id_ingresos) references ingreso(id_ingreso),
foreign key (id_egresos) references egreso(id_egreso)
);

--Insersion datos

select * from egreso
select * from ingreso

alter table ingreso alter column monto decimal(10,2)
alter table egreso alter column monto decimal(10,2)

delete from egreso;

create table prestamos(
idprestamo int identity not null primary key,
id_egreso int not null,
monto int,
fecha date,
descricpcion varchar (50),
pagado varchar (2)
)


CREATE TRIGGER insertar_prestamo
ON egreso
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT * FROM inserted WHERE descricpcion LIKE '%prestamo%')
    BEGIN
        INSERT INTO prestamos(id_egreso, monto, fecha,descricpcion,pagado)
        SELECT  id_egreso,monto, fecha,descricpcion,'no'
        FROM inserted;
    END;
END;



drop trigger insertar_prestamo

select * from prestamos

insert into egreso values (1,23.34,'09-07-2023','prestamo')


create procedure SP_filtroIngresos
@fechainicio as datetime,
@fechafinal as datetime
AS
Select i.id_ingreso, u.usuario,i.fecha,i.monto,i.descricpcion from ingreso i join usuario u on i.id_usuarios=u.id_usuario 
where i.fecha>=@fechainicio and i.fecha<=@fechafinal order by i.fecha;

drop procedure SP_filtroIngresos

create procedure SP_filtroEgresos
@fechainicio as datetime,
@fechafinal as datetime
AS
Select u.usuario,e.fecha,e.monto,e.descricpcion from egreso e join usuario u on e.id_usuarios=u.id_usuario 
where e.fecha>=@fechainicio and e.fecha<=@fechafinal order by e.fecha;

execute SP_FiltroEgresos'01-05-2023','03-05-2023';

