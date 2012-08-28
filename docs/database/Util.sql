DBCC SHRINKFILE (LotteryChongQSSC_Log, 1);
DBCC SHRINKFILE (LotteryGuangD115_Log, 1);
DBCC SHRINKFILE (LotteryJiangX115_Log, 1);
DBCC SHRINKFILE (LotteryJiangXSSC_Log, 1);
DBCC SHRINKFILE (LotteryShanD115_Log, 1);

Alter table DmA4 add [Ji] [int] NULL;
Alter table DmA4 add [JiWei] [int]  NULL;
Alter table DmA4 add [KuaDu] [int]  NULL;
Alter table DmA4 add [AC] [int] NULL ;

Alter table DmA5 add [Ji] [int] NULL;
Alter table DmA5 add [JiWei] [int]  NULL;
Alter table DmA5 add [KuaDu] [int]  NULL;
Alter table DmA5 add [AC] [int] NULL ;

Alter table DmA6 add [Ji] [int] NULL;
Alter table DmA6 add [JiWei] [int]  NULL;
Alter table DmA6 add [KuaDu] [int]  NULL;
Alter table DmA6 add [AC] [int] NULL ;

Alter table DmA7 add [Ji] [int] NULL;
Alter table DmA7 add [JiWei] [int]  NULL;
Alter table DmA7 add [KuaDu] [int]  NULL;
Alter table DmA7 add [AC] [int] NULL ;

Alter table DmA8 add [Ji] [int] NULL;
Alter table DmA8 add [JiWei] [int]  NULL;
Alter table DmA8 add [KuaDu] [int]  NULL;
Alter table DmA8 add [AC] [int] NULL ;

Alter table DmC2 add [Ji] [int] NULL;
Alter table DmC2 add [JiWei] [int]  NULL;
Alter table DmC2 add [KuaDu] [int]  NULL;
Alter table DmC2 add [AC] [int] NULL ;

Alter table DmC3 add [Ji] [int] NULL;
Alter table DmC3 add [JiWei] [int]  NULL;
Alter table DmC3 add [KuaDu] [int]  NULL;
Alter table DmC3 add [AC] [int] NULL ;

Alter table DmD1 add [Ji] [int] NULL;
Alter table DmD1 add [JiWei] [int]  NULL;
Alter table DmD1 add [KuaDu] [int]  NULL;
Alter table DmD1 add [AC] [int] NULL ;

Alter table DmF2 add [Ji] [int] NULL;
Alter table DmF2 add [JiWei] [int]  NULL;
Alter table DmF2 add [KuaDu] [int]  NULL;
Alter table DmF2 add [AC] [int] NULL ;

Alter table DmF3 add [Ji] [int] NULL;
Alter table DmF3 add [JiWei] [int]  NULL;
Alter table DmF3 add [KuaDu] [int]  NULL;
Alter table DmF3 add [AC] [int] NULL ;


//ssc

Alter table DmC2 add [Ji] [int] NULL;
Alter table DmC2 add [JiWei] [int]  NULL;
Alter table DmC2 add [KuaDu] [int]  NULL;
Alter table DmC2 add [AC] [int] NULL ;

Alter table DmC3 add [Ji] [int] NULL;
Alter table DmC3 add [JiWei] [int]  NULL;
Alter table DmC3 add [KuaDu] [int]  NULL;
Alter table DmC3 add [AC] [int] NULL ;

Alter table DmC33 add [Ji] [int] NULL;
Alter table DmC33 add [JiWei] [int]  NULL;
Alter table DmC33 add [KuaDu] [int]  NULL;
Alter table DmC33 add [AC] [int] NULL ;

Alter table DmC36 add [Ji] [int] NULL;
Alter table DmC36 add [JiWei] [int]  NULL;
Alter table DmC36 add [KuaDu] [int]  NULL;
Alter table DmC36 add [AC] [int] NULL ;

Alter table DmD1 add [Ji] [int] NULL;
Alter table DmD1 add [JiWei] [int]  NULL;
Alter table DmD1 add [KuaDu] [int]  NULL;
Alter table DmD1 add [AC] [int] NULL ;

Alter table DmP2 add [Ji] [int] NULL;
Alter table DmP2 add [JiWei] [int]  NULL;
Alter table DmP2 add [KuaDu] [int]  NULL;
Alter table DmP2 add [AC] [int] NULL ;

Alter table DmP3 add [Ji] [int] NULL;
Alter table DmP3 add [JiWei] [int]  NULL;
Alter table DmP3 add [KuaDu] [int]  NULL;
Alter table DmP3 add [AC] [int] NULL ;

