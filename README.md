To Use Our Endpoint you should :

1- go to signin endpoint and click on try it out endpoint the fill your username and password and click Execute button 
![image](https://github.com/raghadnat/BookShop/assets/48677763/40282f43-c24d-4db1-ad3e-10ee207c3ff7)

2- you will found an JWT returned token you should save it to use it on next step.
![image](https://github.com/raghadnat/BookShop/assets/48677763/e1945967-ba9a-4fa3-816e-98495bcf1959)

3- click on authorize endpoint and fill the text box with Bearer + returned JWT token from above step.
![image](https://github.com/raghadnat/BookShop/assets/48677763/70eac5e7-4afa-4138-83cb-6fe69380a8b3)

4- to get books you should call api/book/GetAll endpoint 
![image](https://github.com/raghadnat/BookShop/assets/48677763/0cd80d62-0239-4d05-b4ee-89ee2d64424b)

the endpoint will return list of all existing books.
![image](https://github.com/raghadnat/BookShop/assets/48677763/58689ca1-88f5-40ac-a0e3-6f8e78125131)

5- to borrow a book you should call api/book/borrow/bookId/StudentId endpoint 
![image](https://github.com/raghadnat/BookShop/assets/48677763/ce9873c2-2771-42f9-9ced-294c5d56d64c)

click on try it out and fill the bookId and studentId 
the Response will look like the image bellow after book borrowed
![image](https://github.com/raghadnat/BookShop/assets/48677763/18c74991-eaf0-46d6-803d-838b27f1f38a)





