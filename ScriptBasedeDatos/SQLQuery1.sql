CREATE DATABASE JUEGOPREGUNTAS

USE JUEGOPREGUNTAS


drop table JUGADOR

CREATE TABLE CATEGORIA(

CODIGOCATEGORIA VARCHAR(60) NOT NULL PRIMARY KEY,
NOMBRECATEGORIA VARCHAR(30) NOT NULL,
NIVELCATEGORIA INT NOT NULL,




)

INSERT INTO CATEGORIA(CODIGOCATEGORIA,NOMBRECATEGORIA,NIVELCATEGORIA)VALUES('1A2B3C4D5E','HISTORIA',1)
INSERT INTO CATEGORIA(CODIGOCATEGORIA,NOMBRECATEGORIA,NIVELCATEGORIA)VALUES('1F2G3H4I5J','CIENCIA',2)
INSERT INTO CATEGORIA(CODIGOCATEGORIA,NOMBRECATEGORIA,NIVELCATEGORIA)VALUES('1K2L3M4N5O','GEOGRAFIA',3)
INSERT INTO CATEGORIA(CODIGOCATEGORIA,NOMBRECATEGORIA,NIVELCATEGORIA)VALUES('2P2A3R4S5W','DEPORTE',4)
INSERT INTO CATEGORIA(CODIGOCATEGORIA,NOMBRECATEGORIA,NIVELCATEGORIA)VALUES('1X2Y3Z4A5B','ARTE',5)
SELECT * FROM CATEGORIA


CREATE TABLE PREGUNTA(

CODIGOPREGUNTA VARCHAR(60) NOT NULL PRIMARY KEY,
CATEGORIA VARCHAR(60) NOT NULL,
TITULOPREGUNTA VARCHAR(200) NOT NULL,
CONSTRAINT fk_categoria FOREIGN KEY(CATEGORIA)REFERENCES CATEGORIA(CODIGOCATEGORIA)

)

INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('1','1A2B3C4D5E','EN QUE GUERRA PARTICIPO JUANA DE ARCO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('2','1A2B3C4D5E','CUAL ERA LA CAPITAL DEL IMPERIO INCA')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('3','1A2B3C4D5E','COMO SE LLAMABA EL PADRE DE ALEJANDRO MAGNO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('4','1A2B3C4D5E','QUIEN FUE EL PRIMER EMPERADOR ROMANO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('5','1A2B3C4D5E','EN QUE PAIS NACIO ADOLF HITLER')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('6','1F2G3H4I5J','QUE ES LA FOTOSINTESIS')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('7','1F2G3H4I5J','CUANTOS TIPOS DE DINOSAURIOS HUBIERON')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('8','1F2G3H4I5J','EN QUE GALAXIA SE ENCUENTRA LA TIERRA')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('9','1F2G3H4I5J','CUAL ES LA EDAD DEL UNIVERSO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('10','1F2G3H4I5J','COMO SE LLAMA A LA MUERTE DE UNA ESPECIE')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('11','1K2L3M4N5O','CUAL ES LA CAPITAL DE TURQUIA')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('12','1K2L3M4N5O','EN QUE ISLA ITALIANA ESTA PALERMO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('13','1K2L3M4N5O','CUAL ES LA CAPITAL DE TURQUIA')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('14','1K2L3M4N5O','CUAL ES EL CONTINENTE MAS POBLADO DEL PLANETA')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('15','1K2L3M4N5O','CUAL ES LA MONTA�A MAS ALTA DEL MUNDO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('20','1X2Y3Z4A5B','QUIEN PINTO LA "GIOCONDA"')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('21','1X2Y3Z4A5B','COMO SE LLAMA EL PINTOR QUE SE CORTO LA OREJA"')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('22','1X2Y3Z4A5B','COMO SE LLAMA LA FAMOSA PINTURA DE LEONARDO DAVINCI DONDE APARECE JESUS"')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('23','1X2Y3Z4A5B','LA PINTURA CONOCIDA COMO "GUERNICA" FUE PINTADA POR"')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('24','1X2Y3Z4A5B','QUIEN PINTO LA CAPILLA SIXTINA DEL VATICANO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('25','1X2Y3Z4A5B','QUIEN DE ELLAS NO FUE UNA PINTORA FAMOSA"')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('16','2P2A3R4S5W','CUAL ES EL APODO DEL LEISTER CITY')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('17','2P2A3R4S5W','QUE REVISTA CONCEDE EL BALON DE ORO')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('18','2P2A3R4S5W','CUANTOS JUGADORES COMPONEN UN EQUIPO DE RUGBY')
INSERT INTO PREGUNTA(CODIGOPREGUNTA,CATEGORIA,TITULOPREGUNTA)VALUES('19','2P2A3R4S5W','EN QUE PAIS SE INVENTO EL VOLEIVOL')





SELECT * FROM PREGUNTA
CREATE TABLE RESPUESTA(

 CODRESPUESTA VARCHAR(60) NOT NULL,
 CODPREGUNTA VARCHAR(60) NOT NULL,
 RESPUESTACORRECTA VARCHAR(100) NOT NULL,
 RESPUESTAFALSA1 VARCHAR(100) NOT NULL,
 RESPUESTAFALSA2 VARCHAR(100) NOT NULL,
 RESPUESTAFALSA3 VARCHAR(100) NOT NULL

CONSTRAINT fk_pregunta FOREIGN KEY(CODPREGUNTA)REFERENCES PREGUNTA(CODIGOPREGUNTA)
CONSTRAINT pk_respuesta PRIMARY KEY(CODRESPUESTA,CODPREGUNTA)
)

INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('1A2B3C','1','LA GUERRA DE LOS 100 A�OS','LA GUERRA DE LOS 30 A�OS','PRIMERA CRUZADA','GUERRAS NAPOLEONICAS')

INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('1D2E3F','2','CUZCO','QUITO','MACHU PICHU','LIMA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('1G2H3I','3','FILIPO 2 DE MACEDONIA' ,'LEONIDAS','FILIPO 1 DE GRECIA','PTOLOMEO')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('1J2K3L','4','CESAR AUGUSTO','JULIO CESAR','NERON','CALIGULA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('1M2N3O','5','AUSTRIA','ALEMANIA','POLONIA','ZUIZA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('2A3B4C','6','PROCESO QUIMICO QUE TIENE LUGAR EN LAS PLANTAS','ENFERMEDAD CANCERIGENA','CELULAS MUERTAS','ABONO PARA LAS PLANTAS')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('2D3E4F','7','1700 A 1900','2000 A 2500','600 A 700','200 A 500')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('2G3H4I','8','LA VIA LACTEA','ANDROMEDA','TIERRA','OSA MAYOR')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('2J3K4L','9','13.000 A 20.000 MILLONES','40.000 A 60.000 MILLONES','1 A 2 MILLONES','15.000 A 30.000 MILLONES')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('2M3N4O','10','EXTINCION ','CAZA FURTIVA',' DESAPARICION ANIMAL','CAUTIVERIO ')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('3A4B5C','11','ANKARA','OTTAWA','RIAD','PRETORIA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('3D4E5F','12','SICILIA','CALABRIA','BASILICATA','ANDORRA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('3G4H5I','13','ANKARA','OTTAWA','RIAD','PRETORIA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('3J4K5L','14','ASIA','EUROPA','AMERICA','RUSIA')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('3M4N5O','15','MONTE EVEREST','MONTE MAKALU','MONTE CHO OYU','MONTE MANASLU')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('4A5B6C','16','THE FOXES','LA NARANJA MECANICA','LOS GALACTICOS','LOS DIABLOS ROJOS')

INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('4D5E6F','17','FRANCE FOOTBALL','AS','MARCA','SUN SPORT')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('4G5H6I','18','15','11','10','9')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('4J5K6L','19','ESTADOS UNIDOS','CANADA','TURKIA','JAPON')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('4M5N6O','20','LEONARDO DAVINCI','PICASSO','MIGUEL ANGEL','BOTERO')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('5A6B7C','21','VAN GOGH','PICASSO','LEONARDO','MIGUEL ANGEL')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('5B6C7D','22','LA ULTIMA CENA',' LA GIOCONDA','GUERNICA','EL GRITO')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('5E6F7G','23','PICASSO',' BOTERO','MIGUEL ANGEL','RAPHAEL')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('5H6I7K','24','MIGUEL ANGEL',' LEONARDO','RAPHEL','VAN GOGH')
INSERT INTO RESPUESTA(CODRESPUESTA,CODPREGUNTA,RESPUESTACORRECTA,RESPUESTAFALSA1,RESPUESTAFALSA2,RESPUESTAFALSA3)VALUES
('5L6M7N','25','FEDE GALIZIA',' FRIDA KAHLO','ARTEMISA','MARY CASSATT')

SELECT * FROM RESPUESTA
CREATE TABLE PREMIO(

  CODIGOPREMIO VARCHAR(60) NOT NULL PRIMARY KEY,
  TIPOPREMIO VARCHAR(30) NOT NULL,
  VALORPREMIO REAL NOT NULL



  
)
INSERT INTO PREMIO(CODIGOPREMIO,TIPOPREMIO,VALORPREMIO)VALUES('01','EFECTIVO',1000000)
INSERT INTO PREMIO(CODIGOPREMIO,TIPOPREMIO,VALORPREMIO)VALUES('02','MOTO',3000000)
INSERT INTO PREMIO(CODIGOPREMIO,TIPOPREMIO,VALORPREMIO)VALUES('03','EFECTIVO',6000000)
INSERT INTO PREMIO(CODIGOPREMIO,TIPOPREMIO,VALORPREMIO)VALUES('04','CARRO',25000000)
INSERT INTO PREMIO(CODIGOPREMIO,TIPOPREMIO,VALORPREMIO)VALUES('05','EFECTIVO',70000000)

CREATE TABLE JUGADOR(

CODIGO VARCHAR(60) NOT NULL PRIMARY KEY,
NOMBRE VARCHAR(50) NOT NULL,
CORREO VARCHAR(60) NOT NULL,
CONTRASE�A VARCHAR(40)NOT NULL,
CODIGORONDA INT 


)
select * from JUGADOR

ALTER TABLE JUGADOR ADD CONSTRAINT fk_round FOREIGN KEY(CODIGORONDA)REFERENCES RONDA(NUMERORONDA)
CREATE TABLE RONDA(

NUMERORONDA INT NOT NULL  PRIMARY KEY,
PREMIORONDA VARCHAR(60) NOT NULL,
CODCATEGORIA VARCHAR(60) NOT NULL,
CONSTRAINT fk_Premio FOREIGN KEY(PREMIORONDA) REFERENCES PREMIO(CODIGOPREMIO),
CONSTRAINT fk_catego FOREIGN KEY(CODCATEGORIA)REFERENCES CATEGORIA(CODIGOCATEGORIA)

)

INSERT INTO RONDA(NUMERORONDA,PREMIORONDA,CODCATEGORIA)VALUES(1,'01','1A2B3C4D5E')
INSERT INTO RONDA(NUMERORONDA,PREMIORONDA,CODCATEGORIA)VALUES(2,'02','1F2G3H4I5J')
INSERT INTO RONDA(NUMERORONDA,PREMIORONDA,CODCATEGORIA)VALUES(3,'03','1K2L3M4N5O')
INSERT INTO RONDA(NUMERORONDA,PREMIORONDA,CODCATEGORIA)VALUES(4,'04','2P2A3R4S5W')
INSERT INTO RONDA(NUMERORONDA,PREMIORONDA,CODCATEGORIA)VALUES(5,'05','1X2Y3Z4A5B')

