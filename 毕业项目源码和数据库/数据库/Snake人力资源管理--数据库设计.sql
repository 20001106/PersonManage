--创建数据库
create database PersonManagement

use PersonManagement

if Exists(select * from sysobjects where name='AdminT')
drop table AdminT
go
--创建管理员表
create table AdminT(
	ID int primary key identity(1,1),
	LoginName nvarchar(50) not null,--登录名
	LoginPwd nvarchar(50) not null--登录密码
)

if Exists(select * from sysobjects where name='Train')
drop table Train
go
--创建培训表（Train）
create table Train(
	ID int primary key identity(1,1),--培训ID
	Topic nvarchar(50) not null,--培训主题
	StartTime dateTime not null,--开始时间
	EndTime dateTime not null,--结束时间
	Site nvarchar(50) not null,--培训地点
	Number nvarchar(100) not null--参与人员
)

if Exists(select * from sysobjects where name='Department')
drop table Department
go
--创建部门表(Department)
create table Department(
	ID int primary key identity(100,1),--部门ID
	Name nvarchar(50) not null,--部门名称
	CreateTime DateTime not null,--创建时间
	Remark nvarchar(200),--备注
	BasicPay money not null--基本薪资
)

if Exists(select * from sysobjects where name='Employment')
drop table Employment
go
--创建应聘人员信息表（Employment）
create table Employment(
	ID int primary key identity(1,1),--编号
	Name nvarchar(50) not null,--姓名
	Sex char(2) not null,--性别
	Age int not null,--年龄
	IDCard nvarchar(50) not null,--身份证
	Address nvarchar(100) not null,--现住地址
	Native_place nvarchar(50) not null,--籍贯
	Phone nvarchar(11) not null,--电话号码
	Email nvarchar(50) not null,--邮箱
	DptID int foreign key references Department(ID) not null,--外键，部门表ID
	Diploma nvarchar(50) not null,--员工学历
	Major nvarchar(50) not null,--所学专业
	Remark nvarchar(200),--备注
	WorkExper nvarchar(50) not null,--工作经验
	State int Default('0') not null--录用状态(0:未录用，1：已录用)
)

if Exists(select * from sysobjects where name='Person')
drop table Person
go
--创建员工表（Person）
create table Person(
	ID int primary key identity(1000,1),--员工编号
	Name nvarchar(50) not null,--员工姓名
	Sex char(2) not null,--员工性别
	Age int not null,--员工年龄
	IDCard nvarchar(50) not null,--员工身份证
	Address nvarchar(100) not null,--现住地址
	Native_place nvarchar(50) not null,--籍贯
	Phone nvarchar(11) not null,--电话号码
	Email nvarchar(50) not null,--邮箱
	DptID int foreign key references Department(ID) not null,--外键，部门表ID
	Diploma nvarchar(50) not null,--员工学历
	Major nvarchar(50) not null,--所学专业
	Remark nvarchar(200)--备注
)

if Exists(select * from sysobjects where name='Attendance')
drop table Attendance
go
--创建考勤表（Attendance）
create table Attendance(
	ID int primary key identity(1,1),--考勤ID
	PersonID int foreign key references Person(ID) not null,--外键,员工表ID
	TadayTime date not null,--当日日期
	StartTime datetime not null,--上班时间
	EndTime datetime not null,--下班时间
)

if Exists(select * from sysobjects where name='Reward')
drop table Reward
go
--创建奖惩表（Reward）
create table Reward(
	ID int primary key identity(1,1),--奖惩ID
	PersonID int foreign key references Person(ID) not null,--外键,员工表ID
	Topic nvarchar(50) not null,--奖惩内容
	RewardType char(4) not null,--奖惩类型
	RewardTime datetime not null,--奖惩时间
	RewardGift nvarchar(50) not null--奖惩礼物（奖励或惩罚）
)

if Exists(select * from sysobjects where name='Pay')
drop table Pay
go
--创建薪资表（Pay）
create table Pay(
	ID int primary key identity(1,1),--薪资ID
	PersonID int foreign key references Person(ID) not null,--外键,员工表ID
	OverTime date not null,--结算薪资时间
	AttPay money not null,--考勤费
	OtherPay money not null--其它费
)

