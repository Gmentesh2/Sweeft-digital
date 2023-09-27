--6.1
CREATE DATABASE Sweeft
GO

USE Sweeft
GO


CREATE TABLE Teacher
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Gender CHAR(1) CHECK(Gender LIKE 'M' OR Gender LIKE 'F') NOT NULL,
	[Subject] NVARCHAR(250) NOT NULL
)

INSERT INTO Teacher(FirstName,LastName,Gender,[Subject])
VALUES
(N'გიორგი',N'გიორგაძე','M',N'ბიოლოგია'),
(N'ზურაბ',N'ზურაბიანი','M',N'მათემატიკა')
[dbo].[TeacherPupils]
CREATE TABLE Pupil
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Gender CHAR(1) CHECK(Gender LIKE 'M' OR Gender LIKE 'F') NOT NULL,
	Class VARCHAR(30) NOT NULL
)

INSERT INTO Pupil(FirstName,LastName,Gender,Class)
VALUES
(N'დავით',N'დავითაშვილი','M',N'30-A'),
(N'ელენე',N'ელენიძე','F',N'30-B'),
(N'ანა',N'ანანიაშვილი','F',N'30-A'),
(N'გიორგი',N'ჩხარტიშვილი','M',N'30-B')


CREATE TABLE TeacherPupil
(
	TeacherId INT FOREIGN KEY REFERENCES Teacher(Id),
	PupilId INT FOREIGN KEY REFERENCES Pupil(Id)
)

INSERT INTO TeacherPupil(TeacherId,PupilId)
VALUES
(1,1),
(1,2),
(2,3),
(1,4)


--6.2
SELECT DISTINCT
	t.Id,
	t.FirstName,
	t.LastName,
	t.Gender,
	t.[Subject]
FROM TeacherPupil tp
INNER JOIN Teacher t ON tp.TeacherId = t.Id
INNER JOIN Pupil p ON tp.PupilId = p.Id
WHERE p.FirstName LIKE N'%გიორგი%'