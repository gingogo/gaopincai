DBCC SHRINKFILE (LotteryChongQSSC_Log, 1);
DBCC SHRINKFILE (LotteryGuangD115_Log, 1);
DBCC SHRINKFILE (LotteryJiangX115_Log, 1);
DBCC SHRINKFILE (LotteryJiangXSSC_Log, 1);
DBCC SHRINKFILE (LotteryShanD115_Log, 1);
DBCC SHRINKFILE (LotteryFC3D_Log, 1);
DBCC SHRINKFILE (LotteryPL35_Log, 1);

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

Alter table DmC2 add [NumberType] [varchar](6) NULL;
Alter table DmC3 add [NumberType] [varchar](6) NULL;
Alter table DmC33 add [NumberType] [varchar](6) NULL;
Alter table DmC36 add [NumberType] [varchar](6) NULL;
Alter table DmC4 add [NumberType] [varchar](6) NULL;
Alter table DmC5 add [NumberType] [varchar](6) NULL;
Alter table DmDX add [NumberType] [varchar](6) NULL;
Alter table DmP2 add [NumberType] [varchar](6) NULL;
Alter table DmP3 add [NumberType] [varchar](6) NULL;
Alter table DmP4 add [NumberType] [varchar](6) NULL;
Alter table DmP5 add [NumberType] [varchar](6) NULL;

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

update DmP5 set
ZiHe = t2.ZiHe,
ZiCnt = t2.ZiCnt,
HeCnt = t2.HeCnt,
Ji = t2.Ji,
JiWei = t2.JiWei,
KuaDu = t2.KuaDu,
AC = t2.AC
from LotteryChongQSSC.dbo.DmP5 t2 where DmP5.Id = t2.Id;

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

select count(*) from dbo.DwNumber;
select count(*) from dbo.DwPeroidSpan;
select count(*) from dbo.DwACSpan;
select count(*) from dbo.DwDanShuangSpan ;
select count(*) from dbo.DwDaXiaoSpan;
select count(*) from dbo.DwHeSpan;
select count(*) from dbo.DwHeWeiSpan;
select count(*) from dbo.DwJiSpan;
select count(*) from dbo.DwJiWeiSpan;
select count(*) from dbo.DwKuaDuSpan;
select count(*) from dbo.DwLu012Span;
select count(*) from dbo.DwZiHeSpan;

select max(p) P from dbo.DwNumber;
select max(p) P from dbo.DwPeroidSpan;
select max(p) P from dbo.DwACSpan;
select max(p) P from dbo.DwDanShuangSpan ;
select max(p) P from dbo.DwDaXiaoSpan;
select max(p) P from dbo.DwHeSpan;
select max(p) P  from dbo.DwHeWeiSpan;
select max(p) P from dbo.DwJiSpan;
select max(p) P  from dbo.DwJiWeiSpan;
select max(p) P from dbo.DwKuaDuSpan;
select max(p) P from dbo.DwLu012Span;
select max(p) P  from dbo.DwZiHeSpan;

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