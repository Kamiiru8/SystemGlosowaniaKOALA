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
- <b>MainActivity.cs</b> – aktywność reprezentująca pierszy ekran apikacji (rys 1.) . Na początku przy pomocy SharedPreferences zostaje podjęta próba pobrania watrości z pliku "UserInfo" zapisanego w pamięci lokalenj urządzenia<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L31-#L35"><sup>[1]</sup></a>. Wartości te zostają zapisane w po zalogowaniu użytkownika za pomocą kodu QR<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L80-#L86"><sup>[2]</sup></a> lub tokenu<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/TokenActivity.cs#L55-#L60"><sup>[3]</sup></a>. Użytkownik jest ciagle zalogowany w aplikacji dopóki nie wyrazi chęci wylogowania poprzez przyciśnięcie przycisku „Wyloguj”<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/WelcomeActivity.cs#L67-#L94"><sup>[4]</sup></a> lub wygaśnie ważność tokenu (24 godziny)<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L37-#L45"><sup>[5]</sup></a>. Zapobiega to niechcianemu wylogowaniu się z aplikacji podczas głosowania – np. przypadkowe wyłączenie aplikacji, a nawet po ponownym uruchomienu telefonu użytkownik będzie stale zalogowany. Jeśli głosowanie zakończy się, użytkownik zostaje przeniesiony do ekranu powitalnego (Rys. 4), gdzie oczekuje na rozpoczęcie kolejnego głosowania.
Jeśli istnieje aktualnie zalogowany użytkownik (w pamięci urządzenia zapisane są dane użytkownika) zostaje wyświetlony ekran powitalny (rys. 4), gdzie użytkownik oczekuje na rozpoczęcie się głosowania.
Jeśli nie istnieje aktualnie zalogowany użytkownik (brak danych użytkownika w pamięci urządzenia), wtedy zostaje wyświeltony ekran główny aplikacji (rys. 1) z możliwością zlogowania się na dwa sposoby – za pomocą zeskanowania kodu QR (rys. 2) lub wpisania tokenu (rys. 3). W tej klasie została zdefiniowana akcja po przyciśnięciu przycisku „Zeskanuj QR”<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L64-#L107"><sup>[6]</sup></a> oraz przycisku „Wpisz token”<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L109-#L110"><sup>[7]</sup></a>. Do skanowania kodów QR użyto biblioteki ZXing.Net.Mobile, ktora zwraca rozpoznay tekst<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L66-#L67"><sup>[8]</sup></a>. Użytkownik chcący zalogować się za pomocą kodu QR podchodzi do osoby prowadzącej głosowanie, która generuje dla danej osoby inwidualny kod QR. Użytkownik skanuje ten kod i zostaje uwierzytelniony. W kodzie QR zakodowany jest adres URL, który zostaje rozpoznany i zdekodowany przez bibliotekę ZXing.Net.Mobile, po czym przechodzi do podanego adresu URL, pobiera obiekt JSON, który zostaje zdeserializowany, a zmienne z niego wyłuskane zostają zapisane do pamieci lokalnej urządzenia<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L72-#L86"><sup>[9]</sup></a>. W celu poprawnego działania aplikacji zostaje sprawdzana dostępność połączenia z serwerem WWW Systemu Głosowania<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/MainActivity.cs#L129-#L144"><sup>[10]</sup></a>.

- <b>TokenActivity.cs</b> – aktywność reprezentująca ekran tokenu (rys. 3). Tutaj zostaje obsłużona akcja po przyciśnieciu „Zatwierdź”<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/TokenActivity.cs#L40-#L82"><sup>[1]</sup></a>. Używając tego ekranu użytkownik może wpisać token wygenerowany dla tego użytkownika przez osobę prowadzącą głosowanie. Jeśli użytkownik przepisał poprawnie token, zostanie przeniesiony do ekranu powitalnego (Rys. 4).

- <b>WelcomeActivity.cs</b> – aktywnośc reprezentująca ekran powitalny (Rys 4.). Na tym ekranie zostają wyświetlone imię i nazwisko zalogowanego użytkownika. Jeśli nie istnieje aktyne głosowanie, użytkownik będzie oczekiwał na jego rozpoczęcie. Jeśli istnieje, zostanie przeniesiony do ekranu głosowania (Rys. 5). 
Sprawdznie, czy istnieje aktyne głosowanie odbywa się z częstotliwiścią jednej sekundy - co sekundę zostaje zprawdzona zawartość obiektu JSON<a target="_blank" href="https://github.com/Kamiiru8/SystemGlosowaniaKoala/blob/master/WelcomeActivity.cs#L103-#L129"><sup>[1]</sup></a>.

- <b>VoteActivity.cs</b> – aktywność reprezentująca ekran głosowania (Rys 5.), (Rys. 6). Ekran przedstawia szesć przycisków – z czego są aktywne tylko te, które są odpowiadają odpowiedzi dostępnej w głosowaniu. Minimalna ilość odpowiedzi w głosowaniu to dwa. Ostatnio przyciśnięty przycisk oznaczany jest obwódką. Za odpowiedź zobowiązującą uważa się ostatnio wybrany przycisk.
<br/><br/>
