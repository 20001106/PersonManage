--�������ݿ�
create database PersonManagement

use PersonManagement

if Exists(select * from sysobjects where name='AdminT')
drop table AdminT
go
--��������Ա��
create table AdminT(
	ID int primary key identity(1,1),
	LoginName nvarchar(50) not null,--��¼��
	LoginPwd nvarchar(50) not null--��¼����
)

if Exists(select * from sysobjects where name='Train')
drop table Train
go
--������ѵ��Train��
create table Train(
	ID int primary key identity(1,1),--��ѵID
	Topic nvarchar(50) not null,--��ѵ����
	StartTime dateTime not null,--��ʼʱ��
	EndTime dateTime not null,--����ʱ��
	Site nvarchar(50) not null,--��ѵ�ص�
	Number nvarchar(100) not null--������Ա
)

if Exists(select * from sysobjects where name='Department')
drop table Department
go
--�������ű�(Department)
create table Department(
	ID int primary key identity(100,1),--����ID
	Name nvarchar(50) not null,--��������
	CreateTime DateTime not null,--����ʱ��
	Remark nvarchar(200),--��ע
	BasicPay money not null--����н��
)

if Exists(select * from sysobjects where name='Person')
drop table Person
go
--����Ա����Person��
create table Person(
	ID int primary key identity(1000,1),--Ա�����
	Name nvarchar(50) not null,--Ա������
	Sex char(2) not null,--Ա���Ա�
	Age int not null,--Ա������
	IDCard nvarchar(50) not null,--Ա�����֤
	Address nvarchar(100) not null,--��ס��ַ
	Native_place nvarchar(50) not null,--����
	Phone nvarchar(11) not null,--�绰����
	Email nvarchar(50) not null,--����
	DptID int foreign key references Department(ID) not null,--��������ű�ID
	Diploma nvarchar(50) not null,--Ա��ѧ��
	Major nvarchar(50) not null,--��ѧרҵ
	Remark nvarchar(200)--��ע
)

if Exists(select * from sysobjects where name='Attendance')
drop table Attendance
go
--�������ڱ�Attendance��
create table Attendance(
	ID int primary key identity(1,1),--����ID
	PersonID int foreign key references Person(ID) not null,--���,Ա����ID
	TadayTime date not null,--��������
	StartTime datetime not null,--�ϰ�ʱ��
	EndTime datetime not null,--�°�ʱ��
)

if Exists(select * from sysobjects where name='Reward')
drop table Reward
go
--�������ͱ�Reward��
create table Reward(
	ID int primary key identity(1,1),--����ID
	PersonID int foreign key references Person(ID) not null,--���,Ա����ID
	Topic nvarchar(50) not null,--��������
	RewardType char(4) not null,--��������
	RewardTime datetime not null,--����ʱ��
	RewardGift nvarchar(50) not null--�������������ͷ���
)

if Exists(select * from sysobjects where name='Pay')
drop table Pay
go
--����н�ʱ�Pay��
create table Pay(
	ID int primary key identity(1,1),--н��ID
	PersonID int foreign key references Person(ID) not null,--���,Ա����ID
	OverTime date not null,--����н��ʱ��
	AttPay money not null,--���ڷ�
	OtherPay money not null--������
)

if Exists(select * from sysobjects where name='A_P_Message')
drop table A_P_Message
go
--������Ϣ��(A_P_Message)
create table A_P_Message(
	ID int primary key identity(1,1),--��ϢID
	PersonID int foreign key references Person(ID) not null,--���,Ա����ID
	Message nvarchar(100) not null,--������Ϣ
	Reason nvarchar(50) not null,--ԭ��
	SendTime datetime not null,--����ʱ��
	State int Default('0') not null,--�ظ�״̬(0:δ�ظ���1���ѻظ�)
	ReplyMessage nvarchar(100) null,--�ظ���Ϣ
	ReplyTime datetime null,--�ظ�ʱ��
	ReplyAdmin nvarchar(50)--�ظ�����
)

if Exists(select * from sysobjects where name='UserT')
drop table UserT
go
--�����û���UserT��
create table UserT(
	ID int primary key identity(1,1),--�û�ID
	PersonID int null,--�����Ա����ID
	UserName nvarchar(50) not null,--�û���¼��
	UserPwd nvarchar(50) not null--�û���¼����
)

if Exists(select * from sysobjects where name='Employment')
drop table Employment
go
--����ӦƸ��Ա��Ϣ��Employment��
create table Employment(
	ID int primary key identity(1,1),--���
	Name nvarchar(50) not null,--����
	Sex char(2) not null,--�Ա�
	Age int not null,--����
	IDCard nvarchar(50) not null,--���֤
	Address nvarchar(100) not null,--��ס��ַ
	Native_place nvarchar(50) not null,--����
	Phone nvarchar(11) not null,--�绰����
	Email nvarchar(50) not null,--����
	DptID int not null,--���ű�ID
	UserID int not null,--�û���ID
	Diploma nvarchar(50) not null,--Ա��ѧ��
	Major nvarchar(50) not null,--��ѧרҵ
	Remark nvarchar(200),--��ע
	WorkExper nvarchar(50) not null,--��������
	State int Default('0') not null,--¼��״̬(0:δ¼�ã�1����¼��)
	DeleteRecord int Default('0') not null--¼��״̬(0:δɾ����1����ɾ��)
)

