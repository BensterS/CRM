select distinct * from chances

insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')

update chances set ChanName='长沙华瑞', ChanRate=10, ChanLinkMan='向经理', ChanLinkTel='15876543456', ChanTitle='台式机电脑大批量采购意向', ChanDesc='更新换代', ChanCreateMan=4, ChanCreateDate=getdate(), ChanState=1 where ChanID=10

--分页
create proc PagingProc
	@tbName varchar(50),   --表名
    @keyFile varchar(30),  --主键名
    @showFile varchar(100),--列名
    @where varchar(200),   --条件
    @orderBy varchar(100), --排序列
    @pIndex  int,          --当前页
    @pSize   int           --每页大小
as
	--声明局部变量
	declare @sql varchar(2000) --分页sql
	declare @start varchar(10)    --开始值
	declare @end varchar(10)      --结束值
begin
	--判断where条件
	if (isnull(@where,'') != '')
		set @where = ' where ' + @where

    --判断orderby
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

--创建销售机会分配视图
alter view ChancesAllocation
as
	SELECT   distinct  dbo.Chances.ChanID, dbo.Chances.ChanName, dbo.Chances.ChanLinkMan, dbo.Chances.ChanLinkTel, dbo.Chances.ChanTitle, 
						  dbo.Chances.ChanCreateDate, dbo.Chances.ChanDueMan, dbo.Users.UserName ,dbo.Chances.ChanState
	FROM         dbo.Chances inner JOIN
						  dbo.Users 
				 on dbo.Chances.ChanCreateMan=dbo.Users.userid
go

select * from chancesallocation

--创建销售机会分配人视图
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

--创建客户开发计划视图
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
						,3,getdate(),'电话联系,初步接触',null,'')
select 'GUID'+convert(varchar(8),getdate(),112)+case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
			+	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
			+	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
			+	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
select * from plans
delete from plans

--创建获取日期的存储过程
create proc getDateProc
as
begin
		select case when len(datename(hh,getdate()))=1 then '0'+datename(hh,getdate()) else datename(hh,getdate()) end
			+	case when len(datename(mi,getdate()))=1 then '0'+datename(mi,getdate()) else datename(mi,getdate()) end
			+	case when len(datename(ss,getdate()))=1 then '0'+datename(ss,getdate()) else datename(ss,getdate()) end
			+	case when len(datename(ms,getdate()))=1 then '00'+datename(ms,getdate()) when len(datename(ms,getdate()))=2 then '0'+datename(ms,getdate()) else datename(ms,getdate()) end
end

exec getDateProc


--创建生成客户编号的存储过程
alter proc pro_CustomerID
	@CustomerID varchar(20) output     --输出参数
as
begin
	declare @max varchar(20)		--最大客户编号
	declare @num int				--最后三位
	--declare @CustomerID varchar(20)    --新客户编号
	
	--1. 求出今天最大的客户编号
	select @max=max(CusID) from Customers where convert(varchar(10),CusDate,121) = convert(varchar(10),getdate(),121)

	--2. 如果今天的客户编号为null
	if (@max is null)
		begin
			set @CustomerID = 'KH' + convert(varchar(10),getdate(),112) + '001'	
		end
	else
		begin
			--3. 截取最后三位，加1
			--RIGHT (表达式, 截取个数) , 返回是varchar
			set @num = convert(int,right(@max,3))

			--加1001, 取后三位
			set @num = @num + 1001   --1002
			
			--新的客户编号
			set @CustomerID = 'KH' + convert(varchar(10),getdate(),112) + right(@num,3)

		end

		--打印客户编号
		print @CustomerID
end

declare @CustomerID varchar(20)
exec pro_CustomerID @CustomerID output
select @CustomerID

--查询客户信息表
select * from Customers
insert into Customers values('KH20130827001', 2, '好给力', '好给力', '好给力', '好给力', '好给力', '好给力', '好给力', 50, 100, '好给力', '好给力', '好给力', 'adfad', getdate(), 1)
update Customers set CusAddress='湖南省长沙市',CusZip='421000',CusFax='0731-89373222',CusWebsite='www.changshahuarui.com',CusLicenceNo='ZGHNCS89773212',CusChieftain='邹伟',CusBankroll=100,CusTurnover=200,CusBank='长沙银行',CusBankNo='6222 2343 3433 3223 332',CusLocalTaxNo='ZGHNCS8978436753',CusNationalTaxNo='ZGHNCS7854768945' where CusID='KH20130828001'
update Customers set CusState=2 where Cusid=''

--查询联系人表
select * from LinkMans
insert into LinkMans values('KH20130827001', '好给力', '男', '经理', '15876542345', '0731-98765678', '记的经常联系')
select * from LinkMans where cusid='KH20130827001'
select * from LinkMans where lmID=1


--查询订单表
select * from Orders
insert into orders values('KH20130827001',getdate())

--查询交往记录表
select * from Activitys
insert into activitys values('KH20130827001', getdate() , '咖啡厅', '签订合同', '商谈合同细节', '合同细节商谈成功，当天签订合同')
select * from activitys where cusid='KH20130827001'
delete from activitys where actid=2
update activitys set acydate=convert(datetime,'2013/8/28 星期三 0:00:00') where actid=1


--创建客户信息显示视图
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


--客户流失表
select * from CustomLosts
delete from customLosts where clid>=2
update customLosts set clstate=2 where (select count(*) from Measures where clid=customLosts.clid)>0 and clstate<>2
update customLosts set CLEnterDate=getdate(),CLReason=@CLReason where clid=@clid


--创建客户流失视图
create view view_CustomLosts
as
	SELECT     dbo.Customers.CusName, dbo.CustomLosts.*
	FROM         dbo.Customers INNER JOIN
						  dbo.CustomLosts ON dbo.Customers.CusID = dbo.CustomLosts.CusID
go

select * from view_CustomLosts

--流失措施表
select * from Measures
select * from Measures where clID=2

insert into measures values(13,getdate(),'dad')

--服务表
select * from CustomServices

--服务类型表
select * from ServiceType

--创建服务视图
create view ViewCustomServices
as
	SELECT     dbo.CustomServices.*, dbo.ServiceType.STName, dbo.Customers.CusName, dbo.Users.UserName
	FROM         dbo.Customers INNER JOIN
						  dbo.CustomServices ON dbo.Customers.CusID = dbo.CustomServices.CusID INNER JOIN
						  dbo.ServiceType ON dbo.CustomServices.STID = dbo.ServiceType.STID INNER JOIN
						  dbo.Users ON dbo.Customers.UserID = dbo.Users.UserID

select * from ViewCustomServices






