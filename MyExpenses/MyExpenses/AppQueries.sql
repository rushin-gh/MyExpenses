--Use MyExpenseDB;

--create table Users (
--	UserId int primary key,
--	Username varchar(30),
--	[Password] Varchar(30)
--)

--create table Expenses (
--	ExpenseId int primary key identity(1, 1),
--	Title varchar(100) NOT null,
--	[Desc] varchar(300),
--	Amount INT Not null,
--	UserId int,
--	Constraint FK_Users_Expenses Foreign Key (UserId) References Users(UserId)
--);


--select * from Users;

--insert into Expenses values
--('Visit to Dmart', 'Shoes, Raincoat, Wheel, Crocks', 1930, 1)

--create or alter procedure AddExpense
--	@Title VARCHAR(100),
--	@Desc VARCHAR(300),
--	@Amount INT,
--	@UserId INT
--AS
--BEGIN
--	insert into Expenses values
--	(@Title, @Desc, @Amount, @UserId)
--END

--select * from Expenses

--sp_help Users

--Create or alter procedure GetUserExpenses
--	@UserId INT
--AS
--BEGIN
--	Select ExpenseId, Title, [Desc], Amount FROM Expenses where UserId = @UserId;
--END

--GetUserExpenses @UserId = 1;


--insert into Expenses values
--('Laundry', 'White shirt dry cleaning', 80, 9),
--('Iphone 16 Pro', '128 GB variant', 104000, 9),
--('Shine', 'BSIV', 80000, 9);

--ALTER TABLE Users
----ADD CONSTRAINT UQ_Users_Username UNIQUE (Username);
--add Constraint UL_Users_Usename_Length CHECK(LEN(Username)>0)



--alter table Users
----alter column [Password] VARCHAR(300) not null
--add constraint PL_Users_Password_Length Check(Len(Password) > 8)

--create or alter procedure RegisterUser
--	@Username VARCHAR(50),
--	@Password VARCHAR(100)
--AS
--BEGIN
--	IF NOT EXISTS (Select 1 from [Users] Where Username = @Username)
--	INSERT INTO [Users] Values (@Username, @Password)
--END


--EXEC RegisterUser @Username = 'test', @Password = 'xyz';

--sp_help RegisterUser

--create or alter procedure GetHashedPassword
--	@UserName varchar(100)
--as
--begin
--	select Password from Users where Username = @UserName;
--end;

--GetHashedPassword @UserName = 'rnaikwadi'

--create or alter procedure GetUserId
--	@UserName varchar(100)
--As
--BEGIN
--	select UserId from Users where Username = @UserName;
--END;

--delete from Expenses;
--delete from Users;

/*
username - rnaikwadi
password - 10#Hammer
*/

--create or alter procedure GetExpenseById
--	@ExpenseId INT
--AS
--BEGIN
--	Select * FROM Expenses WHERE ExpenseId = @ExpenseId;
--END

--GetExpenseById 11;

--create or alter procedure UpdateExpenseById
--	@ExpenseId INT,
--	@Title VARCHAR(100),
--	@Desc VARCHAR(300),
--	@Amount DECIMAL(12, 2)
--AS
--BEGIN
--	UPDATE Expenses
--	SET
--		Title = @Title,
--		[Desc] = @Desc,
--		Amount = @Amount
--	WHERE
--		ExpenseId = @ExpenseId
--END