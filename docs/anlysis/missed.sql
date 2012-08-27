select d1,d2,count(*) times from DmJiangX11X5
where date > 20120731
      and f2 not in(select f2 from DmJiangX11X5 where date >= 20120812 and date <=20120812)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from DmJiangX11X5 where date > 20120731
and f2 in(select f2 from DmJiangX11X5 where date = 20120806
		  and f2 not in(select f2 from DmJiangX11X5 where date > 20120806 and date <=20120808))
group by d1,d2
order by d1,d2;

------------------------------------------------------------
select d1,d2,count(*) times from DmGuangD11X5
where date >20120630
      and f2 not in(select f2 from DmGuangD11X5 where date > 20120809 and date <=20120812)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from DmGuangD11X5 where date >20120630
and f2 in(select f2 from DmGuangD11X5 where date = 20120730 
		  and f2 not in(select f2 from DmGuangD11X5 where date > 20120730 and date <=20120802))
group by d1,d2
order by d1,d2;

--------------------------------------------------------------------------

select d1,d2,count(*) times from DmShanD11X5
where left(date,6) = '201207'
      and f2 not in(select f2 from DmShanD11X5 where date >= 20120722 and date <=20120724)
group by d1,d2
order by d1,d2;

select d1,d2,count(*) times from DmShanD11X5 where left(date,6) = '201207' 
and f2 in(select f2 from DmShanD11X5 where date = 20120722 
		  and f2 not in(select f2 from DmShanD11X5 where date > 20120722 and date <=20120724))
group by d1,d2
order by d1,d2;
