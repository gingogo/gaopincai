update Category set Enabled = 1 where Id in(101,106,144,145,147,162,164,165,167,185);

DBCC SHRINKFILE (LotteryChongQSSC_Log, 1);
DBCC SHRINKFILE (LotteryJiangXSSC_Log, 1);
DBCC SHRINKFILE (LotteryChongQ115_Log, 1);
DBCC SHRINKFILE (LotteryGuangD115_Log, 1);
DBCC SHRINKFILE (LotteryJiangX115_Log, 1);
DBCC SHRINKFILE (LotteryShanD115_Log, 1);
DBCC SHRINKFILE (Lottery3D_Log, 1);
DBCC SHRINKFILE (LotteryPL35_Log, 1);
DBCC SHRINKFILE (LotteryShangHSSL_Log, 1);
DBCC SHRINKFILE (LotteryHuN12X3_Log, 1);

RESTORE DATABASE [RawLotteryData] FROM DISK = N'完全备份文件名' WITH NORECOVERY,  REPLACE
RESTORE DATABASE DB 
   FROM DISK = 'g:\back.Bak'
   WITH MOVE 'DBTest' TO 'E:\Program Files\Microsoft SQL Server2005\Data\DB.mdf', 
   MOVE 'DBTest_log' TO 'E:\Program Files\Microsoft SQL Server2005\Data\DB_log.ldf',
STATS = 10, REPLACE
GO

update DwNumber set Date = Replace(CONVERT(varchar(10),created,120),'-','');

drop table dbo.DwACSpan;
drop table dbo.DwDanShuangSpan ;
drop table  dbo.DwDaXiaoSpan;
drop table  dbo.DwHeSpan;
drop table  dbo.DwHeWeiSpan;
drop table  dbo.DwJiSpan;
drop table   dbo.DwJiWeiSpan;
drop table    dbo.DwKuaDuSpan;
drop table   dbo.DwLu012Span;
drop table   dbo.DwZiHeSpan;
drop table dbo.DwPeroidSpan;

Alter table DmC2 add [NumberType] [varchar](2) NULL;
Alter table DmC3 add [NumberType] [varchar](3) NULL;
Alter table DmC4 add [NumberType] [varchar](3) NULL;
Alter table DmC5 add [NumberType] [varchar](3) NULL;
Alter table DmDX add [NumberType] [varchar](2) NULL;
Alter table DmP2 add [NumberType] [varchar](2) NULL;
Alter table DmP3 add [NumberType] [varchar](2) NULL;
Alter table DmP4 add [NumberType] [varchar](2) NULL;
Alter table DmP5 add [NumberType] [varchar](2) NULL;

ALTER TABLE dbo.DwPeroidSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwPeroidSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwPeroidSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwACSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwACSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwACSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwDanShuangSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwDanShuangSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwDanShuangSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwDaXiaoSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwDaXiaoSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwDaXiaoSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwHeSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwHeSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwHeSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwHeWeiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwHeWeiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwHeWeiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwJiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwJiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwJiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwJiWeiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwJiWeiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwJiWeiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwKuaDuSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwKuaDuSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwKuaDuSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwLu012Span DROP COLUMN P4Spans;
ALTER TABLE dbo.DwLu012Span DROP COLUMN C4Spans;
ALTER TABLE dbo.DwLu012Span DROP COLUMN P5Spans;

ALTER TABLE dbo.DwZiHeSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwZiHeSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwZiHeSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwDaXiaoBiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwDaXiaoBiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwDaXiaoBiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwZiHeBiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwZiHeBiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwZiHeBiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwDanShuangBiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwDanShuangBiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwDanShuangBiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwLu012BiSpan DROP COLUMN P4Spans;
ALTER TABLE dbo.DwLu012BiSpan DROP COLUMN C4Spans;
ALTER TABLE dbo.DwLu012BiSpan DROP COLUMN P5Spans;

ALTER TABLE dbo.DwNumber DROP COLUMN P4;
ALTER TABLE dbo.DwNumber DROP COLUMN C4;


ALTER TABLE DmC2 ALTER COLUMN [NumberType] CHAR(2);
ALTER TABLE DmC3 ALTER COLUMN [NumberType] CHAR(3);
ALTER TABLE DmC33 ALTER COLUMN [NumberType] CHAR(3);
ALTER TABLE DmC36 ALTER COLUMN [NumberType] CHAR(3);
ALTER TABLE DmC4 ALTER COLUMN [NumberType] CHAR(4);
ALTER TABLE DmC5 ALTER COLUMN [NumberType] CHAR(5);
ALTER TABLE DmDx ALTER COLUMN [NumberType] CHAR(2);
ALTER TABLE DmP2 ALTER COLUMN [NumberType] CHAR(2);
ALTER TABLE DmP3 ALTER COLUMN [NumberType] CHAR(2);
ALTER TABLE DmP4 ALTER COLUMN [NumberType] CHAR(2);
ALTER TABLE DmP5 ALTER COLUMN [NumberType] CHAR(2);

