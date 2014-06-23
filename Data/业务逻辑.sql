select distinct * from chances

insert into chances values('��ɳ����',100,'��У','13598001123','̨ʽ�����Դ������ɹ�����','',1,getdate(),2,getdate(),1,'')

update chances set ChanName='��ɳ����', ChanRate=10, ChanLinkMan='����', ChanLinkTel='15876543456', ChanTitle='̨ʽ�����Դ������ɹ�����', ChanDesc='���»���', ChanCreateMan=4, ChanCreateDate=getdate(), ChanState=1 where ChanID=10

--��ҳ
create proc PagingProc
	@tbName varchar(50),   --����
    @keyFile varchar(30),  --������
    @showFile varchar(100),--����
    @where varchar(200),   --����
    @orderBy varchar(100), --������
    @pIndex  int,          --��ǰҳ
    @pSize   int           --ÿҳ��С
as
	--�����ֲ�����
	declare @sql varchar(2000) --��ҳsql
	declare @start varchar(10)    --��ʼֵ
	declare @end varchar(10)      --����ֵ
begin
	--�ж�where����
	if (isnull(@where,'') != '')
		set @where = ' where ' + @where

    --�ж�orderby
	if (isnull(@orderby,'') != '')
		set @orderby = ' order by ' + @orderby


	set @start = convert(varchar(10),(@pIndex -1)* @pSize + 1)
	set @end = convert(varchar(10),@pIndex * @pSize)

	set @sql = 'select * from(select row_number() over(order by '
				+ @keyFile +') as rnum,'
				+ @showFile +' from ' 
				+ @tbName + ' ' 
				+ @where + ' ) t where rnum between ' 
				+ @start +' and ' 
				+ @end + ' ' 
				+ @orderBy
	exec (@sql)
end

exec PagingProc 'chances','chanID','*','','chanID',1,10;

--�������ۻ��������ͼ
alter view ChancesAllocation
as
	SELECT   distinct  dbo.Chances.ChanID, dbo.Chances.ChanName, dbo.Chances.ChanLinkMan, dbo.Chances.ChanLinkTel, dbo.Chances.ChanTitle, 
						  dbo.Chances.ChanCreateDate, dbo.Chances.ChanDueMan, dbo.Users.UserName ,dbo.Chances.ChanState
	FROM         dbo.Chances inner JOIN
						  dbo.Users 
				 on dbo.Chances.ChanCreateMan=dbo.Users.userid
go

select * from chancesallocation

--�������ۻ����������ͼ
create view ChancesAllocation_ChanDueMan
as
	SELECT   distinct   dbo.Users.UserName, dbo.Chances.ChanDueMan
	FROM         dbo.Chances right JOIN
						  dbo.Users
						  on dbo.Chances.ChanDueMan=dbo.Users.userid
						  where dbo.Users.RoleID <> 2
go

select * from ChancesAllocation_ChanDueMan
select * from users
select * from chancesallocation

select * from chancesallocation where 1=1 and chanName like '%%' and chanLinkMan like '%%' and username like '%%' and chanDueMan like '%1%' 


select * from plans

PlanID, ChanID, PlanDate, PlanContent, PlanResultDate, PlanResult

--�����ͻ������ƻ���ͼ
create view view_Plans
as
	SELECT     dbo.Plans.PlanID, dbo.Plans.ChanID, dbo.Plans.PlanDate, dbo.Plans.PlanContent, dbo.Plans.PlanResultDate, dbo.Plans.PlanResult, dbo.Chances.ChanError,dbo.Chances.ChanState
	FROM         dbo.Chances INNER JOIN
						  dbo.Plans ON dbo.Chances.ChanID = dbo.Plans.ChanID

select * from view_plans

insert into Plans values('GUID'+convert(varchar(8),getdate(),112)+	case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
																 +	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
																 +	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
																 +	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
						,3,getdate(),'�绰��ϵ,�����Ӵ�',null,'')
select 'GUID'+convert(varchar(8),getdate(),112)+case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
			+	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
			+	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
			+	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
select * from plans
delete from plans

--������ȡ���ڵĴ洢����
create proc getDateProc
as
begin
		select case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
			+	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
			+	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
			+	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
end

exec getDateProc


--�������ɿͻ���ŵĴ洢����
alter proc pro_CustomerID
	@CustomerID varchar(20) output     --�������
