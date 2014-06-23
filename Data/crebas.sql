create database CRM
go

/*==============================================================*/
/* Table: Activitys                                             */
/*==============================================================*/
create table Activitys (
   ActID                int                  identity,
   CusID                char(14)             null,
   ActDate              datetime             null default getdate(),
   ActAdd               nvarchar(100)        null,
   ActTitle             nvarchar(100)        null,
   ActMemo              nvarchar(100)        null,
   ActDesc              nvarchar(max)        null,
   constraint PK_ACTIVITYS primary key (ActID)
)
go

/*==============================================================*/
/* Table: Chances                                               */
/*==============================================================*/
create table Chances (
   ChanID               int                  identity,
   ChanName             nvarchar(50)         null,
   ChanRate             int                  null,
   ChanLinkMan          nvarchar(50)         null,
   ChanLinkTel          varchar(50)          null,
   ChanTitle            nvarchar(500)        null,
   ChanDesc             nvarchar(2000)       null,
   ChanCreateMan        int                  null,
   ChanCreateDate       datetime             null default getdate(),
   ChanDueMan           int                  null,
   ChanDueDate          datetime             null,
   ChanState            int                  null,
   ChanError            nvarchar(500)        null,
   constraint PK_CHANCES primary key (ChanID)
)
go
/*==============================================================*/
/* Table: CustomLosts                                           */
/*==============================================================*/
create table CustomLosts (
   CLID                 int                  identity,
   CusID                char(14)             null,
   CLOrderDate          datetime             null,
   CLDate               datetime             null default getdate(),
   CLEnterDate          datetime             null,
   CLReason             nvarchar(500)        null,
   CLState              int                  null,
   constraint PK_CUSTOMLOSTS primary key (CLID)
)
go
/*==============================================================*/
/* Table: CustomServices                                        */
/*==============================================================*/
create table CustomServices (
   CSID                 int                  identity,
   STID                 int                  null,
   CusID                char(14)             null,
   CSTitle              nvarchar(100)        null,
   CSState              int                  null,
   CSDesc               nvarchar(max)        null,
   CSCreateID           int                  null,
   CSCreateDate         datetime             null,
   CSDueID              int                  null,
   CSDueDate            datetime             null,
   CSDeal               nvarchar(500)        null,
   CSDealDate           datetime             null,
   CSResult             nvarchar(500)        null,
   CSSatisfy            int                  null,
   constraint PK_CUSTOMSERVICES primary key (CSID)
)
go
/*==============================================================*/
/* Table: Customers                                             */
/*==============================================================*/
create table Customers (
   CusID                char(14)             not null,
   UserID               int                  null,
   CusName              nvarchar(50)         null,
   CusAddress           nvarchar(100)        null,
   CusZip               varchar(50)          null,
   CusFax               varchar(50)          null,
   CusWebsite           varchar(100)         null,
   CusLicenceNo         varchar(50)          null,
   CusChieftain         nvarchar(50)         null,
   CusBankroll          int                  null,
   CusTurnover          int                  null,
   CusBank              nvarchar(50)         null,
   CusBankNo            varchar(50)          null,
   CusLocalTaxNo        varchar(50)          null,
   CusNationalTaxNo     varchar(50)          null,
   CusDate              datetime             null default getdate(),
   CusState             int                  null,
   constraint PK_CUSTOMERS primary key (CusID)
)
go
/*==============================================================*/
/* Table: LinkMans                                              */
/*==============================================================*/
create table LinkMans (
   LMID                 int                  identity,
   CusID                char(14)             null,
   LMName               nvarchar(50)         null,
   LMSex                char(2)              null,
   LMDuty               nvarchar(50)         null,
   LMMobileNo           varchar(50)          null,
   LMOfficeNo           varchar(50)          null,
   LMMemo               nvarchar(500)        null,
   constraint PK_LINKMANS primary key (LMID)
)
go
/*==============================================================*/
/* Table: Measures                                              */
/*==============================================================*/
create table Measures (
   MeID                 int                  identity,
   CLID                 int                  null,
   MeDate               datetime             null,
   MeDesc               nvarchar(max)        null,
   constraint PK_MEASURES primary key (MeID)
)
go

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders (
   OrderID              int                  identity,
   CusID                char(14)             null,
   OrderDate            datetime             not null,
   constraint PK_ORDERS primary key (OrderID)
)
go
/*==============================================================*/
/* Table: Plans                                                 */
/*==============================================================*/
create table Plans (
   PlanID               char(36)             not null,
   ChanID               int                  null,
   PlanDate             datetime             null default getdate(),
   PlanContent          nvarchar(1000)       null,
   PlanResultDate       datetime             null,
   PlanResult           nvarchar(1000)       null,
   constraint PK_PLANS primary key (PlanID)
)
go
/*==============================================================*/
/* Table: ServiceType                                           */
/*==============================================================*/
create table ServiceType (
   STID                 int                  identity,
   STName               nvarchar(50)         null,
   constraint PK_SERVICETYPE primary key (STID)
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserID               int                  identity,
   UserLName            varchar(50)          not null,
   UserLPWD             char(47)             not null,
   UserName             varchar(50)          not null,
   RoleID               int                  null,
   constraint PK_USERS primary key (UserID)
)
go

select * from Users

--密码统一为sa
insert into Users values('admin','123','张飞',1)
insert into Users values('bb','bb','李四',2)
insert into Users values('cc','cc','老大',2)
insert into Users values('dd','dd','林志玲',1)
insert into ServiceType values('咨询')
insert into ServiceType values('投诉')
insert into ServiceType values('建议')


select distinct * from chances

insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
insert into chances values('长沙华瑞',100,'邹校','13598001123','台式机电脑大批量采购意向','',1,getdate(),2,getdate(),1,'')
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
create view ChancesAllocation
as
	SELECT   distinct  dbo.Chances.ChanID, dbo.Chances.ChanName, dbo.Chances.ChanLinkMan, dbo.Chances.ChanLinkTel, dbo.Chances.ChanTitle, 
						  dbo.Chances.ChanCreateDate, dbo.Chances.ChanDueMan, dbo.Users.UserName
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
	declare @CustomerID varchar(20)    --新客户编号
	
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

select * from Customers
insert into Customers values('KH20130827001', 2, '好给力', '好给力', '好给力', '好给力', '好给力', '好给力', '好给力', 50, 100, '好给力', '好给力', '好给力', 'adfad', getdate(), 1)

select * from LinkMans
insert into LinkMans values('KH20130827001', '好给力', '男', '经理', '15876542345', '0731-98765678', '记的经常联系')

select * from Orders
insert into orders values('KH20130827001',getdate())

select * from Activitys
insert into activitys values('KH20130827001', getdate() , '咖啡厅', '签订合同', '商谈合同细节', '合同细节商谈成功，当天签订合同')


select * from plans where chanid=3 order by planresultdate desc