update DmC2 set [NumberType] ='C2';
update DmC3 set [NumberType] ='C3';
update DmC33 set [NumberType] ='C33';
update DmC36 set [NumberType] ='C36';
update DmC4 set [NumberType] ='C4';
update DmC5 set [NumberType] ='C5';
update DmDX set [NumberType] ='DX';
update DmP2 set [NumberType] ='P2';
update DmP3 set [NumberType] ='P3';
update DmP4 set [NumberType] ='P4';
update DmP5 set [NumberType] ='P5';

update DwPeroidSpan set D1Spans = t2.Spans from DwD1PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P2Spans = t2.Spans from DwP2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P3Spans = t2.Spans from DwP3PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P4Spans = t2.Spans from DwP4PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P5Spans = t2.Spans from DwP5PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C2Spans = t2.Spans from DwC2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C3Spans = t2.Spans from DwC3PeroidSpan t2 where DwPeroidSpan.P = t2.P;



update DmP5 set
ZiHe = t2.ZiHe,
ZiCnt = t2.ZiCnt,
HeCnt = t2.HeCnt,
Ji = t2.Ji,
JiWei = t2.JiWei,
KuaDu = t2.KuaDu,
AC = t2.AC
from LotteryChongQSSC.dbo.DmP5 t2 where DmP5.Id = t2.Id;

truncate table DwC5C2Span;
truncate table DwC5C3Span;
truncate table DwC5C4Span;
truncate table DwC5C6Span;
truncate table DwC5C7Span;
truncate table DwC5C8Span;

truncate table dbo.DwPeroidSpan;
truncate table dbo.DwACSpan;
truncate table dbo.DwDanShuangSpan ;
truncate table  dbo.DwDaXiaoSpan;
truncate table  dbo.DwHeSpan;
truncate table  dbo.DwHeWeiSpan;
truncate table  dbo.DwJiSpan;
truncate table  dbo.DwJiWeiSpan;
truncate table  dbo.DwKuaDuSpan;
truncate table  dbo.DwLu012Span;
truncate table  dbo.DwZiHeSpan;
truncate table dbo.DwDaXiaoBiSpan;
truncate table dbo.DwZiHeBiSpan;
truncate table  dbo.DwDanShuangBiSpan;
truncate table  dbo.DwLu012BiSpan;

select count(*) Peroids from dbo.DwNumber;
select count(*) Peroids from dbo.DwPeroidSpan;
select count(*) Peroids from  dbo.DwACSpan;
select count(*) Peroids from  dbo.DwDanShuangSpan ;
select count(*) Peroids from   dbo.DwDaXiaoSpan;
select count(*) Peroids from   dbo.DwHeSpan;
select count(*) Peroids from   dbo.DwHeWeiSpan;
select count(*) Peroids from   dbo.DwJiSpan;
select count(*) Peroids from   dbo.DwJiWeiSpan;
select count(*) Peroids from  dbo.DwKuaDuSpan;
select count(*) Peroids from   dbo.DwLu012Span;
select count(*) Peroids from   dbo.DwZiHeSpan;
select count(*) Peroids from  dbo.DwDaXiaoBiSpan;
select count(*) Peroids from  dbo.DwZiHeBiSpan;
select count(*) Peroids from   dbo.DwDanShuangBiSpan;
select count(*) Peroids from   dbo.DwLu012BiSpan;

select Max(P) P from dbo.DwNumber;
select Max(P) P from dbo.DwPeroidSpan;
select Max(P) P from  dbo.DwACSpan;
select Max(P) P from  dbo.DwDanShuangSpan ;
select Max(P) P from   dbo.DwDaXiaoSpan;
select Max(P) P from   dbo.DwHeSpan;
select Max(P) P from   dbo.DwHeWeiSpan;
select Max(P) P from   dbo.DwJiSpan;
select Max(P) P from   dbo.DwJiWeiSpan;
select Max(P) P from  dbo.DwKuaDuSpan;
select Max(P) P from   dbo.DwLu012Span;
select Max(P) P from   dbo.DwZiHeSpan;
select Max(P) P from  dbo.DwDaXiaoBiSpan;
select Max(P) P from  dbo.DwZiHeBiSpan;
select Max(P) P from   dbo.DwDanShuangBiSpan;
select Max(P) P from   dbo.DwLu012BiSpan;

