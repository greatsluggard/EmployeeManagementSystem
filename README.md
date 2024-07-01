## **Инструкция по установке и запуску**

1. Склонируйте данный репозиторий локально на своё устройство в некую папку, например, Projects

2. Откройте корневую директорию проекта используя командлер cmd, git bash, windows shell. Например: 
```
$ cd /Projects/EmployeeManagementSystem
```
3. Откройте Docker Desktop

4. Находясь в корневой директории проекта в командлере, введите команду:
```
$ docker-compose up --build
```
5. У вас запуститься оркестр контейнеров с четырьмя контейнерами внутри.

6. Откройте оркестр контейнеров и запустите контейнер emp

7. Перейдите в бразуер и введите: http://localhost:5001/swagger/index.html

     Для доступа к функционалу отправки Employee в RabbitMQ

8. Перейдите в браузер и введите: http://localhost:5002/swagger/index.html

     Для доступа к функционалу:
     - получения всех Employee
     - получения Employee по имени Department

9. Перейдите в браузер и введите: http://localhost:15672/#/

   Для отслеживания отправки и обработки сообщений в RabbitMQ