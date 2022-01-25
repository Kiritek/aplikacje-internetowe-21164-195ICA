# Lab 4/6 REST Api
## Dokumentacja api Swagger

### ApiGet
![nua](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/GetPostsSwagger.png)

### ApiGetId
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/getIdSwagger.png)

### ApiPost
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/postapiswagger.png)

### ApiPut
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/putSwagger.png)

### ApiDelete
![nus](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/DeleteSwagger.png)

### PostDto(Do akcji get) 
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/SchematPostDto.png)

### PostCreationDto(do akcji post/put)
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/SchematPostCreationDto.png)

### Kod z kontrolera dla zapytania delete
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/DeleteReal.png)

Swagger poprawnie odczytał obiekty jakimi posługuje się api. Dla otrzymywania danych jest to PostDto a dla tworzenia PostCreationDto. Nie udało mu się poprawnie zmapować ścieżek w kontrolerze gdyż dla przykładowo akcji delete nie znalazł tego że w przypadku braku postu jest to NotFound. Tak samo nie znalazł ścieżki Unauthorized i NoContent jedynie podał nieistniejąca Ok. Dzieje się tak dla wszystkich czasowników w kontrolerze.

## Przesyłanie zapytań i uwierzytelnianie
Do uwierzytelniania i autoryzacji wykorzystywany jest jwt. Polega to na tym że w każdym zapytaniu do api trzeba podać token który zawiera informacje o użytkowniku które pozwalają na uwierzytelnienie i autoryzacje w formie zaszyfrowanej. Dane z tokena można odczytać już odszyfrowane można odczytać w kontrolerze gdzie można użyć go do ustalenia czy użytkownik może używać go.
W tym przypadku do zapytania fetch dodaje sprowadzany z menedzera authroyzacji token i doklejam go w nagłówkach. Kod używany do tego jest poniżej

![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/swagger/tokenreal.png)

## Użytkownicy w aplikacji
Do stworzenia obsługi użytkowników użyłem wbudowanego systemu Identity.

### Widok Rejstracji
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/rejstracja.png)

### Widok Potwierdzenia Maila
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/potwierdzenie%20maila.png)

### Widok Zatwierdznego Konta
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/potwierdzenie%20maila2.png)

### Profil użytkownika
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/profil%20uzytownika.png)

## Obsługa Aplikacji
Do aplikacji dodałem zasady że każdy użytkownik może edytować i usuwać tylko swoje posty, chyba że jest Administratorem.
### Lista wszystkich postów
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/posty%20przed%20dodaniem.png)

### Wyszukiwanie postów
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/Szukanie%20po%20tytule.png)

### Dodawanie postu
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/dodanie%20nowego%20postu.png)

### Lista z dodanym postem
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/dodanie%20nowego%20postu2.png)

### Edycja własnego postu
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/edycja%20wlasnego%20postu.png)

### Edycja własnego postu wynik
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/edycja%20wlasnego%20postu2.png)

### Usunięcie własnego postu wynik
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/usuniecie%20wlasnego%20postu.png)

### Próba edycji postu innego użytkownika
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/edycja%20cudzego%20postu.png)

### Próba usunięcia postu innego użytkownika
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/usuniecie%20cudzego%20postu.png)

W obydwu przykładach kończy się to tylko komunikatem nieuatoryzowany. Przed przejściem na konto admina dodałem post by go spróbowac z niego zmodyfikować.

![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/przedzmianamiadmin.png)

### Edycja posta innego użytkownika admin
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/zmianyadmin.png)

### Lista postów po zmianie admina
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/zmianyadminfix.png)

### Lista postów po usunięciu postu innego użytkownika przez admina
![wl](https://github.com/Kiritek/aplikacje-internetowe-21164-195ICA/blob/main/lab46/assets/usuniecieadmin.png)

