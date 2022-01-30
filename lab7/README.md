# Lab 7
## Aplikacje CRUD
Aplikacja powstała częściowo przy pomocy tutorialu https://www.bezkoder.com/django-react-axios-rest-framework/. Backend aplikacji i powiadomienia we frontendzie do nieudanych akcji były wykonane przez mnie.

### Widok dodanych wcześniej tutoriali
![nua](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/listatutoriali.png)

### Prośba o przekazywanie powiadomień(Użyte w celu przedstawenia błędów wypełniania tworzonych tutoriali)
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/powiadomienia.png)

### Widok wyszukiwania tutoriali przy pomocy cząstkowych danych
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwanieczesciowe.png)

### Widok wyszukiwania tutoriali przy pomocy dokładnej frazy
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwaniecalkowite.png)

### Widok dodawania nowego tutorialu bez wprowadzenia danych
![nus](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/brakuj%C4%85ce%20dane.png)

### Widok dodawania nowego tutorialu gdy tytuł i opis są takie same 
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/te%20same%20dane.png)

### Dodany tutorial po wprowadzony poprawnie danych
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/nowytutorial.png)

### Widok Edycji przed zmianą danych tutorialu
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/skuteczna%20zmiana.png)

### Widok Tutoriali po skutecznej zmianie
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/skuteczna%20zmiana%20potwierdzenie.png)
### Widok Edycji przed zmianą statusu publikacji
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/przedzmianapublikacji.png)

### Widok Edycji po zmianie statusu publikacji
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/pozmianiepublikacji.png)

### Widok listy po usunięciu jednego z tutoriali
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/usuniecietutoriala.png)

### Widok listy po usunięciu wszystkich tutoriali
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/usunieciewszystkich%20tutoriali.png)

# Dodatkowe zmiany w aplikacji

## Zmiana wyszukiwarki
Dodałem opcje wybrania pomiędzy wyszukiwaniem po opisie lub po tytule. Teraz gdy pole wyszukiwania jest puste przycisk jest blokowany.

### Wyszukiwanie po tytule 
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwaniepotytule.png)

### Wyszukiwanie po opisie przy błędnych danych
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwaniepoopisie.png)

### Wyszukiwanie po opisie przy poprawnych danych
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwaniepoopisie2.png)

### Brak tekstu - przycisk zablokowany
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/wyszukiwanie%20bez%20tekstu.png)

### Kod nowej funkcjonalności
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/dodanie%20funkcji%20do%20wyszukiwania.png)

## Refaktoryzacja kodu
W refaktoryzacji głownie zagnieżdzałem funkcje zmiany wartości stanu i gdy kod był używany przynajmniej dwukrotnie to przenosiłem go do osobnej funkcji w celu uproszczenia kodu i zwiększenia przejrzystości.

### tutorial-list
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/tutorials-list.png)

### add-tutorial
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab7/assets/addtutorialzmiany.png)

