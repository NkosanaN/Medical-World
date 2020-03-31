if object_id('dbo.sp_users_data')is not null
	drop procedure dbo.sp_users_data
go

create procedure dbo.sp_users_data
	@Mode int = 0,
	@id int = null,
	@FirstName varchar(20) = null,
	@Password varchar(100)= null
with encryption
as 
begin
	set nocount on
	/*
	Mode => 0 get a list of users
			 => 1 get Single users - > login 
			 => 2 delete users 
	*/ 

	if @Mode = 0
	begin
			select * from User_1
		return
	end

	if @Mode = 1
	begin
			select * from User_1
			where FirstName  = @FirstName and Password = @Password
		return
	end

	if @Mode = 2
	begin
		begin try
			begin tran
				delete User_1 where User_1.UserId = @id
				commit
				select 'ok' as Result ,'' as Msg
			return
		end try

		begin catch
			if @@TRANCOUNT > 0
			rollback tran
			select 'ERR' as Result, error_message() as Msg
		end catch

	end
end
go