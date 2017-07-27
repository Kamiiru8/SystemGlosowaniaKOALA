<b>Nazwa projektu:</b> System Głosowania Koala<br/>
<b>Autorzy:</b> Kamiiru8 + 4 inne osoby<br/>
<b>Zakres moich prac:</b> Aplikacje mobilne emulujące działanie fizycznego pilota dla systemów Android i iOS, grafiki<br/>
<b>Wykorzystane przeze mnie:</b><br/>
- <b>Język programowania:</b> C#<br/>
- <b>Środowisko programistyczne:</b> Xamarin Studio<br/>
- <b>Użyte technologie:</b> ZXing.Net.Mobile, JSON<br/><br/>


<b>Opis:</b> Projekt powstał na potrzeby przedmiotu oraz konkursu Programowania Zespołowego Wydziału Matematyki i Informatyki UMK.<br/><br/>

<b>Link do strony projektu:</b><br/>
https://aleks-2.mat.umk.pl/pz2016/zesp05/index.html<br/><br/>

<b>Link do wideoprezentacji:</b><br/>
http://tv.umk.pl/#movie=3489
<br/><br/>

<b>Ulotka projektu:</b><br/><br/>
![ulotkas](https://user-images.githubusercontent.com/29763402/28135223-be9fbd58-6745-11e7-8be8-9c4dd288f13f.jpg)
<br/><br/>

<b>Aplikacja mobilna:</b><br/><br/>
<img width="600" alt="app1" src="https://user-images.githubusercontent.com/29763402/28137008-f5b48804-674b-11e7-9c93-122d21fc4489.png">
<img width="615" alt="app2" src="https://user-images.githubusercontent.com/29763402/28136906-89694356-674b-11e7-94e1-f3d15756c606.png">
<br/><br/>

<b>Opis aktywności projektu:</b><br/>
- <b>MainActivity.cs</b> – aktywność reprezentująca pierszy ekran apikacji (rys 1.) . Pierwszą rzeczą przy uruchamianiu aplikacji jest sprawdzenie, czy istnieje aktualnie zalogowany użytkownik <a href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L31-#L35">[KOD].</a> Dane użytkownika (imię, nazwisko i numer) zostają zapisane w pamięci lokalnej urządzenia przy użyciu SharedPreferences podczas logowania. Użytkownik jest ciagle zalogowany w aplikacji dopóki nie wyrazi chęci wylogowania poprzez przyciśnięcie przycisku „Wyloguj”. Zapobiega to niechcianemu wylogowaniu się z aplikacji podczas głosowania – np. przypadkowe wyłączenie aplikacji, a nawet po ponownym uruchomienu telefonu użytkownik będzie stale zalogowany. Jeśli głosowanie zakończy się, użytkownik zostaje przeniesiony do ekranu powitalnego (Rys. 4), gdzie oczekuje na rozpoczęcie kolejnego głosowania.
Jeśli istnieje aktualnie zalogowany użytkownik (w pamięci urządzenia zapisane są dane użytkownika) zostaje wyświetlony ekran powitalny (rys. 4), gdzie użytkownik oczekuje na rozpoczęcie się głosowania.
Jeśli nie istnieje aktualnie zalogowany użytkownik (brak danych użytkownika w pamięci urządzenia), wtedy zostaje wyświeltony ekran główny aplikacji (rys. 1) z możliwością zlogowania się na dwa sposoby – za pomocą zeskanowania kodu QR (rys. 2) lub wpisania tokenu (rys. 3). W tej klasie została zdefiniowana akcja po przyciśnięciu przycisku „Zeskanuj QR” - bQR oraz przycisku „Wpisz token” - bToken.
W tej klasie zostają również zapisane dane logowania do pamięci urządzenia, sprawdzany dostęp do połąznia internetowego. Korzystanie z aplikacji wymaga aktywnego połącznia z internetem (metoda public bool CheckInternetConnection() ).

- <b>TokenActivity.cs</b> – aktywność reprezentująca ekran tokenu (rys. 3). Tutaj zostaje obsłużona akcja po przyciśnieciu „Zatwierdź”. Używając tego ekranu użytkownik może wpisać token wygenerowany dla tego użytkownika przez osobę prowadzącą głosowanie. Jeśli użytkownik przepisał poprawnie token, zostanie przeniesiony do ekranu powitalnego (Rys. 4).

- <b>WelcomeActivity.cs</b> – aktywnośc reprezentująca ekran powitalny (Rys 4.). Na tym ekranie zostają wyświetlone imię i nazwisko zalogowanego użytkownika. Jeśli nie istnieje aktyne głosowanie, użytkownik będzie oczekiwał na jego rozpoczęcie. Jeśli istnieje, zostanie przeniesiony do ekranu głosowania (Rys. 5). 
Sprawdznie, czy istnieje aktyne głosowanie odbywa się z częstotliwiścią jednej sekundy.

- <b>VoteActivity.cs</b> – aktywność reprezentująca ekran głosowania (Rys 5.), (Rys. 6). Ekran przedstawia szesć przycisków – z czego są aktywne tylko te, które są odpowiadają odpowiedzi dostępnej w głosowaniu. Minimalna ilość odpowiedzi w głosowaniu to dwa. Ostatnio przyciśnięty przycisk oznaczany jest obwódką. Za odpowiedź zobowiązującą uważa się ostatnio wybrany przycisk.
<br/><br/>
