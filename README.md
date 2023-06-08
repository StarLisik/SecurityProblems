# Запуск программы
Запуск сервера произведем выполнение .exe файла по пути "…\SecurityProblems\bin\Debug\net7.0\SecurityProblems.exe". При запуске в командной строке увидим адрес сервера.
 
![image](https://github.com/StarLisik/SecurityProblems/assets/71330701/092ff979-65ab-4e7d-8b0a-03f49447b62b)

Перейдя по указанному адресу, попадем на страницу сервера, где тот запросит сертификат.

![image](https://github.com/StarLisik/SecurityProblems/assets/71330701/94669bec-6ef2-43c4-bbb2-9ba6077b90c2)


Чтобы указать клиентский сертификат, нужно в настройках браузера перейти в настройку сертификатов, и в личное хранилище сертификатов добавить child.ptx, который находится по тому же пути, что .exe программы. Для этого нужно нажать “Импорт” и найти нужный сертификат. После этого сервер сможет нас пропустить.
 
![image](https://github.com/StarLisik/SecurityProblems/assets/71330701/f7de2960-4ad1-4141-9641-7f154bccee01)

Если все сделано верно, то увидим следующую надпись:

 ![image](https://github.com/StarLisik/SecurityProblems/assets/71330701/1a65255c-0397-4bc0-970d-7c2fd1d013db)

