CREATE DATABASE PortLog5;
USE [PortLog5]
CREATE TABLE Usuarios (
    cedula int NOT NULL,
    contraseña nvarchar(50) NOT NULL,
    rol nvarchar(50) NOT NULL,
    PRIMARY KEY (cedula)
);

CREATE TABLE Clientes (
    rut nvarchar(50) NOT NULL,
    nombreCli nvarchar(50) NOT NULL,
    antiguedadFecha DATETIME,
    PRIMARY KEY (rut)
);

CREATE TABLE Productos (
    IdProd int IDENTITY(1,1) NOT NULL,
    nombreProd nvarchar(50) NOT NULL,
        pesoUnidad float,
    PRIMARY KEY (IdProd),
    rut nvarchar(50) FOREIGN KEY REFERENCES Clientes(rut)
);

CREATE TABLE Importaciones (
    codigoImp int IDENTITY(1,1) NOT NULL,
    cantidad int NOT NULL,
precioPorUnidad decimal,
    fechaIngreso DATETIME,
    fechaSalidaPrevista DATETIME,
    PRIMARY KEY (codigoImp),
    IdProd int FOREIGN KEY REFERENCES Productos(IdProd)
);

CREATE TABLE Descuentos (
    antiguedadDiasAplicable int,
    descuentoAplicable decimal,
    comisionDiaria decimal
);



/*INSERTS*/
/*Tabla Usuarios*/
INSERT INTO Usuarios VALUES
(1, 'uno', 'admin'),
(473192081, 'Aminta1983', 'admin'),
(482498581, 'Valium1996', 'admin'),
(473192082, 'Aminta1983', 'deposito'),
(482498582, 'Valium1996', 'deposito');

/*Tabla Clientes:*/
insert into Clientes values
('123488889902', 'Tata Consultancy', '14-JUN-2019'),
('123477778565','Atos SA','01-JUL-2018'),
('144321514562','ANTEL','07-FEB-2020'),
('155555552351','Papaleras Hnos', '21-MAR-2017'),
('110003095823','Farmashop','25-SEP-2016');

/*Tabla Productos:*/
insert into Productos values
('Indica Weed Critical',0.20, '123488889902'),
('Metales',70.5, '123488889902'),
('Maderas', 230,'144321514562'),
('Craft Beer',300,'123477778565'),
('Peras',11,'155555552351'),
('Mouses',30,'110003095823'),
('Teclado', 11,'123488889902'),
('Parlantes',38,'123477778565'),
('Herramientas de Lu', 554,'123477778565'),
('MultiJuice Potion',200,'110003095823');

/*Tabla Importaciones*/
INSERT INTO Importaciones VALUES
(15,10, '14-JUN-2020', '20-JUN-2020', 1),
(20,200, '01-JAN-2020', '20-JAN-2020', 2),
(350,70, '01-JAN-2020', '20-JUN-2020', 3),
(50,100, '11-FEB-2020', '30-JUL-2020', 4),
(50,100, '21-MAR-2020', '15-SEP-2020', 5);

/*Tabla Descuentos*/
INSERT INTO Descuentos VALUES (365, 5, 3);

