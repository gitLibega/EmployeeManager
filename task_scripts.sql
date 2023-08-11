use Employees;
--Скрипт заполнения таблицы

DECLARE @number INT
SET @number = 100;
CREATE TABLE #TempNames (
   FirstName VARCHAR(50),
   LastName VARCHAR(50),
   Patronymic VARCHAR(50),
   Department VARCHAR(50)
)

INSERT INTO #TempNames (FirstName, LastName, Patronymic,Department)
VALUES
   ('John', 'Doe', 'Michael', 'Market'),
   ('Jane', 'Smith', 'Anne', 'IT'),
   ('David', 'Johnson', 'Robert', 'Tax'),
   ('Anna', 'Wilson', 'John', 'Legal')

   
 
WHILE @number > 0
    BEGIN
INSERT INTO Employees (FirstName, LastName, Patronymic, DateOfBirth, DateOfEmployment, Salary, Department)
SELECT
   (SELECT TOP 1 FirstName FROM #TempNames ORDER BY NEWID()) AS FirstName,
   (SELECT TOP 1 LastName FROM #TempNames ORDER BY NEWID()) AS LastName,
   (SELECT TOP 1 Patronymic FROM #TempNames ORDER BY NEWID()) AS Patronymic,
   DATEADD(year, ROUND(RAND(@number) * @number-70,@number), GETDATE()-100) AS DateOfBirth,
   DATEADD(year, ROUND(RAND(@number) * @number-40,@number+13), GETDATE()-100) AS DateOfEmployment,
   ROUND(RAND(@number*@number*@number) * 100000, @number) AS Salary,
   (SELECT TOP 1 Department FROM #TempNames ORDER BY NEWID()) AS Department

   SET @number = @number - 1
    END;

DROP TABLE #TempNames


-- запрос на выборку всех сотрудников

select * from Employees;

-- запрос на выборку всех сотрудников у кого зп больше 10000

select * from Employees where Salary > 10000;

-- запрос на удаление сотрудников старше 70 лет

delete from Employees where DATEDIFF(DAY,DateOfBirth, GETDate()) > 70

--обновить зп до 15000  тем сотрудникам, у которых она меньше.

update Employees set Salary = 15000 where Salary < 10000;