Alter table DmP4 add [Ji] [int] NULL;
Alter table DmP4 add [JiWei] [int]  NULL;
Alter table DmP4 add [KuaDu] [int]  NULL;
Alter table DmP4 add [AC] [int] NULL ;

Alter table DmP5 add [Ji] [int] NULL;
Alter table DmP5 add [JiWei] [int]  NULL;
Alter table DmP5 add [KuaDu] [int]  NULL;
Alter table DmP5 add [AC] [int] NULL ;


select * from dbo.DwC2PeroidSpan order by P desc;
select * from  dbo.DwC33PeroidSpan order by P desc;
select * from dbo.DwC36PeroidSpan  order by P desc;
select * from  dbo.DwC3PeroidSpan order by P desc;
select * from   dbo.DwP2PeroidSpan order by P desc;
select * from  dbo.DwP3PeroidSpan order by P desc;
select * from  dbo.DwP4PeroidSpan order by P desc;
select * from dbo.DwP5PeroidSpan order by P desc;
select * from dbo.DwD1PeroidSpan order by P desc;

truncate table dbo.DwD1PeroidSpan

select COUNT(*) from DwNumber;
select COUNT(*) from dbo.DwD1PeroidSpan;
select COUNT(*) from dbo.DwP2PeroidSpan;
select COUNT(*) from dbo.DwP3PeroidSpan;
select COUNT(*) from dbo.DwP4PeroidSpan;
select COUNT(*) from dbo.DwP5PeroidSpan;
select COUNT(*) from dbo.DwC2PeroidSpan;
select COUNT(*) from dbo.DwC3PeroidSpan;

select * from DwNumber order by P desc;
select * from DwPeroidSpan order by P desc;

update DwPeroidSpan set D1Spans = t2.Spans from DwD1PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P2Spans = t2.Spans from DwP2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P3Spans = t2.Spans from DwP3PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P4Spans = t2.Spans from DwP4PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set P5Spans = t2.Spans from DwP5PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C2Spans = t2.Spans from DwC2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C3Spans = t2.Spans from DwC3PeroidSpan t2 where DwPeroidSpan.P = t2.P;

drop table dbo.DwDanShuangSpan;
drop table dbo.DwDaXiaoSpan;
drop table  dbo.DwHeSpan;
drop table  dbo.DwHeWeiSpan;
drop table  dbo.DwLu012Span;
drop table  dbo.DwPeroidSpan;
drop table  dbo.DwZiHeSpan;

select * from DwNumber;
select * from dbo.DwA5PeroidSpan;
select * from dbo.DwC2PeroidSpan;
select * from dbo.DwC3PeroidSpan;
select * from dbo.DwF2PeroidSpan;
select * from dbo.DwF3PeroidSpan;
select * from dbo.DwD1PeroidSpan;


drop table dbo.DwD1PeroidSpan
drop table dbo.DwP2PeroidSpan;
drop table  dbo.DwP3PeroidSpan;
drop table  dbo.DwP4PeroidSpan;
drop table  dbo.DwP5PeroidSpan;
drop table  dbo.DwC2PeroidSpan;
drop table  dbo.DwC3PeroidSpan;
drop table  dbo.DwC33PeroidSpan;
drop table  dbo.DwC36PeroidSpan;

--insert into DwPeroidSpan (P) select P from DwNumber order by P desc;
--select * from DwPeroidSpan order by P desc;
--truncate table DwPeroidSpan
update DwPeroidSpan set D1Spans = t2.Spans from DwD1PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set F2Spans = t2.Spans from DwF2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set F3Spans = t2.Spans from DwF3PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C2Spans = t2.Spans from DwC2PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set C3Spans = t2.Spans from DwC3PeroidSpan t2 where DwPeroidSpan.P = t2.P;
update DwPeroidSpan set A5Spans = t2.Spans from DwA5PeroidSpan t2 where DwPeroidSpan.P = t2.P;



Alter table DmC2 alter column [Ji] [int] NOT NULL;
Alter table DmC2 alter column [JiWei] [int]  NOT NULL;
Alter table DmC2 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC2 alter column [AC] [int] NOT NULL;

Alter table DmC3 alter column [Ji] [int] NOT NULL;
Alter table DmC3 alter column [JiWei] [int]  NOT NULL;
Alter table DmC3 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC3 alter column [AC] [int] NOT NULL;

Alter table DmC33 alter column [Ji] [int] NOT NULL;
Alter table DmC33 alter column [JiWei] [int]  NOT NULL;
Alter table DmC33 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC33 alter column [AC] [int] NOT NULL;

Alter table DmC36 alter column [Ji] [int] NOT NULL;
Alter table DmC36 alter column [JiWei] [int]  NOT NULL;
Alter table DmC36 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC36 alter column [AC] [int] NOT NULL;

