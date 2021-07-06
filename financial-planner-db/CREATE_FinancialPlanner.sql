-- CREATE TABLE dbo.[User] (
--     UserId int NOT NULL IDENTITY PRIMARY KEY,
--     EmailAddress varchar(100) NOT NULL,
--     FirstName varchar(100) NOT NULL, 
--     MiddleName varchar(100) NULL, 
--     LastName varchar(100) NOT NULL, 
--     PasswordHash varchar(200) NOT NULL
-- )
-- CREATE TABLE Frequency (
--     FrequencyId int NOT NULL IDENTITY PRIMARY KEY,
--     Description varchar(50) NOT NULL
-- )
-- CREATE TABLE Bill (
--     BillId int NOT NULL IDENTITY, 
--     Name varchar(100) NOT NULL, 
--     FrequencyId int NOT NULL,
--     UserId int NOT NULL,
--     StartDate DATE NULL,
--     RepetitionDay int NULL,
--     Amount Decimal(6,2) NOT NULL,
--     IsIncome bit DEFAULT 0,
--     FOREIGN KEY(UserId) REFERENCES dbo.[User](UserId),
--     FOREIGN KEY(FrequencyId) REFERENCES Frequency(FrequencyId)
-- )
select * from dbo.[User]
select * from Frequency
select * from Bill
-- DELETE FROM Bill
-- alter table Bill Add RepetitionDay INT NULL