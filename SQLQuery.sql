CREATE TABLE ponto
(
entrada DATETIME NOT NULL,
saida DATETIME NULL
);
GO

TRUNCATE TABLE ponto;

CREATE TABLE [login]
(
idlogin INT NOT NULL IDENTITY(1,1),
usuario VARCHAR(35) NOT NULL,
senha VARCHAR(40) NOT NULL,

PRIMARY KEY (idlogin)
);
GO

INSERT INTO [login] (usuario, senha)
VALUES ('ihmhr','b7890930eea66df197d479588b7e482ff12ffbeb');

SELECT * FROM [login];

SELECT * FROM ponto;


Alter VIEW vw_relatorio_estagio
AS
SELECT CASE DATENAME(dw,ISNULL(entrada,saida))
	WHEN 'Friday' THEN 'Sexta-Feira'
	WHEN 'Monday' THEN 'Segunda-Feira'
	WHEN 'Tuesday' THEN 'Terça-Feira'
	WHEN 'Wednesday' THEN 'Quarta-Feira'
	WHEN 'Thursday' THEN 'Quinta-Feira'
	WHEN 'Saturday' THEN 'Sabado'
	WHEN 'Sunday' THEN 'Domingo'
END AS Dia, CONVERT(VARCHAR, entrada, 103) + ' ' + CONVERT(VARCHAR, entrada, 108) AS Entrada, CONVERT(VARCHAR, saida, 103) + ' ' + CONVERT(VARCHAR, saida, 108) AS Saida,
DATEDIFF(MINUTE, entrada, saida) AS 'Minutos Trabalhados',
DATEDIFF(HOUR, entrada, saida) AS 'Horas Trabalhadas',
CASE 
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) = 0 THEN 'Nada'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 60 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 120 THEN '1 Hora'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) < 60 THEN 'Menos de 1 Hora'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 120 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 180 THEN '3 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 240 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 300 THEN '4 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 360 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 420 THEN '5 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 480 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 540 THEN '6 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 600 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 660 THEN '7 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 720 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 780 THEN '8 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 840 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 900 THEN '9 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 960 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1020 THEN '10 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1080 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1140 THEN '11 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1200 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1260 THEN '12 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1320 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1380 THEN '13 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1440 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1500 THEN '14 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1560 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1620 THEN '15 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1680 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1740 THEN '16 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1800 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1860 THEN '17 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 1920 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 1980 THEN '18 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 2040 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 2100 THEN '19 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) > 2160 AND (DATEDIFF(MINUTE, entrada, saida) - 360) < 2220 THEN '20 Horas'
	WHEN (DATEDIFF(MINUTE, entrada, saida) - 360) IS NULL THEN 'N/A'
	ELSE '+ 20 Horas'
END AS 'Tempo na Casa',
CAST((DATEDIFF(MINUTE, entrada, saida) - 360) AS VARCHAR) + ' minutos' AS 'Tempo exato'
FROM dbo.ponto_estagio;

EXEC sp_rename 'ponto', 'ponto_estagio';
ALTER TABLE ponto_estagio ALTER COLUMN entrada DATETIME NULL;

CREATE TABLE ponto_clt
(
entrada DATETIME NULL,
entrada_almoco DATETIME NULL,
saida_almoco DATETIME NULL,
saida DATETIME NULL
);
GO


ALTER VIEW vw_relatorio_clt
AS
SELECT CASE DATENAME(dw,ISNULL(entrada,saida))
	WHEN 'Friday' THEN 'Sexta-Feira'
	WHEN 'Monday' THEN 'Segunda-Feira'
	WHEN 'Tuesday' THEN 'Terça-Feira'
	WHEN 'Wednesday' THEN 'Quarta-Feira'
	WHEN 'Thursday' THEN 'Quinta-Feira'
	WHEN 'Saturday' THEN 'Sabado'
	WHEN 'Sunday' THEN 'Domingo'
