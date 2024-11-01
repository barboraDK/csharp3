# Feedback Assignment 06.1

Dokonalá práce ;) Nemám k tomu prakticky co říci. Jen tak dál.

Co bych vypíchl proč se mi to líbí (mluvím teď zejména o ToDoItemsRepository, jelikož tam jsou uhlavní změny):
1) minimalistický kód - co jde udělat na jeden řádek je uděláno na jeden řádek
2) nezakládáš si zbytečně pomocné proměnné - ty můžou znepřehlednit kód. Tvůj kód je pěkně čitelný
3) Práce s nullable return value - šlo by to obejít přes více návratových hodnot (např. že by metody vracely struct (ToDoItem, bool) kdy by bool byl indikátor zda se nám operace povedla), ale to je pak velmi nepřehledné. Máš spávnou práci s nullable return value, je to dobře čitelné a je jasné na první pohled že máme počítat s tím že metoda může jako ToDoItem vrátit null.
4) DeleteById taky vrací nullable ToDoItem - momentálně nechceme další práci s úkolem co smažeme, stačí nám info že úkol s daným id byl nalezen a smazán, což šlo by to přes bool. Tvoje řešení je ale přímo připravené na možnost že se změní zadání a třeba něco s úkolem který smažeme budeme chtít něco udělat.
