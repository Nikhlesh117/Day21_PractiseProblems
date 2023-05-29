Use Address_Book;
create table Student_ADOdotNET
(
	ID int Identity(1,1) Primary key Not Null,
	FirstName Varchar(225),
	LastName Varchar(225),
	Address Varchar(225),
	City Varchar(225),
	State Varchar(225),
	PostalCode int,
	Phone Bigint,
	Email Varchar(225)
);

select * from Student_ADOdotNET ;


CREATE PROCEDURE SPAddingData(
@FirstName Varchar(225),
@LastName Varchar(225),
@Address Varchar(225),
@City Varchar(225),
@State Varchar(225),
@PostalCode int,
@Phone Bigint,
@Email Varchar(100)
)
AS BEGIN
INSERT INTO Student_ADOdotNET (FirstName,LastName, Address, City, State, PostalCode,Phone,Email) 
values(@FirstName,@LastName,@Address, @City, @State, @PostalCode,@Phone, @Email)
END

CREATE PROCEDURE SPGetAllData
AS BEGIN
select * from Student_ADOdotNET
END

CREATE PROCEDURE SPUpdateData
@FirstName Varchar(225),
@LastName Varchar(225)
AS BEGIN
Update Student_ADOdotNET SET  FirstName = @FirstName where LastName = @LastName
END

CREATE PROCEDURE SPDeleteData
@FirstName Varchar(225),
@LastName Varchar(225)
AS BEGIN
DELETE FROM Student_ADOdotNET WHERE FirstName = @FirstName and LastName = @LastName
END