if Exists(select * from sysobjects where name='A_U_Message')
drop table A_U_Message
go
--�����û�¼����Ϣ��(A_U_Message)
create table A_U_Message(
	ID int primary key identity(1,1),--��ϢID
	EpmID int foreign key references Employment(ID) not null,--�����ӦƸ��Ա��ID
	UserID int foreign key references UserT(ID) not null,--�����ӦƸ��Ա��ID
	Topic nvarchar(100) not null--����
)

--�������Ա������
insert into AdminT Values('sansan','123321')
insert into AdminT Values('admin','111111')

--���벿�ű�����
insert into Department Values('������','2020-05-10','������','30')
insert into Department Values('����','2020-05-15','�������','20')
insert into Department Values('���²�','2020-05-20','������Ա','10')

--����Ա��������
insert into Person Values('����','��','20','400000200002023320','����������������·22��','����ʡ������','15273572761','15273572761@163.com','101','��ר','���','ϲ������')
insert into Person Values('����','Ů','19','400000200106013321','����������������·55��','����ʡ��ɳ��','15273572762','15273572762@163.com','101','��ר','���','����')
insert into Person Values('����','��','18','400000200212023322','����������������·33��','����ʡ������','15273572763','15273572763@163.com','102','����','�������','������')
insert into Person Values('����','Ů','21','400000199911113323','����������������·11��','����ʡ������','15273572764','15273572764@163.com','100','����','�������','���裬�ô���')
insert into Person Values('����','��','20','400000200008153324','����������������·44��','����ʡ������','15273572765','15273572765@163.com','102','��ר','��Դ����','��')
insert into Person Values('����','��','20','400000200011043232','����������������·10��','����ʡ��̶��','15273572222','15273572222@163.com','100','����','�������','��')

--������ѵ������
insert into Train Values('������ؼ���','2020-05-21 12:00:00','2020-05-22 22:00:00','������101��','����,����')
insert into Train Values('��Ա����ع���','2020-05-20 09:00:00','2020-05-20 22:00:00','������101��','����')

--���뿼�ڱ�����
insert into Attendance Values('1000','2020-05-22','2020-05-22 09:00:00','2020-05-22 22:00:00')
insert into Attendance Values('1001','2020-05-22','2020-05-22 08:00:00','2020-05-22 22:00:00')
insert into Attendance Values('1004','2020-05-22','2020-05-22 09:00:00','2020-05-22 20:00:00')
insert into Attendance Values('1003','2020-05-23','2020-05-22 09:00:00','2020-05-22 22:00:00')

--���뽱�ͱ�����
insert into Reward Values('1003','ʰ����','����','2020-05-24 10:00:00','������������һ��')
insert into Reward Values('1000','�ϰ�ٵ�','�ͷ�','2020-05-25 10:00:00','�ͷ���100Ԫ���乫')
insert into Reward Values('1004','������������ʰ����','����','2020-05-24 10:00:00','�����������ʳ')

--����н�ʱ�����
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

--������Ϣ������
insert into A_P_Message Values('1002','����������ţ����������²���','�����ⷽ��ļ�����','2020-05-26 10:00:00','1','׼������׼������Ŭ����','2020-05-27 10:00:00','sansan')
insert into A_P_Message Values('1001','����������ţ���������������','�����ⷽ��ļ�����','2020-05-28 10:00:00','0','','','')

--�����û�������
insert into UserT Values('1000','san','112233')
insert into UserT Values('1001','qiong','111111')
insert into UserT Values('1002','wu','333333')
insert into UserT Values('1003','qian','222222')
insert into UserT Values('1004','qi','666666')
insert into UserT Values('','si','222222')
insert into UserT Values('','liqian','888888')
insert into UserT Values('','wangqi','999999')
insert into UserT Values('','kaidi','696969')

--����ӦƸ��Ա������
insert into Employment Values('��˼','��','19','400000200103123230','����������������·01��','����ʡ������','15273572262','15273572262@163.com','102','6','��ר','��Դ����','�ύ����','��','0','0')
insert into Employment Values('��ǰ','Ů','18','400000200207113231','����������������·08��','����ʡ������','15273572268','15273572268@163.com','101','7','��ר','���','����','һ���ƹ���','0','0')
insert into Employment Values('����','��','20','400000200011043232','����������������·10��','����ʡ��̶��','15273572222','15273572222@163.com','100','8','����','�������','�ô���','������','1','0')

--�����û�¼����Ϣ������
insert into A_U_Message Values('3','8','��ϲ�㣬��ͨ��¼��')

--��ѯ
select * from AdminT
select * from Train
select * from Department
select * from Person
select * from Attendance
select * from Reward
select * from Pay
select * from A_P_Message
select * from UserT
select * from Employment
select * from A_U_Message

if Exists(select * from sysobjects where name='proc_pay')
drop proc proc_pay
go
create proc proc_pay
(
  @FindDate date
)
as
begin 
	select DAY(OverTime) ��,sum(AttPay+otherpay+d.BasicPay) �ܹ��� from pay a,Person p,Department d  where 
		a.PersonID = p.ID and p.DptID = d.ID and
		(YEAR(overTime) = year(@FindDate) and MONTH(overTime) = MONTH(@FindDate) )
		group by overtime
end
go

exec proc_pay  '2020-05-23'