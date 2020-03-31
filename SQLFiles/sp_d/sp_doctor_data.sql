if object_id('dbo.sp_doctor_data')is not null
	drop procedure dbo.sp_doctor_data
go

create procedure dbo.sp_doctor_data
	@Mode int = 0,
	@id int null
with encryption
as 
begin
	set nocount on
	/*
	Mode => 0 get a list of Doctors
			 => 1 get Single record
			 => 2 delete doctor 
	*/ 

	if @Mode = 0
	begin
		select * from Doctors
		return
	end

	if @Mode = 1
	begin
		select * from Doctors
		where id  = @id
		return
	end

	if @Mode = 2
	begin
		begin try
			begin tran
				delete Doctors where id = @id
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

grant exec on dbo.sp_doctor_data to public
go 