as
begin
	declare @max varchar(20)		--���ͻ����
	declare @num int				--�����λ
	--declare @CustomerID varchar(20)    --�¿ͻ����
	
	--1. ����������Ŀͻ����
	select @max=max(CusID) from Customers where convert(varchar(10),CusDate,121) = convert(varchar(10),getdate(),121)

	--2. �������Ŀͻ����Ϊnull
	if (@max is null)
		begin
			set @CustomerID = 'KH' + convert(varchar(10),getdate(),112) + '001'	
		end
	else
		begin
			--3. ��ȡ�����λ����1
			--RIGHT (���ʽ, ��ȡ����) , ������varchar
			set @num = convert(int,right(@max,3))

			--��1001, ȡ����λ
			set @num = @num + 1001   --1002
			
			--�µĿͻ����
			set @CustomerID = 'KH' + convert(varchar(10),getdate(),112) + right(@num,3)

		end

		--��ӡ�ͻ����
		print @CustomerID
end

declare @CustomerID varchar(20)
exec pro_CustomerID @CustomerID output
select @CustomerID

--��ѯ�ͻ���Ϣ��
select * from Customers
insert into Customers values('KH20130827001', 2, '�ø���', '�ø���', '�ø���', '�ø���', '�ø���', '�ø���', '�ø���', 50, 100, '�ø���', '�ø���', '�ø���', 'adfad', getdate(), 1)
update Customers set CusAddress='����ʡ��ɳ��',CusZip='421000',CusFax='0731-89373222',CusWebsite='www.changshahuarui.com',CusLicenceNo='ZGHNCS89773212',CusChieftain='��ΰ',CusBankroll=100,CusTurnover=200,CusBank='��ɳ����',CusBankNo='6222 2343 3433 3223 332',CusLocalTaxNo='ZGHNCS8978436753',CusNationalTaxNo='ZGHNCS7854768945' where CusID='KH20130828001'
update Customers set CusState=2 where Cusid=''

--��ѯ��ϵ�˱�
select * from LinkMans
insert into LinkMans values('KH20130827001', '�ø���', '��', '����', '15876542345', '0731-98765678', '�ǵľ�����ϵ')
select * from LinkMans where cusid='KH20130827001'
select * from LinkMans where lmID=1


--��ѯ������
select * from Orders
insert into orders values('KH20130827001',getdate())

--��ѯ������¼��
select * from Activitys
insert into activitys values('KH20130827001', getdate() , '������', 'ǩ����ͬ', '��̸��ͬϸ��', '��ͬϸ����̸�ɹ�������ǩ����ͬ')
select * from activitys where cusid='KH20130827001'
delete from activitys where actid=2
update activitys set acydate=convert(datetime,'2013/8/28 ������ 0:00:00') where actid=1


--�����ͻ���Ϣ��ʾ��ͼ
alter view view_Customers
as
	SELECT     dbo.Customers.*, dbo.Users.UserName
	FROM         dbo.Customers INNER JOIN
						  dbo.Users ON dbo.Customers.UserID = dbo.Users.UserID
go

select * from view_Customers

insert into dbo.CustomLosts

select cusid,orderdate,getdate(),null,null,1 from dbo.Orders as a
where datediff(mm,
			   (select max(orderdate) from orders as b where a.orderid=b.orderid)
			   ,getdate())>6 and cusid not in(select cusid from dbo.CustomLosts)


--�ͻ���ʧ��
select * from CustomLosts
delete from customLosts where clid>=2
update customLosts set clstate=2 where (select count(*) from Measures where clid=customLosts.clid)>0 and clstate<>2
update customLosts set CLEnterDate=getdate(),CLReason=@CLReason where clid=@clid


--�����ͻ���ʧ��ͼ
create view view_CustomLosts
as
	SELECT     dbo.Customers.CusName, dbo.CustomLosts.*
	FROM         dbo.Customers INNER JOIN
						  dbo.CustomLosts ON dbo.Customers.CusID = dbo.CustomLosts.CusID
go

select * from view_CustomLosts

--��ʧ��ʩ��
select * from Measures
select * from Measures where clID=2

insert into measures values(13,getdate(),'dad')

--�����
select * from CustomServices

--�������ͱ�
select * from ServiceType

--����������ͼ
create view ViewCustomServices
as
	SELECT     dbo.CustomServices.*, dbo.ServiceType.STName, dbo.Customers.CusName, dbo.Users.UserName
	FROM         dbo.Customers INNER JOIN
						  dbo.CustomServices ON dbo.Customers.CusID = dbo.CustomServices.CusID INNER JOIN
						  dbo.ServiceType ON dbo.CustomServices.STID = dbo.ServiceType.STID INNER JOIN
						  dbo.Users ON dbo.Customers.UserID = dbo.Users.UserID

select * from ViewCustomServices






