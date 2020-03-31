if OBJECT_ID('dbo.sp_users_process','P') is not null
	drop procedure dbo.sp_users_process
go

create procedure dbo.sp_users_process
	@Mode int = 0,
	@id int = null,
	@FirstName varchar(20),
	@LastName varchar(20),
	@Email varchar(100),
	@Password varchar(100),
	@DateOfBirth DATETIME	
with encryption
as
begin
	set nocount on
	/*
	Modes:
	0 : create new user record
	1 : update user
	*/
	begin try
		
		begin tran
			
			if @Mode = 0
			begin
			insert User_1
			(FirstName ,LastName , Email ,DateOfBirth , Password,TimeCreated)
			values
			(@FirstName, @LastName, @Email, @DateOfBirth,@Password,GETDATE())
			end
			else
			if @Mode = 1
			begin
				update User_1 set
			  [DateOfBirth] = @DateOfBirth,
				[Password] = @Password,
				[FirstName] = @FirstName,
				[LastName] = @LastName
				where UserId =@id 
			end

		commit tran
		select 'ok' as Result , '' as Msg
		return
	end try 

	begin catch
		if @@TRANCOUNT > 0
		rollback tran
		select 'ERR' as Result, ERROR_MESSAGE() as Msg
	end catch

end 
go

grant exec on dbo.sp_users_process to public
go
