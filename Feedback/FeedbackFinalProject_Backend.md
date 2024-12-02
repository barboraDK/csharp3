# Feedback FInal Project Backend

Hlavně bych vysvětlil chyby v DTO - máš tam string Category a ne string? Category.
Co to znamená? Ten otazním znamená že tam může být null.
Category má být nepovinný parametr, tvoje momentální řešení způsobí to že povinný je - musím v http requestu poslat toto políčko (viz jak sis upravila http soubor) jinak narazím na error.

Dále musím zmínit, že nyní děláme finální projekt který je finálním výstupem celého kurzu. Z toho pohledu je nyní potřeba dodělat Unit testy - chceme mít otestované všechny http metody.