Alter table DmD1 alter column [Ji] [int] NOT NULL;
Alter table DmD1 alter column [JiWei] [int]  NOT NULL;
Alter table DmD1 alter column [KuaDu] [int]  NOT NULL;
Alter table DmD1 alter column [AC] [int] NOT NULL;

Alter table DmP2 alter column [Ji] [int] NOT NULL;
Alter table DmP2 alter column [JiWei] [int]  NOT NULL;
Alter table DmP2 alter column [KuaDu] [int]  NOT NULL;
Alter table DmP2 alter column [AC] [int] NOT NULL;

Alter table DmP3 alter column [Ji] [int] NOT NULL;
Alter table DmP3 alter column [JiWei] [int]  NOT NULL;
Alter table DmP3 alter column [KuaDu] [int]  NOT NULL;
Alter table DmP3 alter column [AC] [int] NOT NULL;

Alter table DmP4 alter column [Ji] [int] NOT NULL;
Alter table DmP4 alter column [JiWei] [int]  NOT NULL;
Alter table DmP4 alter column [KuaDu] [int]  NOT NULL;
Alter table DmP4 alter column [AC] [int] NOT NULL;

Alter table DmP5 alter column [Ji] [int] NOT NULL;
Alter table DmP5 alter column [JiWei] [int]  NOT NULL;
Alter table DmP5 alter column [KuaDu] [int]  NOT NULL;
Alter table DmP5 alter column [AC] [int] NOT NULL;


//11x5
Alter table DmA4 alter column [Ji] [int] NOT NULL;
Alter table DmA4 alter column [JiWei] [int]  NOT NULL;
Alter table DmA4 alter column [KuaDu] [int]  NOT NULL;
Alter table DmA4 alter column [AC] [int] NOT NULL;

Alter table DmA5 alter column [Ji] [int] NOT NULL;
Alter table DmA5 alter column [JiWei] [int]  NOT NULL;
Alter table DmA5 alter column [KuaDu] [int]  NOT NULL;
Alter table DmA5 alter column [AC] [int] NOT NULL;

Alter table DmA6 alter column [Ji] [int] NOT NULL;
Alter table DmA6 alter column [JiWei] [int]  NOT NULL;
Alter table DmA6 alter column [KuaDu] [int]  NOT NULL;
Alter table DmA6 alter column [AC] [int] NOT NULL;

Alter table DmA7 alter column [Ji] [int] NOT NULL;
Alter table DmA7 alter column [JiWei] [int]  NOT NULL;
Alter table DmA7 alter column [KuaDu] [int]  NOT NULL;
Alter table DmA7 alter column [AC] [int] NOT NULL;

Alter table DmA8 alter column [Ji] [int] NOT NULL;
Alter table DmA8 alter column [JiWei] [int]  NOT NULL;
Alter table DmA8 alter column [KuaDu] [int]  NOT NULL;
Alter table DmA8 alter column [AC] [int] NOT NULL;

Alter table DmC2 alter column [Ji] [int] NOT NULL;
Alter table DmC2 alter column [JiWei] [int]  NOT NULL;
Alter table DmC2 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC2 alter column [AC] [int] NOT NULL;

Alter table DmC3 alter column [Ji] [int] NOT NULL;
Alter table DmC3 alter column [JiWei] [int]  NOT NULL;
Alter table DmC3 alter column [KuaDu] [int]  NOT NULL;
Alter table DmC3 alter column [AC] [int] NOT NULL;

Alter table DmD1 alter column [Ji] [int] NOT NULL;
Alter table DmD1 alter column [JiWei] [int]  NOT NULL;
Alter table DmD1 alter column [KuaDu] [int]  NOT NULL;
Alter table DmD1 alter column [AC] [int] NOT NULL;

Alter table DmF2 alter column [Ji] [int] NOT NULL;
Alter table DmF2 alter column [JiWei] [int]  NOT NULL;
Alter table DmF2 alter column [KuaDu] [int]  NOT NULL;
Alter table DmF2 alter column [AC] [int] NOT NULL;

Alter table DmF3 alter column [Ji] [int] NOT NULL;
Alter table DmF3 alter column [JiWei] [int]  NOT NULL;
Alter table DmF3 alter column [KuaDu] [int]  NOT NULL;
Alter table DmF3 alter column [AC] [int] NOT NULL;


update DmP5 set
ZiHe = t2.ZiHe,
ZiCnt = t2.ZiCnt,
HeCnt = t2.HeCnt,
Ji = t2.Ji,
JiWei = t2.JiWei,
KuaDu = t2.KuaDu,
AC = t2.AC
from LotteryChongQSSC.dbo.DmP5 t2 where DmP5.Id = t2.Id;