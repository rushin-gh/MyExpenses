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

--select * from Expenses

--sp_help Users

--Create or alter procedure GetUserExpenses
--	@UserId INT
--AS
--BEGIN
--	Select Title, [Desc], Amount FROM Expenses where UserId = @UserId;
--END

--GetUserExpenses @UserId = 1;


--insert into Expenses values
--('Laundry', 'White shirt dry cleaning', 80, 1),
--('Iphone 16 Pro', '128 GB variant', 104000, 1),
--('Shine', 'BSIV', 80000, 1);