END AS Dia, CONVERT(VARCHAR, entrada, 103) + ' ' + CONVERT(VARCHAR, entrada, 108) AS Entrada, 
CONVERT(VARCHAR, entrada_almoco, 103) + ' ' + CONVERT(VARCHAR, entrada_almoco, 108) AS 'Foi Almoçar',
CONVERT(VARCHAR, saida_almoco, 103) + ' ' + CONVERT(VARCHAR, saida_almoco, 108) AS 'Voltou do Almoço',
CONVERT(VARCHAR, saida, 103) + ' ' + CONVERT(VARCHAR, saida, 108) AS Saida,
(CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT)) AS 'Minutos Trabalhados',
(DATEDIFF(MINUTE, entrada, saida) - DATEDIFF(MINUTE, entrada_almoco, saida_almoco)) / 60 AS 'Horas Trabalhadas',
CASE 
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) = 0 THEN 'Nada'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 60 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 120 THEN '1 Hora'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 60 THEN 'Menos de 1 Hora'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 120 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 180 THEN '3 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 240 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 300 THEN '4 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 360 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 420 THEN '5 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 480 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 540 THEN '6 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 600 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 660 THEN '7 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 720 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 780 THEN '8 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 840 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 900 THEN '9 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 960 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1020 THEN '10 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1080 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1140 THEN '11 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1200 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1260 THEN '12 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1320 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1380 THEN '13 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1440 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1500 THEN '14 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1560 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1620 THEN '15 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1680 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1740 THEN '16 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1800 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1860 THEN '17 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 1920 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 1980 THEN '18 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 2040 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 2100 THEN '19 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) > 2160 AND (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) < 2220 THEN '20 Horas'
	WHEN (CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) IS NULL THEN 'N/A'
	ELSE '+ 20 Horas'
END AS 'Tempo na Casa',
CAST((CAST(DATEDIFF(MINUTE, entrada, saida) AS INT) - CAST(DATEDIFF(MINUTE, entrada_almoco, saida_almoco) AS INT) - 528) AS VARCHAR) + ' minutos' AS 'Tempo exato'
FROM dbo.ponto_clt;


select
(DATEDIFF(MINUTE, entrada, saida) - DATEDIFF(MINUTE, entrada_almoco, saida_almoco)) / 60 AS 'Horas Trabalhadas'
from ponto_clt;

select * from ponto_estagio WHERE entrada LIKE '%10:54%';
UPDATE ponto_estagio SET entrada = '20160616 10:54:00.000' WHERE entrada = '2016-06-10 10:54:00.000'



SELECT saida INTO saidas FROM ponto_estagio pe WHERE pe.saida IS NOT NULL;

SELECT CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR)
FROM ponto_estagio pe WHERE pe.saida IS NOT NULL;

SELECT * FROM entradas
RIGHT JOIN saidas
ON CAST(DAY(entrada) AS VARCHAR) + N'' + CAST(MONTH(entrada)  AS VARCHAR) = CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR)

Alter PROCEDURE usp_arrumar_estagio
AS
BEGIN
	DROP TABLE IF EXISTS entradas;
	DROP TABLE IF EXISTS saidas;

	SELECT entrada INTO entradas FROM ponto_estagio pe WHERE pe.entrada IS NOT NULL;
	SELECT saida INTO saidas FROM ponto_estagio pe WHERE pe.saida IS NOT NULL;

	DROP TABLE IF EXISTS ponto_estagio;

	SELECT * INTO ponto_estagio FROM entradas
	FULL OUTER JOIN saidas
	ON CAST(DAY(entrada) AS VARCHAR) + N'' + CAST(MONTH(entrada)  AS VARCHAR) = CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR);

	IF ((SELECT COUNT(1) FROM ponto_estagio) > 0) BEGIN
		DROP TABLE IF EXISTS entradas;
		DROP TABLE IF EXISTS saidas;
	END
END
GO

EXEC usp_arrumar_estagio

SELECT * FROM vw_relatorio_estagio ORDER BY Entrada DESC, Saida

SELECT CASE DATENAME(dw,ISNULL(entrada,saida))
	WHEN 'Friday' THEN 'Sexta-Feira'
	WHEN 'Monday' THEN 'Segunda-Feira'
	WHEN 'Tuesday' THEN 'Terça-Feira'
	WHEN 'Wednesday' THEN 'Quarta-Feira'
	WHEN 'Thursday' THEN 'Quinta-Feira'
	WHEN 'Saturday' THEN 'Sabado'
	WHEN 'Sunday' THEN 'Domingo'
END AS Dia, CONVERT(VARCHAR, entrada, 103) + ' ' + CONVERT(VARCHAR, entrada, 108) AS Entrada
FROM dbo.ponto_estagio;

