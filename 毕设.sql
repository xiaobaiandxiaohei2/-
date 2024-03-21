create database Nursing
use Nursing

--管理员表
create table Admin
(
	ID int identity(1,1) primary key,		--ID
	Name nvarchar(50) not null,				--名称
	Phone varchar(50) not null,				--手机号
	Password varchar(50) not null,			--密码
	State char(1) check(State='1' or State='0') not null,		--状态,1.在职，0.离职
)
go

--老人表
create table Senior
(
	ID int identity(1,1) primary key,		--ID
	Name nvarchar(50) not null,				--名称
	IdentityCard varchar(18) not null,		--身份证
	Sex nvarchar(1) check(Sex='男' or Sex='女') not null,	--性别
	AvatarPath varchar(100) not null,		--头像
	Province nvarchar(20) not null,			--省
	City nvarchar(20) not null,				--市
	District nvarchar(20) not null,			--区
	Address nvarchar(50) not null,			--具体地址
	UnderlyingDisease nvarchar(100),		--基础病
	State char(1) check(State='0' or State='1') not null,	--0表示未入住,1表示已入住
)
go

--监护人表
create table Guardian(		
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
	IdentificationCard varchar(18) not null,	--身份证
	Password varchar(50) not null,				--密码
	Phone varchar(11) not null					--联系电话
)
go

--房间表
create table Room(			
	ID int IDENTITY(1,1) primary key,
	RoomNumber varchar(20) not null,			--房间号
	Remark nvarchar(100),						--备注
	State char(1) check(State='0' or State='1' or State='2' or State='3') not null,	--0.待维修，1.维修中，2.可入住 3.已满员
)
go

--护工表
create table Caregiver(	
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
	Sex nvarchar(1) check(Sex='男' or Sex='女') not null,		--性别		
	IdentificationCard varchar(18) not null,	--身份证
	WorkYears int not null,						--工作年限
	Grade int not null,							--护工级别
	AvatarPath varchar(100) not null,			--头像
	Remark nvarchar(100),						--备注
	State char(1) check(State='0' or State='1') not null,		--0.不在职，1.在职
)
go

--预约表
create table Booking(		
	ID int IDENTITY(1,1) primary key,
	WeChatUserID int references Guardian(ID) not null,			--监护人ID
	RoomID int references Room(ID) not null,					--房间ID
	StayTime datetime not null,					--入住时间
	BookingTime datetime not null,				--预约时间
	Name nvarchar(50) not null,					--联系人
	Phone varchar(11) not null,					--联系电话
	State char(1) check(State='0' or State='1' or State='2') not null,		--0.未审核，1.通过审核，2.未通过审核
	AuditTime datetime not null,				--审核时间
	AdminID int references Admin(ID) not null,	--审核人ID
	Remark nvarchar(100),						--备注
)
go

--入住记录表
create table HospitalizationRecord
(
	ID int identity(1,1) primary key,			--ID
	SeniorID int references Senior(ID) not null,--老人ID
	EnterTime datetime not null,				--入住时间
	ExitTime datetime,							--出院时间
	GuardianID int references Guardian(ID) not null,	--监护人ID
	RoomID int references Room(ID) not null,			--房间ID
	CaregiverID int references Caregiver(ID) not null,	--护工ID
)
go

--申请表
create table Application
(
	ID int identity(1,1) primary key,					--ID
	GuardianID int references Guardian(ID) not null,	--监护人ID
	SeniorID int references Senior(ID) not null,		--老人ID
	Type char(1) check(Type='1' or Type='2') not null,	--1表示外出申请，2表示出院申请
	OutTime datetime not null,							--外出时间或者出院时间
	BackTime datetime,									--外出返回时间
	State char(1) check(State='0' or State='1' or State='2') not null,	--0表示未处理，1表示已通过，2表示未通过
	AuditTime datetime not null,						--审核时间
	AdminID int references Admin(ID) not null,			--审核人ID
	Remark nvarchar(100),								--备注
)
go

--意见表
create table Suggestion
(
	ID int identity(1,1) primary key,				--ID
	GuardianID int references Guardian(ID) not null,--监护人ID
	Content nvarchar(100) not null,					--建议内容 
	Time dateTime not null,							--提交时间
)
go

--健康数据项目表
create table HealthDataItem
(
	ID int identity(1,1) primary key,				--ID
	Name nvarchar(50) not null,						--项目名称（体温，血压 ...）
	Weight int not null								--权重
)
go

--健康检查数据表
create table HealthCheckData
(
	ID int identity(1,1) primary key,			--ID
	SeniorID int references Senior(ID) not null,--老人ID
	CaregiverID int references Caregiver(ID) not null,	--护工ID
	CheckTime datetime not null,						--检查时间
	HealthDataItemID int references HealthDataItem(ID) not null,	--检查项目ID
	CheckData decimal(10,1) not null,					--检查数据值
)
go


select * from Admin where Password = '123' AND Phone='1234567890' ;

INSERT INTO Admin (Name, Phone, Password, State)
VALUES ('John Doe', '1234567890', '123', '1');

select * from Caregiver