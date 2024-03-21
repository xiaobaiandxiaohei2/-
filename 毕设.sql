create database Nursing
use Nursing

--����Ա��
create table Admin
(
	ID int identity(1,1) primary key,		--ID
	Name nvarchar(50) not null,				--����
	Phone varchar(50) not null,				--�ֻ���
	Password varchar(50) not null,			--����
	State char(1) check(State='1' or State='0') not null,		--״̬,1.��ְ��0.��ְ
)
go

--���˱�
create table Senior
(
	ID int identity(1,1) primary key,		--ID
	Name nvarchar(50) not null,				--����
	IdentityCard varchar(18) not null,		--���֤
	Sex nvarchar(1) check(Sex='��' or Sex='Ů') not null,	--�Ա�
	AvatarPath varchar(100) not null,		--ͷ��
	Province nvarchar(20) not null,			--ʡ
	City nvarchar(20) not null,				--��
	District nvarchar(20) not null,			--��
	Address nvarchar(50) not null,			--�����ַ
	UnderlyingDisease nvarchar(100),		--������
	State char(1) check(State='0' or State='1') not null,	--0��ʾδ��ס,1��ʾ����ס
)
go

--�໤�˱�
create table Guardian(		
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
	IdentificationCard varchar(18) not null,	--���֤
	Password varchar(50) not null,				--����
	Phone varchar(11) not null					--��ϵ�绰
)
go

--�����
create table Room(			
	ID int IDENTITY(1,1) primary key,
	RoomNumber varchar(20) not null,			--�����
	Remark nvarchar(100),						--��ע
	State char(1) check(State='0' or State='1' or State='2' or State='3') not null,	--0.��ά�ޣ�1.ά���У�2.����ס 3.����Ա
)
go

--������
create table Caregiver(	
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(50) not null,
	Sex nvarchar(1) check(Sex='��' or Sex='Ů') not null,		--�Ա�		
	IdentificationCard varchar(18) not null,	--���֤
	WorkYears int not null,						--��������
	Grade int not null,							--��������
	AvatarPath varchar(100) not null,			--ͷ��
	Remark nvarchar(100),						--��ע
	State char(1) check(State='0' or State='1') not null,		--0.����ְ��1.��ְ
)
go

--ԤԼ��
create table Booking(		
	ID int IDENTITY(1,1) primary key,
	WeChatUserID int references Guardian(ID) not null,			--�໤��ID
	RoomID int references Room(ID) not null,					--����ID
	StayTime datetime not null,					--��סʱ��
	BookingTime datetime not null,				--ԤԼʱ��
	Name nvarchar(50) not null,					--��ϵ��
	Phone varchar(11) not null,					--��ϵ�绰
	State char(1) check(State='0' or State='1' or State='2') not null,		--0.δ��ˣ�1.ͨ����ˣ�2.δͨ�����
	AuditTime datetime not null,				--���ʱ��
	AdminID int references Admin(ID) not null,	--�����ID
	Remark nvarchar(100),						--��ע
)
go

--��ס��¼��
create table HospitalizationRecord
(
	ID int identity(1,1) primary key,			--ID
	SeniorID int references Senior(ID) not null,--����ID
	EnterTime datetime not null,				--��סʱ��
	ExitTime datetime,							--��Ժʱ��
	GuardianID int references Guardian(ID) not null,	--�໤��ID
	RoomID int references Room(ID) not null,			--����ID
	CaregiverID int references Caregiver(ID) not null,	--����ID
)
go

--�����
create table Application
(
	ID int identity(1,1) primary key,					--ID
	GuardianID int references Guardian(ID) not null,	--�໤��ID
	SeniorID int references Senior(ID) not null,		--����ID
	Type char(1) check(Type='1' or Type='2') not null,	--1��ʾ������룬2��ʾ��Ժ����
	OutTime datetime not null,							--���ʱ����߳�Ժʱ��
	BackTime datetime,									--�������ʱ��
	State char(1) check(State='0' or State='1' or State='2') not null,	--0��ʾδ����1��ʾ��ͨ����2��ʾδͨ��
	AuditTime datetime not null,						--���ʱ��
	AdminID int references Admin(ID) not null,			--�����ID
	Remark nvarchar(100),								--��ע
)
go

--�����
create table Suggestion
(
	ID int identity(1,1) primary key,				--ID
	GuardianID int references Guardian(ID) not null,--�໤��ID
	Content nvarchar(100) not null,					--�������� 
	Time dateTime not null,							--�ύʱ��
)
go

--����������Ŀ��
create table HealthDataItem
(
	ID int identity(1,1) primary key,				--ID
	Name nvarchar(50) not null,						--��Ŀ���ƣ����£�Ѫѹ ...��
	Weight int not null								--Ȩ��
)
go

--����������ݱ�
create table HealthCheckData
(
	ID int identity(1,1) primary key,			--ID
	SeniorID int references Senior(ID) not null,--����ID
	CaregiverID int references Caregiver(ID) not null,	--����ID
	CheckTime datetime not null,						--���ʱ��
	HealthDataItemID int references HealthDataItem(ID) not null,	--�����ĿID
	CheckData decimal(10,1) not null,					--�������ֵ
)
go


select * from Admin where Password = '123' AND Phone='1234567890' ;

INSERT INTO Admin (Name, Phone, Password, State)
VALUES ('John Doe', '1234567890', '123', '1');

select * from Caregiver