SELECT ISNULL(pe.entrada, pp.entrada) AS Ent, ISNULL(pe.saida, pp.saida) AS Said FROM dbo.ponto_estagio pe CROSS JOIN dbo.ponto_estagio pp
WHERE (pe.entrada IS NOT NULL OR pp.entrada IS NOT NULL);

DELETE FROM ponto_estagio WHERE saida IN (
'2016-07-02 12:04:55.000',
'2016-07-02 12:06:06.000',
'2016-07-02 12:07:17.000',
'2016-07-02 12:07:32.000',
'2016-07-02 12:16:00.000',
'2016-07-02 12:16:13.000',
'2016-07-02 12:16:30.000',
'2016-07-02 12:19:05.000',
'2016-07-02 12:19:22.000'
);


SELECT object_name(object_id) as procedure_executed, last_execution_time, last_elapsed_time, execution_count
FROM   sys.dm_exec_procedure_stats ps 
WHERE lower(object_name(object_id)) = 'usp_arrumar_estagio'
ORDER BY last_execution_time DESC

IF(DATEDIFF(DAY, (SELECT last_execution_time FROM   sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_estagio'), GETDATE()) >= 1) BEGIN EXEC usp_arrumar_estagio END

SELECT DATEDIFF(DAY, (SELECT last_execution_time FROM   sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_estagio'), GETDATE())

CREATE PROCEDURE usp_arrumar_clt
AS
BEGIN
	DROP TABLE IF EXISTS entradas;
	DROP TABLE IF EXISTS saidas;
	DROP TABLE IF EXISTS vaialmocar;
	DROP TABLE IF EXISTS voltaalmocar;

	SELECT entrada INTO entradas FROM ponto_clt pc WHERE pc.entrada IS NOT NULL;
	SELECT saida INTO saidas FROM ponto_clt pc WHERE pc.saida IS NOT NULL;
	SELECT entrada_almoco INTO vaialmocar FROM ponto_clt pc WHERE pc.entrada_almoco IS NOT NULL;
	SELECT saida_almoco INTO voltaalmocar FROM ponto_clt pc WHERE pc.saida_almoco IS NOT NULL;

	DROP TABLE IF EXISTS ponto_clt;

	SELECT * INTO ponto_clt FROM entradas 
	FULL OUTER JOIN saidas ON 
		CAST(DAY(entrada) AS VARCHAR) + N'' + CAST(MONTH(entrada)  AS VARCHAR) =	CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR)
	FULL OUTER JOIN vaialmocar ON 
		(CAST(DAY(entrada_almoco) AS VARCHAR) + N'' + CAST(MONTH(entrada) AS VARCHAR)	= CAST(DAY(entrada) AS VARCHAR) + N'' + CAST(MONTH(entrada)  AS VARCHAR) AND CAST(DAY(entrada_almoco) AS VARCHAR) + N'' + CAST(MONTH(entrada)  AS VARCHAR) = CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR))
	FULL OUTER JOIN voltaalmocar ON 
		(CAST(DAY(saida_almoco) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR) = CAST(DAY(entrada_almoco) AS VARCHAR) + N'' + CAST(MONTH(entrada) AS VARCHAR) AND CAST(DAY(saida_almoco) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR) = CAST(DAY(entrada) AS VARCHAR) + N'' + CAST(MONTH(entrada) AS VARCHAR) AND CAST(DAY(saida_almoco) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR) = CAST(DAY(entrada_almoco) AS VARCHAR) + N'' + CAST(MONTH(entrada) AS VARCHAR) AND CAST(DAY(saida_almoco) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR) = CAST(DAY(saida) AS VARCHAR) + N'' + CAST(MONTH(saida) AS VARCHAR))

	IF ((SELECT COUNT(1) FROM ponto_estagio) > 0) BEGIN
		DROP TABLE IF EXISTS entradas;
		DROP TABLE IF EXISTS saidas;
	END
END
GO


SELECT * FROM ponto_clt

EXEC usp_arrumar_clt

IF(DATEDIFF(DAY, (SELECT last_execution_time FROM sys.dm_exec_procedure_stats ps WHERE lower(object_name(object_id)) = 'usp_arrumar_clt'), GETDATE()) >= 1) 
BEGIN 
	EXEC usp_arrumar_clt
END