update DmCategory  set DownIntervals = 6 where Id in(145,147,162,164,165);

insert into DmDx select * from LotteryChongQSSC.dbo.DmDx;
insert into DmC2 select * from LotteryChongQSSC.dbo.DmC2;
insert into DmC3 select * from LotteryChongQSSC.dbo.DmC3;
insert into DmC33 select * from LotteryChongQSSC.dbo.DmC33;
insert into DmC36 select * from LotteryChongQSSC.dbo.DmC36;
insert into DmP2 select * from LotteryChongQSSC.dbo.DmP2;
insert into DmP3 select * from LotteryChongQSSC.dbo.DmP3;

SELECT tmp.ruletype, 
       tmp.numbertype, 
       tmp.dimension, 
       tmp.numberid, 
       tmp.peroidcount, 
       '1' AS Nums, 
       tmp.actualtimes, 
       tmp.currentspans, 
       tmp.maxspans, 
       t2.d1spans AS LastSpans, 
       tmp.avgspans, 
       t3.probability, 
       t3.prize, 
       t3.amount 
FROM   (SELECT '11X5'                          AS RuleType, 
               'D1'                            AS NumberType, 
               'Peroid'                        AS Dimension, 
               t1.d1                           AS NumberId, 
               Max(t1.p)                       AS P, 
               (SELECT Count(*) 
                FROM   dwnumber)               AS PeroidCount, 
               Count(*)                        AS ActualTimes, 
               (SELECT Count(*) 
                FROM   dwnumber) - Max(t1.seq) AS CurrentSpans, 
               Max(t2.d1spans)                 AS MaxSpans, 
               Avg(CONVERT(FLOAT, t2.d1spans)) AS AvgSpans 
        FROM   dwnumber t1, 
               dwperoidspan t2, 
               dmdx t3 
        WHERE  t1.p = t2.p 
               AND t1.d1 = t3.id 
               AND t3.numbertype = 'DX' 
        GROUP  BY t1.d1) AS tmp, 
       dwperoidspan t2, 
       lottery.dbo.numbertype t3 
WHERE  tmp.p = t2.p 
       AND tmp.numbertype = t3.code 
       AND tmp.ruletype = t3.ruletype 
ORDER  BY tmp.currentspans DESC 

Alter table DmC2 add [DaXiaoBi] [char](3) NULL;
Alter table DmC2 add [ZiHeBi] [char](3) NULL;
Alter table DmC2 add [DanShuangBi] [char](3) NULL;
Alter table DmC2 add [Lu012Bi] [char](5) NULL;

Alter table DmC3 add [DaXiaoBi] [char](3) NULL;
Alter table DmC3 add [ZiHeBi] [char](3) NULL;
Alter table DmC3 add [DanShuangBi] [char](3) NULL;
Alter table DmC3 add [Lu012Bi] [char](5) NULL;

Alter table DmDX add [DaXiaoBi] [char](3) NULL;
Alter table DmDX add [ZiHeBi] [char](3) NULL;
Alter table DmDX add [DanShuangBi] [char](3) NULL;
Alter table DmDX add [Lu012Bi] [char](5) NULL;

Alter table DmP2 add [DaXiaoBi] [char](3) NULL;
Alter table DmP2 add [ZiHeBi] [char](3) NULL;
Alter table DmP2 add [DanShuangBi] [char](3) NULL;
Alter table DmP2 add [Lu012Bi] [char](5) NULL;

Alter table DmP3 add [DaXiaoBi] [char](3) NULL;
Alter table DmP3 add [ZiHeBi] [char](3) NULL;
Alter table DmP3 add [DanShuangBi] [char](3) NULL;
Alter table DmP3 add [Lu012Bi] [char](5) NULL;

Alter table DmC4 add [DaXiaoBi] [char](3) NULL;
Alter table DmC4 add [ZiHeBi] [char](3) NULL;
Alter table DmC4 add [DanShuangBi] [char](3) NULL;
Alter table DmC4 add [Lu012Bi] [char](5) NULL;

Alter table DmC5 add [DaXiaoBi] [char](3) NULL;
Alter table DmC5 add [ZiHeBi] [char](3) NULL;
Alter table DmC5 add [DanShuangBi] [char](3) NULL;
Alter table DmC5 add [Lu012Bi] [char](5) NULL;

Alter table DmP4 add [DaXiaoBi] [char](3) NULL;
Alter table DmP4 add [ZiHeBi] [char](3) NULL;
Alter table DmP4 add [DanShuangBi] [char](3) NULL;
Alter table DmP4 add [Lu012Bi] [char](5) NULL;
	