--插入管理员表数据
insert into AdminT Values('sansan','123321')
insert into AdminT Values('admin','111111')

--插入部门表数据
insert into Department Values('技术部','2020-05-10','管理技术','300')
insert into Department Values('财务部','2020-05-15','管理财务','200')
insert into Department Values('人事部','2020-05-20','管理人员','100')

--插入员工表数据
insert into Person Values('张三','男','20','400000200002023320','虚拟市虚拟区虚拟路22号','湖南省永州市','15273572761','15273572761@163.com','101','大专','会计','喜欢打球')
insert into Person Values('李琼','女','19','400000200106013321','虚拟市虚拟区虚拟路55号','湖南省长沙市','15273572762','15273572762@163.com','101','大专','会计','听歌')
insert into Person Values('王五','男','18','400000200212023322','虚拟市虚拟区虚拟路33号','湖南省岳阳市','15273572763','15273572763@163.com','100','本科','软件技术','交朋友')
insert into Person Values('赵茜','女','21','400000199911113323','虚拟市虚拟区虚拟路11号','湖南省益阳市','15273572764','15273572764@163.com','100','本科','软件技术','跳舞，敲代码')
insert into Person Values('陈七','男','20','400000200008153324','虚拟市虚拟区虚拟路44号','湖南省郴州市','15273572765','15273572765@163.com','102','大专','资源管理','无')

--插入培训表数据
insert into Train Values('提升相关技术','2020-05-21 12:00:00','2020-05-22 22:00:00','虚拟室101号','王五,赵茜')
insert into Train Values('人员的相关管理','2020-05-20 09:00:00','2020-05-20 22:00:00','虚拟室101号','陈七')

--插入应聘人员表数据
insert into Employment Values('张思','男','19','400000200103123230','虚拟市虚拟区虚拟路01号','湖南省怀化市','15273572262','15273572262@163.com','102','大专','资源管理','结交朋友','无','0')
insert into Employment Values('李前','女','18','400000200207113231','虚拟市虚拟区虚拟路08号','湖南省衡阳市','15273572268','15273572268@163.com','101','大专','会计','听歌','一年会计管理','0')
insert into Employment Values('王七','男','20','400000200011043232','虚拟市虚拟区虚拟路10号','湖南省虚拟市','15273572222','15273572222@163.com','100','本科','软件技术','敲代码','两年编程','0')

--插入考勤表数据
insert into Attendance Values('1000','2020-05-22','2020-05-22 09:00:00','2020-05-22 22:00:00')
insert into Attendance Values('1001','2020-05-22','2020-05-22 08:00:00','2020-05-22 22:00:00')
insert into Attendance Values('1004','2020-05-22','2020-05-22 09:00:00','2020-05-22 20:00:00')
insert into Attendance Values('1003','2020-05-23','2020-05-22 09:00:00','2020-05-22 22:00:00')

--插入奖惩表数据
insert into Reward Values('1003','拾金不昧','奖励','2020-05-24 10:00:00','奖励：布娃娃一个')
insert into Reward Values('1000','上班迟到','惩罚','2020-05-25 10:00:00','惩罚：100元，充公')
insert into Reward Values('1004','帮助其他人收拾桌面','奖励','2020-05-24 10:00:00','奖励：大份零食')

--插入薪资表数据
insert into Pay Values('1000','2020-05-22','10','20')
insert into Pay Values('1001','2020-05-22','10','20')
insert into Pay Values('1002','2020-05-22','0','20')
insert into Pay Values('1003','2020-05-22','0','20')
insert into Pay Values('1004','2020-05-22','10','20')
insert into Pay Values('1000','2020-05-23','0','20')
insert into Pay Values('1001','2020-05-23','0','20')
insert into Pay Values('1002','2020-05-23','0','20')
insert into Pay Values('1003','2020-05-23','0','20')
insert into Pay Values('1004','2020-05-23','0','20')

--查询
select * from AdminT
select * from Train
select * from Employment
select * from Department
select * from Person
select * from Attendance
select * from Reward
select * from Pay