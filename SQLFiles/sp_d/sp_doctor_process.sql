if OBJECT_ID('dbo.sp_doctor_process','P') is not null
	drop procedure dbo.sp_doctor_process
go

create procedure dbo.sp_doctor_process
	@Mode int = 0,
	@id int = null,
	@Name varchar(20),
	@Age int ,
	@Surname varchar(20)
	
with encryption
as
begin
	set nocount on
	/*
	Modes:
	0 : create new doctors record
	1 : update doctor
	*/

	begin try
		
		begin tran
			
			if @Mode = 0
			begin
				insert Doctors
				(Name ,DateChange ,Age  ,Surname)
				values
				(@Name, GETDATE(), @Age, @Surname)
			end
			else
			if @Mode = 1
			begin
				update Doctors set
			  [Name] = @Name,
				[Surname] = @Surname,
				[Age] = @Age
				where [id] =@id 
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

grant exec on dbo.sp_doctor_process to public
go

