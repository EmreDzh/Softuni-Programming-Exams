CREATE DATABASE Zoo
GO

USE Zoo
GO

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)

)
CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)
CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)
CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT  FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)
CREATE TABLE AnimalsCages
(
	CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id)
	PRIMARY KEY (CageId, AnimalId)
)
CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)
CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)

)


		--EXERCISE 2
INSERT INTO Volunteers([Name],PhoneNumber,[Address],AnimalId,DepartmentId) VALUES
('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev','0877564223',NULL,42,4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
('Boryana Mileva','0888112233',NULL,31,5)

INSERT INTO Animals([Name],BirthDate,OwnerId,AnimalTypeId) VALUES
('Giraffe','2018-09-21',21,1),
('Harpy Eagle','2015-04-17',15,3),
('Hamadryas Baboon','2017-11-02',NULL,1),
('Tuatara','2021-06-30',2,4)

		--EXERCISE 3
UPDATE Animals
SET OwnerId = (
	SELECT Id
	FROM Owners
	WHERE [Name] = 'Kaloqn Stoqnov '
)
WHERE OwnerId IS NULL

		--EXERCISE 4
DELETE FROM Volunteers
WHERE DepartmentId IN (
	SELECT Id
	FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'
)

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant' 

		--EXERCISE 5
SELECT
[Name],
PhoneNumber,
[Address],
AnimalId,
DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

		--EXERCISE 6
SELECT
a.[Name],
ay.AnimalType,
CONVERT(VARCHAR(10), a.BirthDate, 104) AS BirthDate
FROM Animals AS a
LEFT JOIN AnimalTypes AS ay ON a.AnimalTypeId = ay.Id
ORDER BY a.[Name]

		--EXERCISE 7
SELECT TOP(5)
o.[Name] AS [Owner],
COUNT(a.Id) AS CountOfAnimals
FROM Animals AS a
INNER JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, o.[Name]

		--EXERCISE 8
SELECT
CONCAT(o.[Name],'-',a.[Name]) AS OwnersAnimals,
o.PhoneNumber,
c.Id
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
JOIN AnimalTypes AS ay ON a.AnimalTypeId = ay.Id
JOIN Cages AS c ON ac.CageId = c.Id
WHERE ay.AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

		--EXERCISE 9
SELECT
v.[Name],
v.PhoneNumber,
replace(replace(replace(v.Address, 'Sofia,', ''), 'Sofia ,', ''), 'n/a', '') AS [Address]
FROM Volunteers AS v
LEFT JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE vd.DepartmentName = 'Education program assistant' 
AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name]


		--EXERCISE 10
SELECT
a.[Name],
DATEPART(YEAR, a.BirthDate) AS BirthYear,
ap.AnimalType
FROM Animals AS a
LEFT JOIN AnimalTypes AS ap ON a.AnimalTypeId = ap.Id
WHERE a.OwnerId IS NULL
AND DATEPART(YEAR, a.BirthDate) >= 2018
AND ap.AnimalType NOT LIKE '%Birds%'
ORDER BY a.[Name]


		--EXERCIE 11
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
		DECLARE @vdId INT = (
			SELECT
			Id
			FROM VolunteersDepartments
			WHERE DepartmentName = @VolunteersDepartment
		)

		DECLARE @countVolu INT = (
			SELECT
			COUNT(vd.Id)
			FROM Volunteers AS v
			LEFT JOIN VolunteersDepartments AS vd ON v.DepartmentId = VD.Id
			WHERE vd.Id = @vdId
		)

		RETURN @countVolu

END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')



		--EXERCISE 12
CREATE PROC usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
BEGIN
		SELECT
			a.[Name],
			CASE
			WHEN a.OwnerId IS NULL THEN 'For adoption'
			WHEN a.OwnerId IS NOT NULL THEN o.[Name]
			END AS [OwnersName]
		FROM Animals AS a
		LEFT JOIN Owners AS o ON a.OwnerId = o.Id
		WHERE a.[Name] = @AnimalName

END

EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
