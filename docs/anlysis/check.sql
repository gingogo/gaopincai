select date,count(*) times from dim_jx115 group by date having count(*) < 65 order by date desc;
select date,count(*) times from dim_gd115 group by date having count(*) < 65 order by date desc;
select date,count(*) times from dim_sd115 group by date having count(*) < 65 order by date desc;

select distinct date from dim_sd115 order by date desc;
select [date] from dim_date where date > 20091109 and date < 20120721 and date not in(select distinct date from dim_jx115) order by date asc;
select [date] from dim_date where date > 20091214 and date < 20120721 and date not in(select distinct date from dim_gd115) order by date asc;
select [date] from dim_date where date > 20090908 and date < 20120721 and date not in(select distinct date from dim_sd115) order by date asc;
select * from dim_sd115 where date = 20091128

update dim_gd115 set dim_gd115.c = b.times
from (select date,count(*) times from dim_gd115 group by date) b
where dim_gd115.date = b.date;

select d1,d2,d3,count(*) times from dim_jx115
where left(date,4) = '2012' and f3 not in (select distinct f3 from dim_jx115 where date>=20120501 and date <= 20120801)
group by d1,d2,d3
order by d1,d2,d3;

select d1,d2,count(*) times from dim_jx115
where left(date,6) = '201206'
      and f2 not in(select f2 from dim_jx115 where date >= 20120624 and date <20120703)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from dim_jx115
where left(date,6) = '201207'
      and f2 not in(select f2 from dim_jx115 where date >= 20120719 and date <20120724)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from dim_jx115 where date = 20120719 
and f2 not in(select f2 from dim_jx115 where date > 20120719 and date <20120724)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from dim_jx115 where date = 20120717 
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from dim_jx115
where left(date,6) = '201207'
      and f2 not in(select f2 from dim_jx115 where date > 20120716 and date <=20120723)
group by d1,d2
order by d1,d2;

select * from dim_jx115 where left(date,6) = '201207' and f2 in(
select f2 from dim_jx115
where left(date,6) = '201207'
      and f2 not in(select f2 from dim_jx115 where date > 20120714 and date <=20129719))
order by d1,d2,p desc;

select distinct f2 from dim_jx115 order by f2 asc;

select times,count(*) t from(
select date,count(distinct f2) times from dim_sd115
where c = 65
group by date ) a
group by a.times
order by times asc;

select n,COUNT(*) times from dim_gd115 where d1 = 4 and d2 = 10 
group by n
order by n asc;

select  * from dim_gd115 where d1 = 11 and d2 = 5 order by date desc;
select  * from dim_jx115 where d1 = 8 and d2 = 6 order by date desc;

select d1,count(*) times from dim_gd115
where date >= 20120731
group by d1
order by d1 asc;

select d1,count(*) times from dim_gd115
where date = 20120803
group by d1
order by d1 asc;

select d1,count(*) times from dim_jx115
where date = 20120803  
group by d1
order by d1 asc;

select * from dim_jx115 order by p desc
select * from dim_gd115 order by p desc

--truncate table dim_jx115;
--truncate table dim_gd115;
--truncate table dim_sd115;
--truncate table dim_jx115f2cycle;


select d1,d2,count(*) times from dim_jx115
where date = 20120803
group by d1,d2
order by d1,d2;

select * from dim_jx115 where f2 in('0711','1197') and date = 20120731;


select c,COUNT(c) times from dw_jx_f2_cycle
where d = 6
group by c
order by c asc;