Alter table DmP5 add [DaXiaoBi] [char](3) NULL;
Alter table DmP5 add [ZiHeBi] [char](3) NULL;
Alter table DmP5 add [DanShuangBi] [char](3) NULL;
Alter table DmP5 add [Lu012Bi] [char](5) NULL;

Alter table DmG2 add [DaXiaoBi] [char](3) NULL;
Alter table DmG2 add [ZiHeBi] [char](3) NULL;
Alter table DmG2 add [DanShuangBi] [char](3) NULL;
Alter table DmG2 add [Lu012Bi] [char](5) NULL;

Alter table DmG3 add [DaXiaoBi] [char](3) NULL;
Alter table DmG3 add [ZiHeBi] [char](3) NULL;
Alter table DmG3 add [DanShuangBi] [char](3) NULL;
Alter table DmG3 add [Lu012Bi] [char](5) NULL;

Alter table DmZ2 add [DaXiaoBi] [char](3) NULL;
Alter table DmZ2 add [ZiHeBi] [char](3) NULL;
Alter table DmZ2 add [DanShuangBi] [char](3) NULL;
Alter table DmZ2 add [Lu012Bi] [char](5) NULL;

Alter table DmZ3 add [DaXiaoBi] [char](3) NULL;
Alter table DmZ3 add [ZiHeBi] [char](3) NULL;
Alter table DmZ3 add [DanShuangBi] [char](3) NULL;
Alter table DmZ3 add [Lu012Bi] [char](5) NULL;

Alter table DmC2 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmC2 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmC2 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmC2 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmC3 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmC3 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmC3 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmC3 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmDX ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmDX ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmDX ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmDX ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmP2 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmP2 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmP2 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmP2 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmP3 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmP3 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmP3 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmP3 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmC4 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmC4 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmC4 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmC4 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmC5 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmC5 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmC5 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmC5 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmP4 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmP4 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmP4 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmP4 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;
	
Alter table DmP5 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmP5 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmP5 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmP5 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmG2 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmG2 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmG2 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmG2 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmG3 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmG3 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmG3 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmG3 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmZ2 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmZ2 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmZ2 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmZ2 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;

Alter table DmZ3 ALTER COLUMN  [DaXiaoBi] [char](3) NOT NULL;
Alter table DmZ3 ALTER COLUMN  [ZiHeBi] [char](3) NOT NULL;
Alter table DmZ3 ALTER COLUMN  [DanShuangBi] [char](3) NOT NULL;
Alter table DmZ3 ALTER COLUMN  [Lu012Bi] [char](5) NOT NULL;


update DmDX set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmDX set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmDX set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmDX set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmC2 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmC2 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmC2 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmC2 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmC3 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmC3 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmC3 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmC3 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmC4 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmC4 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmC4 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmC4 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmC5 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmC5 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmC5 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmC5 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmP2 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmP2 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmP2 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmP2 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmP3 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmP3 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmP3 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmP3 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmP4 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmP4 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmP4 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmP4 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);

update DmP5 set DaXiaoBi= Convert(char(1),DaCnt) + '|' + Convert(char(1),XiaoCnt);
update DmP5 set ZiHeBi= Convert(char(1),ZiCnt) + '|' + Convert(char(1),HeCnt);
update DmP5 set DanShuangBi= Convert(char(1),DanCnt) + '|' + Convert(char(1),ShuangCnt);
update DmP5 set Lu012Bi= Convert(char(1),Lu0Cnt) + '|' + Convert(char(1),Lu1Cnt) + '|' + Convert(char(1),Lu2Cnt);


delete from dbo.DwPeroidSpan where P > 20121025060;
delete from dbo.DwACSpan where P > 20121025060;
delete from dbo.DwDanShuangSpan  where P > 20121025060;
delete from  dbo.DwDaXiaoSpan where P > 20121025060;
delete from dbo.DwHeSpan where P > 20121025060;
delete from dbo.DwHeWeiSpan where P > 20121025060;
delete from  dbo.DwJiSpan where P > 20121025060;
delete from  dbo.DwJiWeiSpan where P > 20121025060;
delete from  dbo.DwKuaDuSpan where P > 20121025060;
delete from  dbo.DwLu012Span where P > 20121025060;
delete from  dbo.DwZiHeSpan where P > 20121025060;
delete from dbo.DwDaXiaoBiSpan where P > 20121025060;
delete from dbo.DwZiHeBiSpan where P > 20121025060;
delete from  dbo.DwDanShuangBiSpan where P > 20121025060;
delete from  dbo.DwLu012BiSpan where P > 20121025060;
delete from  dbo.DwNumber where P > 20121025060;


