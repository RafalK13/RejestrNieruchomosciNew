use RejestrNieruchomosciNew
insert into Dzialka ( Numer, ObrebId, Kwakt, Kwzrob, Pow)

select a.[Nr dzia�ki] as 'Numer', o.ObrebId as 'ObrebId', a.[Nowy nr KW] as 'Kwakt', a.KW as 'Kwzrob', a.Powierzchnia as 'Pow'
--select a.[Obr�b numerycznie], count(a.[Obr�b numerycznie])
from Arkusz1$ a
inner join obreb o
on ((( a.[ObrebRaf] = o.Numer AND o.GminaSloId = 1) or (a.[ObrebRaf]=o.Nazwa AND o.GminaSloId !=1)) and not (o.GminaSloId !=4 and a.[ObrebRaf] = 'Borkowo'))
--group by (a.[Obr�b numerycznie])


